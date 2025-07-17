using Prescription_Management_API.Interface;
using Prescription_Management_API.Models;

namespace Prescription_Management_API.Services
{
    public class PrescriptionService : IPrescriptionService
    {
        private readonly IPrescriptionRepository _prescriptionRepository;
        private readonly IPatientRepository _patientRepository;

        public PrescriptionService(IPrescriptionRepository prescriptionRepository, IPatientRepository patientRepository)
        {
            this._prescriptionRepository = prescriptionRepository;
            this._patientRepository = patientRepository;
        }

        public IEnumerable<Prescription> GetAllPrescriptions()
        {
            return this._prescriptionRepository.GetAll();
        }

        public Prescription? GetPrescriptionById(int id)
        {
            return this._prescriptionRepository.GetById(id);
        }

        public Prescription CreatePrescription(Prescription prescription)
        {
            // Validate patient exists
            if (!this._patientRepository.Exists(prescription.PatientId))
            {
                throw new ArgumentException($"Patient with ID {prescription.PatientId} not found");
            }

            this._prescriptionRepository.Add(prescription);
            return prescription;
        }

        public IEnumerable<Prescription> GetPrescriptionsByPatient(int patientId)
        {
            return this._prescriptionRepository.GetByPatientId(patientId);
        }
    }
}
