namespace HMS.Forms
{
    public partial class PatientForm : Form
    {
        public PatientForm()
        {
            InitializeComponent();
            // Handling button clicks to open corresponding forms
            SchedulingBtn.Click += (s, e) => new AddAppointment(true).ShowDialog();
            ChatBtn.Click += (s, e) => new ChatForm().ShowDialog();
            HistoryBtn.Click += (s, e) => new PatientHistory().ShowDialog();
            ChatHistory.Click += (s, e) => new ChatHistory().ShowDialog();
            // When closing this form, close the entire program
            FormClosed += (s, e) => Application.Exit();
        }
    }
}
