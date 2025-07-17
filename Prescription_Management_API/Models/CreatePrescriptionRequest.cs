using System.ComponentModel.DataAnnotations;

namespace Prescription_Management_API.Models
{
    public class CreatePrescriptionRequest
    {
        [Required]
        public int PatientId { get; set; }

        [Required, StringLength(100, ErrorMessage = "Doctor's name cannot exceed 100 characters.")]
        public string Medication { get; set; }

        [Required, StringLength(100, ErrorMessage = "Drug name cannot exceed 100 characters.")]
        public string dosage { get; set; }

    }
}
