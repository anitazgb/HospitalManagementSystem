namespace HMS.Models
{
    public class ChatEntity
    {
        // Class for storing chat messages
        public int ID { get; set; }
        public Guid PatientID { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
    }
}
