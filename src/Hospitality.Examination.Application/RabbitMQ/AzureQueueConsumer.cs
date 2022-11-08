namespace Hospitality.Examination.Application.RabbitMQ
{
    public class AzureQueueConsumer : BackgroundService
    {
        private readonly IConfiguration _configuration;
        private IUpdateExamination _updateExamination;
        private const string _queueName = "hostedservicetoexamination";
        public AzureQueueConsumer(IConfiguration configuration, IUpdateExamination updateExamination)
        {
            _configuration = configuration;
            _updateExamination = updateExamination;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var _queueClient = new QueueClient(_configuration["ConectionStringRabbit"], _queueName);
            while (!stoppingToken.IsCancellationRequested)
            {
                var queueMessage = await _queueClient.ReceiveMessageAsync();
                if (queueMessage.Value != null)
                {
                    await _updateExamination.updateExaminationData(queueMessage.Value.MessageText);
                    await _queueClient.DeleteMessageAsync(queueMessage.Value.MessageId, queueMessage.Value.PopReceipt);
                }
                await Task.Delay(TimeSpan.FromSeconds(10));
            }
        }
    }
}
