using clinicpro.Entities;
using Microsoft.AspNetCore.Mvc;

namespace clinicpro.Repository;

public interface IPatientRepository
{
    Task<List<Patient>> GetAllPatientsAsync();
    Task<Patient> GetPatientByIdAsync(string id);
    Task<bool> PostPatientAsync(Patient patient);
    Task<bool> PatchPatientAsync(string id, Patient patient);
    Task<bool> DeletePatientByIdAsync(string id);
}