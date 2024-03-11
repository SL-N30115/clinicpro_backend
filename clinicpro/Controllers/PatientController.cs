using clinicpro.Entities;
using clinicpro.Services;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;

namespace clinicpro.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IPatientService _patientService;

        public PatientController(IPatientService patientService)
        {
            _patientService = patientService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Patient>>> GetAllPatients()
        {
            var patients = await _patientService.GetAllPatientsAsync();
            return Ok(patients);
        }

        [HttpGet("{patientID}")]
        public async Task<ActionResult<Patient>> GetPatientByID(String patientID)
        {
            var patient = await _patientService.GetPatientByIdAsync(patientID);
            return Ok(patient);
        }

        [HttpPost]
        public async Task<IActionResult> PostNewPatient([FromBody] Patient patient)
        {
            var result = await _patientService.PostPatientAsync(patient);

            if (result)
            {
                return StatusCode(201, "successfully created");
            }

            return StatusCode(500, "Failed to create new patient");
        }


        [HttpPatch]
        public async Task<IActionResult> PatchExistingPatient(string id, [FromBody] Patient patient)
        {
            var result = await _patientService.PatchPatientAsync(id, patient);

            if (result)
            {
                return Ok();
            }

            return StatusCode(500, "Failed to patch new patient");
        }


        [HttpDelete]
        public async Task<IActionResult> DeletePatientById(string id)
        {
            var result = await _patientService.DeletePatientByIdAsync(id);

            if (result)
            {
                return NoContent();
            }

            return StatusCode(500, "Failed to delete patient");
        }
    }
}