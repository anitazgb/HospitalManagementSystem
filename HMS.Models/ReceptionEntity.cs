namespace HMS.Models
{
    public class ReceptionEntity
    {
        public int ID { get; set; }
        public Guid PatientID { get; set; }
        public Guid DoctorID { get; set; }
        public int SicknessID { get; set; }
        public SicknessEntity? Sickness { get; set; }
        public string Report { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
    }
}
