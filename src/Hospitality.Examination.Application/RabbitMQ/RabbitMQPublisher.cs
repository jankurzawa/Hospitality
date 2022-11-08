namespace Hospitality.Examination.RabbitMQ
{
    public class RabbitMQPublisher : IRabbitMqService
    {
        private readonly IConfiguration _configuration;
        private readonly string _hostName;

        public RabbitMQPublisher(IConfiguration configuration)
        {
            _configuration = configuration;
            _hostName = _configuration.GetValue<string>("EXAMINATION_RABBITMQ_URL");
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
                               routingKey: "sentForExamination",
                               basicProperties: null,
                               body: body);
                Debug.WriteLine($"ExaminationAPI:  Send message to HostedService: {json}");
            }
        }
    }
}