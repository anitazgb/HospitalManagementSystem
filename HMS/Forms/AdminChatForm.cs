using HMS.Models;
using Microsoft.AspNetCore.SignalR.Client;
using System.Net.Http.Json;

namespace HMS.Forms
{
    public partial class AdminChatForm : Form
    {
        private HubConnection connection;
        public AdminChatForm()
        {
            InitializeComponent();

            // Connect to the chat hub
            ConnectToHub();

            // When the form loads, load the data
            Load += async (s, e) => { await LoadData(); };

            // When the send button is clicked
            button1.Click += async (s, e) =>
            {
                // Check if connected to the hub
                if (connection.State == HubConnectionState.Connected)
                {
                    //Get user ID
                    var targetUser = UserCB.SelectedValue.ToString();
                    var message = MessageTB.Text;

                    // Send a method call to the hub with the username and message to them
                    await connection.InvokeAsync("SendMessageToUser", targetUser, message);
                    MessageTB.Text = string.Empty;

                    // After that, get the username by their ID to log our own message in the chat
                    var name = await GetName(CurrentUser.MyUser.ID.ToString());
                    var newMessage = $"{DateTime.Now.ToString("MM.dd.yyyy HH:mm:ss")} {name}: {message}";
                    ChatTB.Text += newMessage + Environment.NewLine;
                }
            };
        }
        // Method for connecting to the hub
        private async void ConnectToHub()
        {
            // Pass the user's token as a parameter
            connection = new HubConnectionBuilder()
                .WithUrl("http://localhost:8080/myhub", options =>
                {
                    options.AccessTokenProvider = () => Task.FromResult(CurrentUser.MyUser.token);
                })
                .Build();

            // Also subscribe to track method calls; if it is called, then
            connection.On<string, string>("ReceiveMessage", (user, message) =>
            {
                // Use Invoke to log the message from another thread to the user interface
                this.Invoke((Action)(async () =>
                {
                    // Again, get the name by ID
                    var name = await GetName(user);
                    var newMessage = $"{DateTime.Now.ToString("MM.dd.yyyy HH:mm:ss")} {name}: {message}";
                    ChatTB.Text += newMessage + Environment.NewLine;
                }));
            });
            
            // The actual connection to the hub
            try
            {
                await connection.StartAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Connection failed: {ex.Message}");
            }
        }

        // Get the username by their ID
        private async Task<string> GetName(string id)
        {
            try
            {
                using var client = new HttpClient();
                var response = await client.PostAsJsonAsync($"http://localhost:8080/api/users/GetName?id={id}", new { });
                var responseString = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    return responseString;
                }
                else
                {
                    return string.Empty;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return string.Empty;
            }
        }

        // Load patient data (write to them only)
        private async Task LoadData()
        {
            using var client = new HttpClient();
            var users = await client.GetFromJsonAsync<List<UserCollection>>("http://localhost:8080/api/users/GetAll");
            UserCB.DataSource = users.Where(x => x.Role == "patient").ToList();
            UserCB.DisplayMember = "Username";
            UserCB.ValueMember = "ID";
        }
    }
}
