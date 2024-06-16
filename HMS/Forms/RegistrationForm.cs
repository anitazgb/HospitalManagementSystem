namespace HMS.Forms
{
    public partial class RegistrationForm : Form
    {
        public RegistrationForm()
        {
            InitializeComponent();
            // Handling the registration button click, validate all fields are filled, and then add the user to the database via API
            RegisterBtn.Click += async (s, e) =>
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

                // Create a dictionary with the values to be sent to the API
                var values = new Dictionary<string, string>
                    {
                        { "username", UsernameTB.Text },
                        { "password", PasswordTB.Text }
                    };
                var content = new FormUrlEncodedContent(values);

                // Create a new HttpClient and send the data to the API
                using var client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:8080/");

                // If the response is OK, display a success message, otherwise display an error message
                var response = await client.PostAsync("api/users", content);
                var responseString = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                    MessageBox.Show("User added successfully.");
                else
                {
                    MessageBox.Show("Error adding user.");
                    return;
                }
                Close();
            };
        }
    }
}
