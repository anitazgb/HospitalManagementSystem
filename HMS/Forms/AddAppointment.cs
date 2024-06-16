using HMS.Models;
using Microsoft.AspNetCore.SignalR.Client;
using Newtonsoft.Json;

namespace HMS.Forms
{
    public partial class AddAppointment : Form
    {
        private HubConnection _hubConnection;
        // 2 versions of the form, for client and admin
        public AddAppointment(bool isClient)
        {
            InitializeComponent();
            // If client, then the patient is not selected; the client is the patient
            if (isClient)
            {
                label3.Visible = PatientsCB.Visible = false;
            }
            // When the form loads, populate the dropdown lists and connect to the hub
            Load += async (s, e) => 
            {
                await GetPatients();
                await GetDoctors();
                await ConnectToHub();
            };
            // When the add button is clicked
            AddBtn.Click += async (s, e) =>
            {
                // Generate the values
                var values = new Dictionary<string, string>
                    {
                        { "patientID", PatientsCB.SelectedValue.ToString() },
                        { "doctorID", (isClient ? CurrentUser.MyUser.ID.ToString() : DoctorCB.SelectedValue.ToString()) },
                        { "datetime", DTP.Value.Date.ToString() }
                    };
                var content = new FormUrlEncodedContent(values);

                using var client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:8080/");
                // Passing the generated values to the API
                var response = await client.PostAsync("api/appointments", content);
                var responseString = await response.Content.ReadAsStringAsync();
                // If everything was added successfully
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Appointment added successfully.");
                    // If we are connected to the hub, we call the UpdateAppointments method, which will be triggered
                    // for all connected clients.
                    if (_hubConnection.State == HubConnectionState.Connected)
                    {
                        await _hubConnection.InvokeAsync("UpdateAppointments");
                    }
                } 
                else
                {
                    MessageBox.Show("Error adding Appointment.");
                    return;
                }
                Close();
            };
        }
        // Method for loading data from the API into the dropdown list
        private async Task GetPatients()
        {
            using var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:8080/");
            var response = await client.GetAsync($"api/users/GetPatients?role=patient");
            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                var users = JsonConvert.DeserializeObject<List<UserCollection>>(responseString);
                PatientsCB.DataSource = users;
                PatientsCB.ValueMember = "ID";
                PatientsCB.DisplayMember = "Username";
            }
            else
            {
                MessageBox.Show("Error retrieving patients.");
            }
        }
        // Method for loading data from the API into the dropdown list
        private async Task GetDoctors()
        {
            using var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:8080/");
            var response = await client.GetAsync($"api/users/GetPatients?role=doctor");
            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                var users = JsonConvert.DeserializeObject<List<UserCollection>>(responseString);
                DoctorCB.DataSource = users;
                DoctorCB.ValueMember = "ID";
                DoctorCB.DisplayMember = "Username";
            }
            else
            {
                MessageBox.Show("Error retrieving patients.");
            }
        }
        // Method for connecting to the hub, where we only establish the connection
        // The user's token CurrentUser.MyUser.token is passed as a parameter
        private async Task ConnectToHub()
        {
            _hubConnection = new HubConnectionBuilder()
                .WithUrl("http://localhost:8080/appointmnetHub", options =>
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
