namespace HostedService
{
    public class ExaminationPublisher : IExaminationPublisher
    {
        private readonly IConfiguration _configuration;
        private readonly string? _hostName;

        public ExaminationPublisher(IConfiguration configuration)
        {
            _configuration = configuration;
            _hostName = _configuration.GetValue<string>("HOSTED_RABBITMQ_URL");
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
                               routingKey: "sentAfterExaminationFinished",
                               basicProperties: null,
                               body: body);
                Debug.WriteLine($"HostedService: Send message to Examination.API: {json}");
            }
        }
    }
}