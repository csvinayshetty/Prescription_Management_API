using Prescription_Management_API.Models;

namespace Prescription_Management_API.Interface
{
    public interface IPrescriptionRepository
    {
        IEnumerable<Prescription> GetAll();
        Prescription? GetById(int id);
        void Add(Prescription prescription);
        IEnumerable<Prescription> GetByPatientId(int patientId);
        bool Exists(int patientId);
    }
}
