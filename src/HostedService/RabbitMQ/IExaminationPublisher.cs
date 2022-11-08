namespace HostedService
{
    public interface IExaminationPublisher
    {
        void SendMessage<T>(T message);
    }
}