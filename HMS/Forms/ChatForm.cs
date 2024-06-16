using Microsoft.AspNetCore.SignalR.Client;
using System.Net.Http.Json;

namespace HMS.Forms
{
    public partial class ChatForm : Form
    {
        private HubConnection connection;
        public ChatForm()
        {
            InitializeComponent();
            // Connect to the hub
            ConnectToHub();
            // When the send button is clicked
            SendBtn.Click += async (s, e) =>
            {
                // If connected to the hub, trigger the method and pass our message as a parameter
                if (connection.State == HubConnectionState.Connected)
                {
                    await connection.InvokeAsync("SendMessage", MessageTB.Text);
                    MessageTB.Text = string.Empty;
                }
            };

            // When closing the form, save the chat
            FormClosing += async (s, e) =>
            {
                await SaveChatHistory();
            };
        }
        // Method for saving the chat
        private async Task SaveChatHistory()
        {
            // If the chat is not empty, save it to the database through the API
            if (string.IsNullOrEmpty(ChatTB.Text))
                return;
            try
            {
                var patient = CurrentUser.MyUser.ID.ToString();
                var history = ChatTB.Text;

                using var client = new HttpClient();
                var response = await client.PostAsJsonAsync($"http://localhost:8080/api/chats?patientID={patient}&content={history}", new { });
                var stringError = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                }
                else
                {
                    MessageBox.Show(stringError);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Connect to the hub
        private async void ConnectToHub()
        {
            // Pass the user's token as a parameter
            connection = new HubConnectionBuilder()
                .WithUrl("http://localhost:8080/myhub", options =>
                {
                    options.AccessTokenProvider = () => Task.FromResult(CurrentUser.MyUser.token);
                })
                .Build();

            // Subscribe to updates
            connection.On<string, string>("ReceiveMessage", (user, message) =>
            {
                // If a message is received, use Invoke to log it from another thread to the UI
                this.Invoke((Action)(async () =>
                {
                    // Additionally, get the sender's name by their ID
                    var name = await GetName(user);
                    var newMessage = $"{DateTime.Now.ToString("MM.dd.yyyy HH:mm:ss")} {name}: {message}";
                    ChatTB.Text += newMessage + Environment.NewLine;
                }));
            });

            try
            {
                await connection.StartAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Connection failed: {ex.Message}");
            }
        }

        // Method for getting the username by ID
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
    }
}
