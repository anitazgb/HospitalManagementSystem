using HMS.Models;
using Microsoft.AspNetCore.SignalR.Client;
using Newtonsoft.Json;

namespace HMS.Forms
{
    public partial class PatientHistory : Form
    {
        private HubConnection _hubConnection;
        public PatientHistory()
        {
            InitializeComponent();
            // When the form loads, we load the data and connect to the hub.
            Load += async (s, e) =>
            {
                await LoadData();
                await ConnectToHub();
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

                // Since users are in a different database, we load them separately and then link them using LINQ
                var users = await GetUsers();
                var result = from appointment in appointments
                             join doctor in users on appointment.DoctorID equals doctor.ID
                             select new AppointmentWithNames
                             {
                                 AppointmentID = appointment.ID,
                                 Doctor = doctor.Username,
                                 Date = appointment.Date
                             };
                DGV.DataSource = result.ToList();
                DGV.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                DGV.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                DGV.Columns[2].Visible = false;
                DGV.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            else
            {
                MessageBox.Show("Error retrieving users by role.");
            }
        }

        // Method for retrieving users from the API
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
                MessageBox.Show("Error retrieving users.");
                return null;
            }
        }

        // Method for connecting to the hub
        private async Task ConnectToHub()
        {
            // The token is passed as a parameter
            _hubConnection = new HubConnectionBuilder()
                .WithUrl("http://localhost:8080/appointmnetHub", options =>
                {
                    options.AccessTokenProvider = () => Task.FromResult(CurrentUser.MyUser.token);
                })
            .Build();
            // Subscribe to updates
            _hubConnection.On("UpdateAppointments", () =>
            {
                // When an update is received from the hub, reload the data
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
    }
}
