using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Prescription_Management_API.Interface;
using Prescription_Management_API.Models;

namespace Prescription_Management_API.Controllers
{
    /// <summary>
    /// Provides operations for managing prescriptions.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class PrescriptionsController : ControllerBase
    {
        private readonly IPrescriptionService _prescriptionService;

        public PrescriptionsController(IPrescriptionService prescriptionService)
        {
            _prescriptionService = prescriptionService;
        }

        /// <summary>
        /// Gets all prescriptions
        /// </summary>
        /// <returns>List of prescriptions</returns>
        [HttpGet]
        public ActionResult<IEnumerable<Prescription>> Get()
        {
            return Ok(_prescriptionService.GetAllPrescriptions());
        }

        /// <summary>
        /// Gets a specific prescription by ID
        /// </summary>
        /// <param name="id">Prescription ID</param>
        /// <returns>The requested prescription</returns>
        /// <response code="200">Returns the prescription</response>
        /// <response code="404">If prescription not found</response>
        [HttpGet("{id}")]
        public ActionResult<Prescription> Get(int id)
        {
            var prescription = _prescriptionService.GetPrescriptionById(id);
            if (prescription == null)
            {
                return NotFound();
            }
            return Ok(prescription);
        }

        /// <summary>
        /// Creates a new prescription
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /api/Prescriptions
        ///     {
        ///        "patientId": 1,
        ///        "drugName": "Amoxicillin",
        ///        "dosage": "500mg"
        ///     }
        ///
        /// </remarks>
        /// <param name="dto">Prescription data</param>
        /// <returns>The newly created prescription</returns>
        /// <response code="201">Returns the newly created prescription</response>
        /// <response code="400">If the patient doesn't exist or data is invalid</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Prescription> Post([FromBody] Prescription prescription)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            //var createdPrescription = _prescriptionService.CreatePrescription(prescription);
            //return CreatedAtAction(nameof(Get), new { id = createdPrescription.Id }, createdPrescription);

            try
            {
                var createdPrescription = _prescriptionService.CreatePrescription(prescription);
                return CreatedAtAction(nameof(Get), new { id = createdPrescription.Id }, createdPrescription);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("patient/{patientId}")]
        public ActionResult<IEnumerable<Prescription>> GetByPatient(int patientId)
        {
            return Ok(_prescriptionService.GetPrescriptionsByPatient(patientId));
        }
    }
}
