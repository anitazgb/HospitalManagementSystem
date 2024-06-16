using System.Net.Http.Json;

namespace HMS.Forms
{
    public partial class AddInventoryItem : Form
    {
        public AddInventoryItem()
        {
            InitializeComponent();
            // When the add button is clicked, pass the values to the API and wait for a response
            AddBtn.Click += async (s, e) =>
            {
                try
                {
                    var name = textBox1.Text;
                    var quantity = int.Parse(textBox2.Text);
                    using var client = new HttpClient();
                    var response = await client.PostAsJsonAsync($"http://localhost:8080/inventory?name={name}&quantity={quantity}", new { });
                    // If everything is OK, the value is added and we close the form
                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Success");
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("Add item error");
                        return;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
               
            };
        }
    }
}
