namespace Hospitality.Patient.API.PatientHostedService
{
    public class AzurePatientHostedServiceConsumer : BackgroundService
    {
        private readonly IConfiguration _configuration;
        private IPatientService _patientService;
        private IPatientHostedServicePublisher _publisherService;
        private const string _queueName = "hostedservicetopatient";
        public AzurePatientHostedServiceConsumer(IConfiguration configuration, IPatientService patientService, IPatientHostedServicePublisher publisherService)
        {
            _configuration = configuration;
            _patientService = patientService;
            _publisherService = publisherService;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var _queueClient = new QueueClient(_configuration["ConectionStringRabbit"], _queueName);
            while (!stoppingToken.IsCancellationRequested)
            {
                var queueMessage = await _queueClient.ReceiveMessageAsync();
                if (queueMessage.Value != null)
                {
                    PatientNotificationDTO patientInfoForNotification = await PreparePatientInfoForNotification(queueMessage.Value.MessageText);
                    _publisherService.SendMessage(patientInfoForNotification);
                    await _queueClient.DeleteMessageAsync(queueMessage.Value.MessageId, queueMessage.Value.PopReceipt);
                }
            }
        }

        private async Task<PatientNotificationDTO> PreparePatientInfoForNotification(string context)
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
            switch (examinationTypeName)
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
