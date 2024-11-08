using MimeKit;

namespace EmailService;

/// <summary>
/// Class <c>Message</c> Represents an email message with recipients, subject, and content.
/// </summary>
public class Message
{
    /// <summary>
    /// Gets or sets the list of recipient email addresses.
    /// </summary>
    public List<MailboxAddress> To { get; set; }
    /// <summary>
    /// Gets or sets the subject of the email message.
    /// </summary>
    public string Subject { get; set; }
    /// <summary>
    /// Gets or sets the content of the email message.
    /// </summary>
    public string Content { get; set; }

    // <summary>
    /// Gets or sets the content type of the email message.
    /// </summary>
    public MimeKit.Text.TextFormat ContentType { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="Message"/> class with the specified recipients, subject, and content.
    /// </summary>
    /// <param name="to">A collection of <see cref="EmailUser"/> objects representing the recipients of the email.</param>
    /// <param name="subject">The subject of the email message.</param>
    /// <param name="content">The content of the email message.</param>
    /// <param name="contentType">The content type of the email message content</param>
    public Message(IEnumerable<EmailUser> to, string subject, string content, MimeKit.Text.TextFormat contentType){
        To = new List<MailboxAddress>();

        To.AddRange(to.Select(x => new MailboxAddress(x.UserName, x.Address)));
        Subject = subject;
        Content = content;
        ContentType = contentType;
    }
}
