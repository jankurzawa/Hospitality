namespace EmailSender
{
    public interface IEmailService
    {
        void SendEmail(Message message);
    }
}