namespace HMS.Forms
{
    public partial class AdminForm : Form
    {
        public AdminForm()
        {
            InitializeComponent();
            // Handle button clicks to open the corresponding forms
            SchedulingBtn.Click += (s, e) => new AppointmentSchedulingForm().ShowDialog();
            UserBtn.Click += (s, e) => new UserForm().ShowDialog();
            ChatBtn.Click += (s, e) => new AdminChatForm().ShowDialog();
            ReportBtn.Click += (s, e) => new ReportForm().ShowDialog();
            // When we close this window, close the entire application
            FormClosed += (s, e) => Application.Exit();
        }
    }
}
