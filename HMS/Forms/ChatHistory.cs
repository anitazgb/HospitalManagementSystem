using HMS.Models;
using System.Data;
using System.Net.Http.Json;

namespace HMS.Forms
{
    public partial class ChatHistory : Form
    {
        public ChatHistory()
        {
            InitializeComponent();
            // When the form loads, load the entire chat history
            Load += async (s, e) =>
            {
                await LoadInventory();
            };
        }

        // Method for loading this user's chat history
        private async Task LoadInventory()
        {
            using var client = new HttpClient();
            var history = await client.GetFromJsonAsync<List<ChatEntity>>("http://localhost:8080/api/chats/GetChats");
            var patientHistory = history?.Where(x => x.PatientID == CurrentUser.MyUser.ID).ToList();
            DGV.DataSource = patientHistory;
            DGV.Columns[1].Visible = false;
            DGV.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }
    }
}
