using HMS.Models;
using Microsoft.AspNetCore.SignalR.Client;
using System.Net.Http.Json;

namespace HMS.Forms
{
    public partial class MedicalInventoryManagementForm : Form
    {
        private HubConnection _hubConnection;
        private List<InventoryItem> _inventory;
        public MedicalInventoryManagementForm()
        {
            InitializeComponent();
            // Since this is the only form for the nurse, close the entire application when it is closed
            FormClosed += (s, e) => Application.Exit();
            // When the form loads, retrieve data and connect to the hub
            Load += async (s, e) => 
            {
                await LoadInventory();
                await ConnectToHub();
            };
            // When the add button is clicked
            AddBtn.Click += async (s, e) => 
            {
                // Open the form for adding
                new AddInventoryItem().ShowDialog();
                // Send update to everyone
                await UpdateForAll();
                // Reload data
                await LoadInventory();
            };
            // When the delete button is clicked
            DeleteBtn.Click += async (s, e) =>
            {
                // Get the ID based on the selected row
                var row = DGV.SelectedCells[0].RowIndex;
                var id = (int)DGV[0, row].Value;
                // Pass this ID to the API and delete the corresponding item
                using var client = new HttpClient();
                var response = await client.PostAsJsonAsync($"http://localhost:8080/inventory/Delete?id={id}", new { });

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Success");
                    // After deletion, trigger an update for everyone
                    await UpdateForAll();
                }
                else
                {
                    MessageBox.Show("Add error");
                }
            };
            // Drawing event: if LowStock, make the cell red
            DGV.CellPainting += (s, e) =>
            {
                try
                {
                    if(e.ColumnIndex==3)
                    {
                        if ((bool)e.Value)
                            e.CellStyle.BackColor = Color.Tomato;
                    }
                }
                catch (Exception)
                {
                }
            };
            // When data in the DataGridView is updated, pass the values to the API and update them in the database
            DGV.CellValueChanged +=async  (s, e) =>
            {
                try
                {
                    if(e.ColumnIndex==2)
                    {
                        var quantity = (int)DGV[2,e.RowIndex].Value;
                        var id = (int)DGV[0, e.RowIndex].Value;

                        using var client = new HttpClient();
                        var response = await client.PostAsJsonAsync($"http://localhost:8080/inventory/Update?id={id}&quantity={quantity}", new { });

                        if (response.IsSuccessStatusCode)
                        {
                            MessageBox.Show("Success");
                            // If update is successful, trigger an update on the hub
                            await UpdateForAll();
                            // Reload the data
                            await LoadInventory();
                        }
                        else
                        {
                            MessageBox.Show("Update error");
                        }
                    }
                }
                catch (Exception)
                {
                }
            };
        }
        // Method for loading data from the API
        private async Task LoadInventory()
        {
            using var client = new HttpClient();
            _inventory = await client.GetFromJsonAsync<List<InventoryItem>>("http://localhost:8080/inventory");
            DGV.DataSource = _inventory;
            DGV.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }
        // Method that calls the UpdateInventory method on the hub if connected to the hub
        private async Task UpdateForAll()
        {
            if (_hubConnection.State == HubConnectionState.Connected)
            {
                await _hubConnection.InvokeAsync("UpdateInventory");
            }
        }
        // Method for connecting to the hub
        private async Task ConnectToHub()
        {
            // Pass the user's token as a parameter
            _hubConnection = new HubConnectionBuilder()
                .WithUrl("http://localhost:8080/inventoryHub", options =>
                {
                    options.AccessTokenProvider = () => Task.FromResult(CurrentUser.MyUser.token);
                })
                .Build();
            // Subscribe for updates
            _hubConnection.On("UpdateInventory", () =>
            {
                // When updating, reload the data using Invoke
                this.Invoke((Action)(async () =>
                {
                    await LoadInventory();
                }));
            });
            // Start connecting to the hub
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
