using System.ComponentModel.DataAnnotations.Schema;

namespace HMS.Models
{
    public class AppointmentEntity
    {
        // Class for storing appointment data
        public int ID { get; set; }
        public Guid PatientID { get; set; }
        public Guid DoctorID { get; set; }
        [Column(TypeName = "Date")]
        public DateTime Date { get; set; }
    }
}
