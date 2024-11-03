namespace EmailService;

public interface IEmailSender
{
    void SendMail(Message message);
    Task SendMailAsync(Message message);
}