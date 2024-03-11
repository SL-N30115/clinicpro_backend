﻿namespace clinicpro.Entities;

public class MongoDBSettings
{
    public string ConnectionURL { get; set; } = null!;
    public string DatabaseName { get; set; } = null!;
    public string CollectionName { get; set; } = null!;
}