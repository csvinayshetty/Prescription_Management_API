using Microsoft.AspNetCore.Mvc;
using Prescription_Management_API.Models;
using System.Text.Json;

namespace Prescription_Management_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly List<Patient> _patients;

        public PatientsController()
        {
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                WriteIndented = true
            };
            // Fix: Use System.IO.File instead of ambiguous File
            var json = System.IO.File.ReadAllText("Data/Patients.json");
            _patients = JsonSerializer.Deserialize<List<Patient>>(json, options) ?? new List<Patient>();
        }

        [HttpGet]
        public ActionResult<IEnumerable<Patient>> Get()
        {
            return Ok(_patients);
        }

        [HttpGet("{id}")]
        public ActionResult<Patient> Get(int id)
        {
            var patient = _patients.FirstOrDefault(p => p.Id == id);
            if (patient == null)
            {
                return NotFound();
            }
            return Ok(patient);
        }
    }
}
