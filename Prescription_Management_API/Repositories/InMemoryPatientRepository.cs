using Prescription_Management_API.Interface;
using Prescription_Management_API.Models;
using System.Text.Json;

namespace Prescription_Management_API.Repositories
{
    public class InMemoryPatientRepository : IPatientRepository
    {
        private readonly List<Patient> _patients;

        public InMemoryPatientRepository()
        {
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                WriteIndented = true
            };

            // Load from JSON file
            var json = File.ReadAllText("Data/Patients.json");
            _patients = JsonSerializer.Deserialize<List<Patient>>(json, options) ?? new List<Patient>();
        }

        public IEnumerable<Patient> GetAll() => _patients;

        public Patient? GetById(int id) => _patients.FirstOrDefault(p => p.Id == id);

        public bool Exists(int id) => _patients.Any(p => p.Id == id);
    }
}
