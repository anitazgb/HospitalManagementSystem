namespace HMS.Forms
{
    public partial class AddSicknessForm : Form
    {
        public AddSicknessForm()
        {
            InitializeComponent();
            // When the add button is clicked, connect to the API and add the illness
            AddBtn.Click += async (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(TittleTB.Text))
                {
                    MessageBox.Show("The Title field is not filled in", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                var values = new Dictionary<string, string>
                    {
                        { "title", TittleTB.Text }
                    };
                var content = new FormUrlEncodedContent(values);

                using var client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:8080/");

                var response = await client.PostAsync("api/sickness", content);
                var responseString = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                    MessageBox.Show("Sickness added successfully.");
                else
                {
                    MessageBox.Show("Error adding sickness.");
                    return;
                }
                Close();
            };
            
        }
    }
}
