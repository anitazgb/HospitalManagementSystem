using HMS.Models;
using System.Net.Http.Json;

namespace HMS.Forms
{
    public partial class ReportForm : Form
    {
        public ReportForm()
        {
            InitializeComponent();
            // When the create report button is clicked
            CreateBtn.Click += async (s, e) =>
            {

                using var client = new HttpClient();
                // Depending on the selected report type:
                // - Send the API a time range from and to
                // - Write the returned response to a text field
                if (TypeCB.SelectedIndex == 0)
                {
                    var report = await client.GetFromJsonAsync<List<ReportString>>($"http://localhost:8080/api/reports/Reception?start={StartDTP.Value.ToString("MM-dd-yyyy")}&end={EndDTP.Value.ToString("MM-dd-yyyy")}");
                    var users = await client.GetFromJsonAsync<List<UserCollection>>("http://localhost:8080/api/users/GetAll");
                    textBox2.Text = string.Empty;
                    // Since users are in a different database and cannot be linked, simply replace ID with username for better display
                    foreach (var user in users)
                    {
                        
                        var item = report.Where(x => x.Row.Contains(user.ID.ToString().ToUpper())).FirstOrDefault();
                        if (item != null)
                            item.Row = item.Row.Replace(user.ID.ToString().ToUpper(), user.Username);
                    }
                    // Display the result in a text field
                    foreach (var item in report)
                    {
                        textBox2.Text += item.Row + Environment.NewLine;
                    }
                }
                else if (TypeCB.SelectedIndex == 1)
                {
                    var report = await client.GetFromJsonAsync<List<ReportString>>($"http://localhost:8080/api/reports/Sickness?start={StartDTP.Value.ToString("MM-dd-yyyy")}&end={EndDTP.Value.ToString("MM-dd-yyyy")}");
                    textBox2.Text = string.Empty;
                    // Display the result in a text field
                    foreach (var item in report)
                    {
                        textBox2.Text += item.Row + Environment.NewLine;
                    }
                }
                else if (TypeCB.SelectedIndex == 2)
                {
                    var report = await client.GetFromJsonAsync<List<ReportString>>($"http://localhost:8080/api/reports/Issue?start={StartDTP.Value.ToString("MM-dd-yyyy")} &end= {EndDTP.Value.ToString("MM-dd-yyyy")}");
                    textBox2.Text = string.Empty;
                    // Display the result in a text field
                    foreach (var item in report)
                    {
                        textBox2.Text += item.Row + Environment.NewLine;
                    }
                }
                else
                {
                    MessageBox.Show("Shoose type of report");
                }
            };
        }
    }
}
