using HMS.Models;
using System.Net.Http.Json;

namespace HMS.Forms
{
    public partial class UserForm : Form
    {
        public UserForm()
        {
            InitializeComponent();
            // When the form loads, load the data
            Load += async (s, e) =>
            {
                await LoadData();
            };
            // When the values in DataGridView cells change, call the API method to update the data
            DGV.CellValueChanged += async (s, e) =>
            {
                try
                {
                    var row = DGV.SelectedCells[0].RowIndex;
                    var id = DGV[0, row].Value.ToString();
                    var username = DGV[1, row].Value.ToString();
                    var password = DGV[2, row].Value.ToString();
                    var role = DGV[3, row].Value.ToString();
                    using var client = new HttpClient();
                    client.BaseAddress = new Uri("http://localhost:8080/");

                    var response = await client.PostAsJsonAsync($"api/users/Update?id={id}&name={username}&password={password}&role={role}", new { });
                    var responseString = await response.Content.ReadAsStringAsync();
                    if (response.IsSuccessStatusCode)
                        MessageBox.Show("User updated successfully.");
                    else
                    {
                        MessageBox.Show("Error updating user.");
                        return;
                    }
                    await LoadData();
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            };
            // When the add button is clicked, add a new user via the API
            AddBtn.Click += async (s, e) =>
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

                using var client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:8080/");

                var response = await client.PostAsJsonAsync($"api/users/AddUserWithRole?username={UsernameTB.Text}&password={PasswordTB.Text}&role={RoleCB.Text}", new { });
                var responseString = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                    MessageBox.Show("User added successfully.");
                else
                {
                    MessageBox.Show("Error adding user.");
                    return;
                }
                UsernameTB.Text = PasswordTB.Text = string.Empty;
                await LoadData();
            };
            // Delete a user from the database via the API
            DeleteBtn.Click += async (s, e) =>
            {
                try
                {
                    var row = DGV.SelectedCells[0].RowIndex;
                    var id = DGV[0, row].Value.ToString();
                    using var client = new HttpClient();
                    client.BaseAddress = new Uri("http://localhost:8080/");

                    var response = await client.PostAsJsonAsync($"api/users/Delete?id={id}", new { });
                    var responseString = await response.Content.ReadAsStringAsync();
                    if (response.IsSuccessStatusCode)
                        MessageBox.Show("User deleted successfully.");
                    else
                    {
                        MessageBox.Show("Error deleting user.");
                        return;
                    }
                    await LoadData();
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            };
        }
        // Method for loading data
        private async Task LoadData()
        {
            using var client = new HttpClient();
            var users = await client.GetFromJsonAsync<List<UserCollection>>("http://localhost:8080/api/users/GetAll");
            DGV.DataSource = users;
        }
    }
}
