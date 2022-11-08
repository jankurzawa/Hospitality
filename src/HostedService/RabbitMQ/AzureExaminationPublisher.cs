namespace HostedService.RabbitMQ
{
    public class AzureExaminationPublisher : IExaminationPublisher
    {
        private IConfiguration _configuration;
        private const string queueNameToExamination = "hostedservicetoexamination";
        private const string queueNameToPatient = "hostedservicetopatient";

        public AzureExaminationPublisher(IConfiguration configuration)
            => _configuration = configuration;
        public async void SendMessage<T>(T message)
        {
            var json = JsonConvert.SerializeObject(message);
            await (new QueueClient(_configuration["ConectionStringRabbit"], queueNameToExamination)).SendMessageAsync(json);
            await (new QueueClient(_configuration["ConectionStringRabbit"], queueNameToPatient)).SendMessageAsync(json);
        }
    }
}
