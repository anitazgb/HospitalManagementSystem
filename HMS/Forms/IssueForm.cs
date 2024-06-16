using HMS.Models;
using Microsoft.AspNetCore.SignalR.Client;
using System.Net.Http.Json;

namespace HMS.Forms
{
    public partial class IssueForm : Form
    {
        private HubConnection _hubConnection;
        public IssueForm()
        {
            InitializeComponent();
            // When the form loads, load the data and connect to the hub
            Load += async (s, e) =>
            {
                await LoadInventory();
                await LoadPatients();
                await ConnectToHub();
            };
            // When the issue button is clicked, pass the values to the API and add the issuance
            IssueBtn.Click += async (s, e) =>
            {
                try
                {
                    var doctor = CurrentUser.MyUser.ID.ToString();
                    var patient = PatientCB.SelectedValue.ToString();
                    var item = int.Parse(ItemCB.SelectedValue.ToString());
                    var quantity = int.Parse(QuantityTB.Text);
                    using var client = new HttpClient();
                    var response = await client.PostAsJsonAsync($"http://localhost:8080/api/issue?patientID={patient}&doctorID={doctor}&itemID={item}&quantity={quantity}", new { });
                    var stringError = await response.Content.ReadAsStringAsync();
                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Success");
                        // If connected to the hub, trigger the UpdateInventory method
                        if (_hubConnection.State == HubConnectionState.Connected)
                        {
                            await _hubConnection.InvokeAsync("UpdateInventory");
                        }
                        Close();
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
            };
        }
        // Load medical inventory data
        private async Task LoadInventory()
        {
            using var client = new HttpClient();
            var inventory = await client.GetFromJsonAsync<List<InventoryItem>>("http://localhost:8080/inventory");
            ItemCB.DataSource = inventory;
            ItemCB.DisplayMember = "Name";
            ItemCB.ValueMember = "ID";
        }
        // Load patients
        private async Task LoadPatients()
        {
            using var client = new HttpClient();
            var inventory = await client.GetFromJsonAsync<List<UserCollection>>("http://localhost:8080/api/users/GetPatients?role=patient");
            PatientCB.DataSource = inventory;
            PatientCB.DisplayMember = "Username";
            PatientCB.ValueMember = "ID";
        }
        // Method for connecting to the hub, without tracking anything additional
        private async Task ConnectToHub()
        {
            // Pass the token
            _hubConnection = new HubConnectionBuilder()
                .WithUrl("http://localhost:8080/inventoryHub", options =>
                {
                    options.AccessTokenProvider = () => Task.FromResult(CurrentUser.MyUser.token);
                })
            .Build();

            try
            {
                await _hubConnection.StartAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Connection failed: {ex.Message}");
            }
        }
    }
}
