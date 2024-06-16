using HMS.Models;
using Microsoft.AspNetCore.SignalR.Client;
using Newtonsoft.Json;

namespace HMS.Forms
{
    public partial class AppointmentSchedulingForm : Form
    {
        private HubConnection _hubConnection;
        public AppointmentSchedulingForm()
        {
            InitializeComponent();
            // When the form loads, load the data and connect to the hub
            Load += async (s, e) =>
            {
                await LoadData();
                await ConnectToHub();
            };
            // When the add record button is clicked
            AddBtn.Click += async (s, e) =>
            {
                // Open the add form with admin role
                new AddAppointment(false).ShowDialog();

                // After that, send updates to everyone
                await UpdateForAll();

                // Reload the data
                await LoadData();               
            };

            // When deleting, check the selected item in the DGV and get its ID, then pass this ID to the API
            DeleteBtn.Click += async (s, e) =>
            {
                var row = DGV.SelectedCells[0].RowIndex;
                var id = (int)DGV[0, row].Value;

                var values = new Dictionary<string, string>
                    {
                        { "appointmentID", id.ToString() }
                    };
                var content = new FormUrlEncodedContent(values);

                using var client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:8080/");

                var response = await client.PostAsync("api/appointments/Delete", content);
                var responseString = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                    MessageBox.Show("Appointment deleted successfully.");
                else
                {
                    MessageBox.Show("Error deleting appointment.");
                    return;
                }
                // After that, send updates to everyone
                await UpdateForAll();
                // Reload the data
                await LoadData();
            };
        }
        // Method for loading data from the API
        private async Task LoadData()
        {
            using var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:8080/");
            var response = await client.GetAsync($"api/appointments/GetAppointments");
            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                var appointments = JsonConvert.DeserializeObject<List<AppointmentEntity>>(responseString);

                // Since users are in a different database, load them separately and then link them using LINQ
                var users = await GetUsers();
                var result = from appointment in appointments
                             join doctor in users on appointment.DoctorID equals doctor.ID
                             join patient in users on appointment.PatientID equals patient.ID
                             select new AppointmentWithNames
                             {
                                 AppointmentID = appointment.ID,
                                 Doctor = doctor.Username,
                                 Patient = patient.Username,
                                 Date = appointment.Date
                             };
                DGV.DataSource = result.ToList();
                DGV.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                DGV.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                DGV.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                DGV.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
            else
            {
                MessageBox.Show("Error retrieving users by role.");
            }
        }

        // Get users from the API
        private async Task<List<UserCollection>> GetUsers()
        {
            using var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:8080/");
            var response = await client.GetAsync($"api/users/GetAll");
            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                var users = JsonConvert.DeserializeObject<List<UserCollection>>(responseString);
                return users;
            }
            else
            {
                MessageBox.Show("Error retrieving patients.");
                return null;
            }
        }
        // Connect to the hub
        private async Task ConnectToHub()
        {
            // Pass the token as a parameter
            _hubConnection = new HubConnectionBuilder()
                .WithUrl("http://localhost:8080/appointmnetHub", options =>
                {
                    options.AccessTokenProvider = () => Task.FromResult(CurrentUser.MyUser.token);
                })
                .Build();

            // Subscribe to updates
            _hubConnection.On("UpdateAppointments", () =>
            {
                // If an update is triggered, use Invoke to load data and update the UI from another thread
                this.Invoke((Action)(async () =>
                {
                    await LoadData();
                }));
            });

            try
            {
                await _hubConnection.StartAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Connection failed: {ex.Message}");
            }
        }

        // Method to be called in the hub to trigger the UpdateAppointments method
        private async Task UpdateForAll()
        {
            if (_hubConnection.State == HubConnectionState.Connected)
            {
                await _hubConnection.InvokeAsync("UpdateAppointments");
            }
        }
    }

    // Class to represent records with doctor and patient names instead of IDs
    public class AppointmentWithNames
    {
        public int AppointmentID { get; set; }
        public string Doctor { get; set; }
        public string Patient { get; set; }
        public DateTime Date { get; set; }
    }
}
