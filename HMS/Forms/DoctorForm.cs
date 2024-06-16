namespace HMS.Forms
{
    public partial class DoctorForm : Form
    {
        public DoctorForm()
        {
            InitializeComponent();
            // Handle button clicks and open the corresponding forms
            PatientBtn.Click += (s, e) => new PatientManagmentForm().ShowDialog();
            MedicalBtn.Click += (s, e) => new IssueForm().ShowDialog();
            // When closing this form, completely shut down the application
            FormClosed += (s, e) => Application.Exit();
        }
    }
}
