using MongoDB.Bson.Serialization.Attributes;

namespace clinicpro.Entities;

public class latestRecord
{
    [BsonElement("BLOOD_PRESSURE")]
    public string? BloodPressure { get; set; } 
    [BsonElement("RESPIRATORY_RATE")]
    public string? RespiratoryRate { get; set; } 
    [BsonElement("BLOOD_OXYGEN_LEVEL")]
    public string? BloodOxygenLevel { get; set; }
    [BsonElement("HEARTBEAT_RATE")]
    public string? HeartbeatRate { get; set; } 
}