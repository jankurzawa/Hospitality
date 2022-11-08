namespace EmailService.Services.Interfaces
{
    public interface IEmailSender
    {
        void SendEmail(Message message);
    }
}