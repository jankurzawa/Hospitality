namespace Hospitality.Examination.RabbitMQ
{
        public interface IRabbitMqService
        {
            void SendMessage<T>(T message);
        }
}
