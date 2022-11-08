namespace HostedService.RabbitMQ
{
    public class AzureExaminationConsumer : BackgroundService
    {
        private readonly IConfiguration _configuration;
        private IExaminationExecution _examinationExecution;
        private IExaminationPublisher _examinationPublisher;
        private const string _queueName = "examinationtohostedservice";
        public AzureExaminationConsumer(IConfiguration configuration, IExaminationExecution examinationExecution, IExaminationPublisher examinationPublisher)
        {
            _configuration = configuration;
            _examinationExecution = examinationExecution;
            _examinationPublisher = examinationPublisher;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var _queueClient = new QueueClient(_configuration["ConectionStringRabbit"], _queueName);
            while (!stoppingToken.IsCancellationRequested)
            {
                var queueMessage = await _queueClient.ReceiveMessageAsync();
                if (queueMessage.Value != null)
                {
                    ExaminationExecutionDto examinationExecutionDto = _examinationExecution.executeExamination(queueMessage.Value.MessageText);
                    _examinationPublisher.SendMessage(examinationExecutionDto);
                    await _queueClient.DeleteMessageAsync(queueMessage.Value.MessageId, queueMessage.Value.PopReceipt);
                }
                await Task.Delay(TimeSpan.FromSeconds(10));
            }
        }
    }
}
