using MailKit;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;

namespace EmailService;

/// <summary>
/// A service for sending emails using SMTP with synchronous and asynchronous options.
/// </summary>
public class EmailSender : IEmailSender
{
    private readonly EmailConfiguration _emailConfig;

    /// <summary>
    /// Initializes a new instance of the <see cref="EmailSender"/> class with the specified email configuration.
    /// </summary>
    /// <param name="emailConfig">The email configuration settings.</param>
    public EmailSender(IOptions<EmailConfiguration> emailConfig)
    {
        _emailConfig = emailConfig.Value;
    }

    public void SendMail(Message message)
    {
        var emailMessage = CreateEmailMessage(message);
        
        Send(emailMessage);
    }

    public async Task SendMailAsync(Message message)
    {
        var emailMessage = CreateEmailMessage(message);
        
        await SendAsync(emailMessage);
    }

    /// <summary>
    /// Sends a email message synchronously using SMTP.
    /// </summary>
    /// <param name="emailMessage">The MIME email message to be sent.</param>
    private void Send(MimeMessage emailMessage)
    {
        using (var client = new SmtpClient())
        {
            try
            {
                client.Connect(_emailConfig.SmtpServer, _emailConfig.Port, true);
                client.AuthenticationMechanisms.Remove("XOAUTH2");
                client.Authenticate(_emailConfig.Username, _emailConfig.Password);
            }
            catch
            {
                throw;
            }
            finally
            {
                client.Disconnect(true);
                client.Dispose();
            }
        }
    }

    /// <summary>
    /// Sends a email message asynchronously using SMTP.
    /// </summary>
    /// <param name="mailMessage">The MIME email message to be sent.</param>
    /// <returns>A task representing the asynchronous send operation.</returns>
    private async Task SendAsync(MimeMessage mailMessage)
    {
        using (var client = new SmtpClient())
        {
            try
            {
                await client.ConnectAsync(_emailConfig.SmtpServer, _emailConfig.Port, true);
                client.AuthenticationMechanisms.Remove("XOAUTH2");
                await client.AuthenticateAsync(_emailConfig.Username, _emailConfig.Password);

                await client.SendAsync(mailMessage);
            }
            catch
            {
                //log an error message or throw an exception, or both.
                throw;
            }
            finally
            {
                await client.DisconnectAsync(true);
                client.Dispose();
            }
        }
    }

    /// <summary>
    /// Creates a <see cref="MimeMessage"/> from the provided <see cref="Message"/>.
    /// </summary>
    /// <param name="message">The message details including recipients, subject, and content.</param>
    /// <returns>A <see cref="MimeMessage"/> constructed from the message.</returns>
    private MimeMessage CreateEmailMessage(Message message)
    {
        var emailMessage = new MimeMessage();
        emailMessage.From.Add(new MailboxAddress("email", _emailConfig.From));
        emailMessage.To.AddRange(message.To);
        emailMessage.Subject = message.Subject;
        emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Text) { Text = message.Content };

        return emailMessage;
    }
}