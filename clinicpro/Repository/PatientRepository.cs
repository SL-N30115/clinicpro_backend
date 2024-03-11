using clinicpro.Entities;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;

namespace clinicpro.Repository;

public class PatientRepository : IPatientRepository
{
    private readonly IMongoClient _client;
    private readonly IMongoCollection<Patient> _patientCollection;
    private readonly IMongoDatabase _database;

    public PatientRepository(IMongoClient client)
    {
        _client = client;
        _database = client.GetDatabase("ClinicDatabase");
        _patientCollection = _database.GetCollection<Patient>("patients");
    }

    public async Task<List<Patient>> GetAllPatientsAsync()
    {
        var filter = new BsonDocument();
        var patients = await _patientCollection.Find(filter).ToListAsync();
        patients.ForEach(patients => { patients.patientID = patients._id.ToString(); });

        return patients;
    }

    public async Task<Patient> GetPatientByIdAsync(string id)
    {
        var filter = Builders<Patient>.Filter.Eq(r => r._id, ObjectId.Parse(id));
        return await _patientCollection.Find(filter).FirstOrDefaultAsync();
    }

    public async Task<bool> PostPatientAsync(Patient patient)
    {
        try
        {
            await _patientCollection.InsertOneAsync(patient);
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }
    }

    public async Task<bool> PatchPatientAsync(string id, Patient patient)
    {
        try
        {
            var filter = Builders<Patient>.Filter.Eq(r => r._id, ObjectId.Parse(id));
            await _patientCollection.ReplaceOneAsync(filter, patient);
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }
    }

    public async Task<bool> DeletePatientByIdAsync(string id)
    {
        try
        {
            var filter = Builders<Patient>.Filter.Eq(r => r._id, ObjectId.Parse(id));
            await _patientCollection.DeleteOneAsync(filter);
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }
    }
}