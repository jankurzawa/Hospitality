namespace PatientTemperatureControl
{
    public class PatientTemperature
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public string PatientId { get; set; }
        [BsonElement("Temperature")]
        public decimal Temperature { get; set; }
        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        public DateTime MeasurementDate { get; set; }
    }
}
