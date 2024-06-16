using Azure.Core;
using HMS.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.SignalR;
using Microsoft.IdentityModel.Tokens;
using Server.Hubs;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

// Creating our web application
var builder = WebApplication.CreateBuilder(args);

// Set the application to run on local machine on localhost:8080
builder.WebHost.UseUrls("http://localhost:8080");

// Add services for authorization and authentication (JWT Bearer scheme)
builder.Services.AddAuthorization();

// Adding authentication scheme (JSON Web Token Bearer):
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        // JWT validation settings:
        // validate the token issuer, audience, lifetime, and encryption key
        options.TokenValidationParameters = new TokenValidationParameters 
        {
            ValidateIssuer = true,                  // validate token issuer
            ValidIssuer = AuthOptions.ISSUER,       // set token issuer
            ValidateAudience = true,                // validate token audience
            ValidAudience = AuthOptions.AUDIENCE,   // set token audience
            ValidateLifetime = true,                // validate token lifetime
            IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(), // set signing key
            ValidateIssuerSigningKey = true         // validate the signing key
        };

        // Handle message received events (for SignalR token extraction)
        options.Events = new JwtBearerEvents
        {
            OnMessageReceived = context =>
            {
                // Extract the access token from the query string if it exists
                var accessToken = context.Request.Query["access_token"];

                // Check if the request is for a SignalR hub and the token is present
                var path = context.HttpContext.Request.Path; // get the request path
                if (!string.IsNullOrEmpty(accessToken) && path.StartsWithSegments("/myhub")) // if the request is directed to the hub
                {
                    context.Token = accessToken; // Set the token in the context
                }
                return Task.CompletedTask; // return the task
            }
        };
    });

// Adding SignalR service
builder.Services.AddSignalR();

// Adding controller service
builder.Services.AddControllers();
var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

app.UseAuthentication();   // adding authentication middleware 
app.UseAuthorization();    // adding authorization middleware 

// Handling login, passing user data
app.MapPost("/login", async (UserCollection loginModel) =>
{
    // Find the user 
    UserCollection? person = (await new Server.Repositories.UserRepository().Get()).FirstOrDefault(p => p.Username == loginModel.Username && p.Password == loginModel.Password);
    
    // If the user is not found, send status code 401
    if (person is null) return Results.Unauthorized();
    
    // Save the username, role, and ID
    var claims = new List<Claim> 
    { 
        new Claim(ClaimTypes.Name, person.Username), 
        new Claim(ClaimTypes.Role, person.Role),
        new Claim(ClaimTypes.NameIdentifier, person.ID.ToString()),
    };
    
    // Generate JWT token
    var jwt = new JwtSecurityToken(
            issuer: AuthOptions.ISSUER,
            audience: AuthOptions.AUDIENCE,
            claims: claims,
            expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(2)), // Set expiration time to 2 minutes
            signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256)); // Sign the token
    var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt); // Convert the token to a string

    // Prepare the Response
    var response = new
    {
        access_token = encodedJwt,
        userID = person.ID.ToString(),
        role = person.Role
    };

    // Return the response so that the client can save the current user (JSON)
    return Results.Json(response);
});

// Mapping each hub
app.MapHub<MyHub>("/myhub");
app.MapHub<InventoryHub>("/inventoryHub");
app.MapHub<AppointmnetHub>("/appointmnetHub");

// Adding controller mapping
app.MapControllers();

// Start the application
app.Run();

// Class for authentication using tokens
public class AuthOptions
{
    public const string ISSUER = "MyAuthServer"; // token issuer
    public const string AUDIENCE = "MyAuthClient"; // token audience
    const string KEY = "mysupersecret_secretsecretsecretkey!123";   // encryption key
    public static SymmetricSecurityKey GetSymmetricSecurityKey() =>
        new SymmetricSecurityKey(Encoding.UTF8.GetBytes(KEY));
}
