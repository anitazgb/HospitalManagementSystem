namespace HMS.Models
{
    public class IssueEntity
    {
        public int ID { get; set; }
        public Guid PatientID { get; set; }
        public Guid DoctorID { get; set; }
        public int InventoryItemID { get; set; }
        public InventoryItem InventoryItem { get; set; }
        public int Quantity { get; set; }
        public DateTime DateTime { get; set; }
    }
}
