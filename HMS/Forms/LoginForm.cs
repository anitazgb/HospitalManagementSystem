using HMS.Forms;
using HMS.Models;
using System.Net.Http.Json;

namespace HMS
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            // Handle the login button click, validate all fields, and then send the data to the API
            // Display the appropriate MessageBox based on the result
            EnterBtn.Click += async (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(UsernameTB.Text))
                {
                    MessageBox.Show("The Username field is not filled in", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (string.IsNullOrWhiteSpace(PasswordTB.Text))
                {
                    MessageBox.Show("The Password field is not filled in", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                using var client = new HttpClient();
                var user = new UserCollection() { Username = UsernameTB.Text, Password = PasswordTB.Text };
                var response = await client.PostAsJsonAsync($"http://localhost:8080/login", user);
                // If the response is OK, deserialize it and save the current user's data in the CurrentUser class
                // - their ID
                // - their token for authentication in hubs
                // - their role for hubs and the client application
                if ((int)response.StatusCode == 200)
                {
                    var responseString = await response.Content.ReadAsStringAsync();
                    dynamic result = Newtonsoft.Json.JsonConvert.DeserializeObject(responseString);

                    string id = result.userID;
                    string token = result.access_token;
                    string role = result.role;
                    MessageBox.Show("You're welcome", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    CurrentUser.MyUser = new CurrentUser.Person(
                        ID: new Guid(id),
                        role: role,
                        token: token);

                    // Depending on the role, open the appropriate form
                    switch (CurrentUser.MyUser.role)
                    {
                        case "doctor":
                            new DoctorForm().Show();
                            break;
                        case "nurse":
                            new MedicalInventoryManagementForm().Show();
                            break;
                        case "admin":
                            new AdminForm().Show();
                            break;
                        case "patient":
                            new PatientForm().Show();
                            break;
                        default:
                            return;
                    }
                    Hide(); // hide the login form
                }
                else
                {
                    MessageBox.Show("User not found", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            };
            // When the register button is clicked, open the appropriate form
            RegisterBtn.Click += (s, e) => new RegistrationForm().ShowDialog();
        }
    }
}
