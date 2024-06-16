using HMS.Models;
using Newtonsoft.Json;

namespace HMS.Forms
{
    public partial class PatientManagmentForm : Form
    {
        public PatientManagmentForm()
        {
            InitializeComponent();
            // When the form loads, load patient and illness data
            Load += async (s, e) =>
            {
                await GetPatients();
                await GetSickness();
            };
            // When the add disease button is clicked, open the form, and after it closes,
            // refresh the disease list by loading it again

            AddSicknessBtn.Click += async (s, e) =>
            {
                new AddSicknessForm().ShowDialog();
                await GetSickness();
            };
            // When saving the appointment
            SaveReception.Click += async (s, e) =>
            {
                // Store all values in a dictionary and send it to the API.
                var values = new Dictionary<string, string>
                    {
                        { "patientID", PatientsCB.SelectedValue.ToString() },
                        { "doctorID", CurrentUser.MyUser.ID.ToString() },
                        { "sicknessID", SicknessCB.SelectedValue.ToString() },
                        { "report", ReportTB.Text }
                    };
                var content = new FormUrlEncodedContent(values);

                using var client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:8080/");

                var response = await client.PostAsync("api/reception", content);
                var responseString = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                    MessageBox.Show("Reseption added successfully.");
                else
                {
                    MessageBox.Show("Error adding reseption.");
                    return;
                }
                Close();
            };
        }
        // Method to retrieve all patients
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
        // Method to retrieve all diseases
        private async Task GetSickness()
        {
            using var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:8080/");
            var response = await client.GetAsync($"api/sickness/GetSickness");
            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                var users = JsonConvert.DeserializeObject<List<SicknessEntity>>(responseString);
                SicknessCB.DataSource = users;
                SicknessCB.ValueMember = "ID";
                SicknessCB.DisplayMember = "Title";
            }
            else
            {
                MessageBox.Show("Error retrieving Sickness.");
            }
        }
    }
}
