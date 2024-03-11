using clinicpro.Entities;
using clinicpro.Repository;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace clinicpro.Services;

public class PatientService : IPatientService
{
    private readonly IPatientRepository _patientRepository;
    private readonly IValidator<Patient> _validator;


    public PatientService(IPatientRepository patientRepository, IValidator<Patient> validator)
    {
        _patientRepository = patientRepository;
        _validator = validator;
    }

    public async Task<ActionResult<List<Patient>>> GetAllPatientsAsync()
    {
        try
        {
            return await _patientRepository.GetAllPatientsAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw new Exception(e.Message);
        }
    }

    public async Task<ActionResult<Patient>> GetPatientByIdAsync(string id)
    {
        try
        {
            return await _patientRepository.GetPatientByIdAsync(id);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw new Exception(e.Message);
        }
    }

    public async Task<bool> PostPatientAsync(Patient patient)
    {
        try
        {
            var validateResult = await _validator.ValidateAsync(patient);
            if (!validateResult.IsValid)
            {
                throw new Exception(validateResult.Errors.ToString());
            }

            return await _patientRepository.PostPatientAsync(patient);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw new Exception(e.Message);
        }
    }

    public async Task<bool> PatchPatientAsync(string id, Patient patient)
    {
        try
        {
            var validateResult = await _validator.ValidateAsync(patient);
            if (!validateResult.IsValid)
            {
                throw new ValidationException(validateResult.Errors);
            }

            return await _patientRepository.PatchPatientAsync(id, patient);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw new Exception(e.Message);
        }
    }

    public async Task<bool> DeletePatientByIdAsync(string id)
    {
        try
        {
            return await _patientRepository.DeletePatientByIdAsync(id);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw new Exception(e.Message);
        }
    }
}