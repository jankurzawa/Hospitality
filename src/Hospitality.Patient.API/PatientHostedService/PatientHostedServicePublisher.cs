namespace Hospitality.Patient.API.PatientHostedService
{
    public class PatientHostedServicePublisher : IPatientHostedServicePublisher
    {
        private readonly IConfiguration _configuration;
        private readonly string? _hostName;

        public PatientHostedServicePublisher(IConfiguration configuration)
        {
            _configuration = configuration;
            _hostName = _configuration.GetValue<string>("PATIENT_RABBITMQ_URL");
        }

        public void SendMessage<T>(T message)
        {
            var factory = new ConnectionFactory() { HostName = _hostName };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.ExchangeDeclare(exchange: "ExaminationExchange", type: ExchangeType.Direct);

                var json = JsonConvert.SerializeObject(message);
                var body = Encoding.UTF8.GetBytes(json);
                channel.BasicPublish(exchange: "ExaminationExchange",
                               routingKey: "sentInfoForNotification",
                               basicProperties: null,
                               body: body);
                Debug.WriteLine($"PatientHostedServicePublisher: Send message to EmailService: {json}");
            }
        }
    }
}