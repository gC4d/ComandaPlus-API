namespace EmailService;

/// <summary>
/// Interface <c>IEmailSender</c> defines a service for sending email messages with synchronous and asynchronous methods.
/// </summary>
public interface IEmailSender
{

    /// <summary>
    /// Sends an email message synchronously.
    /// </summary>
    /// <param name="message">The message details including recipients, subject, and content.</param>
    void SendMail(Message message);

    /// <summary>
    /// Sends an email message asynchronously.
    /// </summary>
    /// <param name="message">The message details including recipients, subject, and content.</param>
    /// <returns>A task that represents the asynchronous send operation.</returns>
    Task SendMailAsync(Message message);
}