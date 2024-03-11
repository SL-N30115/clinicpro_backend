using clinicpro.Entities;
using Microsoft.AspNetCore.Mvc;

namespace clinicpro.Services;

public interface IPatientService
{
     Task<ActionResult<List<Patient>>> GetAllPatientsAsync();
     Task<ActionResult<Patient>> GetPatientByIdAsync(string id);
     Task<bool> PostPatientAsync(Patient patient);
     Task<bool> PatchPatientAsync(string id, Patient patient);
     Task<bool> DeletePatientByIdAsync(string id);
}