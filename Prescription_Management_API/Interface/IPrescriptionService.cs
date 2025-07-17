using Prescription_Management_API.Models;

namespace Prescription_Management_API.Interface
{
    public interface IPrescriptionService
    {
        IEnumerable<Prescription> GetAllPrescriptions();
        Prescription? GetPrescriptionById(int id);
        Prescription CreatePrescription(Prescription prescription);
        IEnumerable<Prescription> GetPrescriptionsByPatient(int patientId);
    }
}
