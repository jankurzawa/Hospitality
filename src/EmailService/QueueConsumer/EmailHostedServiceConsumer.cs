namespace EmailService.QueueConsumer
{
    public class EmailHostedServiceConsumer : BackgroundService
    {
        private IConnection _connection;
        private IModel _channel;
        private string? _queueName;
        private IEmailSender _emailSender;
        private readonly IConfiguration _configuration;
        private readonly string? _hostName;

        public EmailHostedServiceConsumer(IEmailSender emailSender, IConfiguration configuration)
        {
            _emailSender = emailSender;
            _configuration = configuration;
            _hostName = _configuration.GetValue<string>("EMAIL_RABBITMQ_URL");

            var factory = new ConnectionFactory { HostName = _hostName };
            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
            _channel.ExchangeDeclare(exchange: "ExaminationExchange", type: ExchangeType.Direct);
            _queueName = _channel.QueueDeclare().QueueName;
            _channel.QueueBind(queue: _queueName, exchange: "ExaminationExchange", routingKey: "sentInfoForNotification");
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            stoppingToken.ThrowIfCancellationRequested();

            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += async (ch, ea) =>
            {
                var content = Encoding.UTF8.GetString(ea.Body.ToArray());
                Debug.WriteLine($"EmailHostedServiceConsumer: Received message from PatientHostedServicePublisher: {content}");

                PatientNotificationDTO examinationExecutionDto = JsonConvert.DeserializeObject<PatientNotificationDTO>(content);
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
            };
            _channel.BasicConsume(queue: _queueName, autoAck: true, consumer: consumer);
            return Task.CompletedTask;
        }

        private double CheckIfIsInsured(PatientNotificationDTO patient)
            => patient.IsInsured ? patient.Price : 0;

        public override void Dispose()
        {
            _channel.Close();
            _connection.Close();
            base.Dispose();
        }
    }
}