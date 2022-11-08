namespace Hospitality.Patient.API.PatientHostedService
{
    public class PatientHostedServiceConsumer : BackgroundService
    {
        private IConnection _connection;
        private IModel _channel;
        private string? _queueName;
        private IPatientService _patientService;
        private IPatientHostedServicePublisher _publisherService;
        private readonly IConfiguration _configuration;
        private readonly string? _hostName;

        public PatientHostedServiceConsumer(IPatientService patientService, IPatientHostedServicePublisher publisherService, IConfiguration configuration)
        {
            _patientService = patientService;
            _publisherService = publisherService;
            _configuration = configuration;
            _hostName = _configuration.GetValue<string>("PATIENT_RABBITMQ_URL");

            var factory = new ConnectionFactory { HostName = _hostName };
            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
            _channel.ExchangeDeclare(exchange: "ExaminationExchange", type: ExchangeType.Direct);
            _queueName = _channel.QueueDeclare().QueueName;
            _channel.QueueBind(queue: _queueName, exchange: "ExaminationExchange", routingKey: "sentAfterExaminationFinished");
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            stoppingToken.ThrowIfCancellationRequested();

            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += async (ch, ea) =>
            {
                var content = Encoding.UTF8.GetString(ea.Body.ToArray());
                Debug.WriteLine($"PatientHostedServiceConsumer: Received message from HostedService: {content}");

                PatientNotificationDTO patientInfoForNotification = await preparePatientInfoForNotification(content);
                _publisherService.SendMessage(patientInfoForNotification);
            };
            _channel.BasicConsume(queue: _queueName, autoAck: true, consumer: consumer);
            return Task.CompletedTask;
        }

        public override void Dispose()
        {
            _channel.Close();
            _connection.Close();
            base.Dispose();
        }

        private async Task<PatientNotificationDTO> preparePatientInfoForNotification(string context)
        {
            ExaminationExecutionDto examinationExecution = JsonConvert.DeserializeObject<ExaminationExecutionDto>(context);
            double examinationPrice = GetExaminationPrice(examinationExecution.ExaminationTypeName);

            PatientNotificationDTO patientInfoForNotification = await _patientService.GetPatientByIDAsync(examinationExecution.PatientId);
            patientInfoForNotification.Status = examinationExecution.Status;
            patientInfoForNotification.ExaminationDescription = examinationExecution.Description;
            patientInfoForNotification.ExaminationTypeName = examinationExecution.ExaminationTypeName;
            patientInfoForNotification.Price = examinationPrice;
            return patientInfoForNotification;
        }

        private static double GetExaminationPrice(string examinationTypeName)
        {
            switch(examinationTypeName)
            {
                case "USG kolana":
                    return 1234.99;
                case "USG jamy brzusznej":
                    return 1001.99;
                case "RTG głowy":
                    return 900.99;
                case "RTG celowane na ząb obrotnika":
                    return 1234.99;
                case "RTG styczne czaszki":
                    return 500;
                case "Leczenie kanałowe zębów":
                    return 550.58;
                case "Badanie kału na pasożyty":
                    return 900;
                case "Cytologia płynna":
                    return 700.70;
                case "Echo serca":
                    return 2500;
                case "Gastroskopia":
                    return 1500.99;
                default:
                    return 0;
            }
        }
    }
}