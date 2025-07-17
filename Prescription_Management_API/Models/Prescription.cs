namespace Prescription_Management_API.Models
{
    public class Prescription
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public string DrugName { get; set; } = string.Empty;
        public string Dosage { get; set; } = string.Empty;
        public string DatePrescribed { get; set; } = string.Empty;
    }
}
