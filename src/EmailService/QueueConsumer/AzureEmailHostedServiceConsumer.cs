namespace EmailService.QueueConsumer
{
    public class AzureEmailHostedServiceConsumer : BackgroundService
    {
        private IEmailSender _emailSender;
        private IConfiguration _configuration;
        private const string _queueName = "patientservicetoemailservice";
        
        public AzureEmailHostedServiceConsumer(IEmailSender emailSender, IConfiguration configuration)
        {
            _emailSender = emailSender;
            _configuration = configuration;
        }
        protected async override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var _queueClient = new QueueClient(_configuration["ConectionStringRabbit"], _queueName);
            while (!stoppingToken.IsCancellationRequested)
            {
                var queueMessage = await _queueClient.ReceiveMessageAsync();
                if (queueMessage.Value != null)
                {
                    PatientNotificationDTO examinationExecutionDto = JsonConvert.DeserializeObject<PatientNotificationDTO>(queueMessage.Value.MessageText);
                    double costOfExamination = CheckIfIsInsured(examinationExecutionDto);

                    string messageText = "";
                    if (examinationExecutionDto.ExaminationDescription == "")
                    {
                        messageText = $"Hello, {examinationExecutionDto.PatientName} {examinationExecutionDto.PatientSurname}! \n" +
                                            $"Your examination \"{examinationExecutionDto.ExaminationTypeName}\" was finished. You could check result in your account. \n" +
                                            $"You need to pay: \"{costOfExamination}\" zł \n" +
                                            $"Kind regards,\nHospitality";
                    }
                    else
                    {
                        messageText = $"Hello, {examinationExecutionDto.PatientName} {examinationExecutionDto.PatientSurname}! \n" +
                                            $"Your examination \"{examinationExecutionDto.ExaminationTypeName}\" was finished.\nResults\n{examinationExecutionDto.ExaminationDescription}\n" +
                                            $"You need to pay: \"{costOfExamination}\" zł \n" +
                                            $"Kind regards,\nHospitality";
                    }
                    var message = new Message(new string[] { examinationExecutionDto.Email }, "Client message", messageText);

                    _emailSender.SendEmail(message);
                    await _queueClient.DeleteMessageAsync(queueMessage.Value.MessageId, queueMessage.Value.PopReceipt);
                }
            }
        }
        private double CheckIfIsInsured(PatientNotificationDTO patient)
            => patient.IsInsured ? patient.Price : 0;
    }
}
