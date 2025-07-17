using Prescription_Management_API.Models;

namespace Prescription_Management_API.Interface
{
    public interface IPatientRepository
    {
        IEnumerable<Patient> GetAll();
        Patient? GetById(int id);
        bool Exists(int id);
    }
}
