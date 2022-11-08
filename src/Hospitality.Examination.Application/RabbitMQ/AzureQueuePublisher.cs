namespace Hospitality.Examination.Application.RabbitMQ
{
    public class AzureQueuePublisher : IRabbitMqService
    {
        private IConfiguration _configuration;
        private const string queueName = "examinationtohostedservice";
        
        public AzureQueuePublisher(IConfiguration configuration)
            => _configuration = configuration;
        
        public async void SendMessage<T>(T message)
            => await (new QueueClient(_configuration["ConectionStringRabbit"], queueName))
            .SendMessageAsync(JsonConvert.SerializeObject(message));
    }
}
