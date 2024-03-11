using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace clinicpro.Entities;

[BsonIgnoreExtraElements]
public class Patient
{
    [BsonId]       
    [BsonIgnoreIfDefault]
    public ObjectId _id { get; set; }
    public string patientID { get; set; }
    public string idCardNumber { get; set; }
    public required string firstName { get; set; }
    public required string lastName { get; set; }
    public string gender { get; set; }
    public string bedNumber { get; set; }
    public DateTime dateOfBirth { get; set; }
    public int height { get; set; }
    public int weight { get; set; }
    public string photoUrl { get; set; }
    public double phoneNumber { get; set; }
    public string? email { get; set; }
    public string address { get; set; }
    public string postalCode { get; set; }
    public string? doctor { get; set; }
    public string? emergencyContact { get; set; }
    public string? medicalNotes { get; set; }
    public bool? medicalAllergies { get; set; }
    public bool? disabled { get; set; }
    public latestRecord? latestRecord { get; set; }


    public override string ToString()
    {
        return firstName + " " + lastName;
    }
}