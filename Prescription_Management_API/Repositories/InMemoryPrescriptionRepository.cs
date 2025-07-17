using Prescription_Management_API.Interface;
using Prescription_Management_API.Models;
using System.Text.Json;

namespace Prescription_Management_API.Repositories
{
    public class InMemoryPrescriptionRepository : IPrescriptionRepository
    {
        private readonly List<Prescription> _prescriptions;
        private readonly List<Patient> _patients;
        private int _nextId = 1;

        public InMemoryPrescriptionRepository()
        {
           var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                WriteIndented = true
            };

            var json = System.IO.File.ReadAllText("Data/Prescriptions.json");
            this._prescriptions = JsonSerializer.Deserialize<List<Prescription>>(json, options) ?? new List<Prescription>();

            // Load from JSON file
            json = File.ReadAllText("Data/Patients.json");
            _patients = JsonSerializer.Deserialize<List<Patient>>(json) ?? new List<Patient>();
        }

        private void saveToJson()
        {
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                WriteIndented = true
            };
            var json = JsonSerializer.Serialize(this._prescriptions, options);
            System.IO.File.WriteAllText("Data/Prescriptions.json", json);
        }

       
        public void Add(Prescription prescription)
        {
            prescription.Id = this._nextId++;
            this._prescriptions.Add(prescription);
            saveToJson();
        }

        public IEnumerable<Prescription> GetAll()
        {
            return this._prescriptions;
        }

        public Prescription? GetById(int id)
        {
            return this._prescriptions.FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Prescription> GetByPatientId(int patientId)
        {
            return this._prescriptions.Where(p => p.PatientId == patientId);
        }

        public bool Exists(int id) => _patients.Any(p => p.Id == id); // Implement the Exists method
    }
}
