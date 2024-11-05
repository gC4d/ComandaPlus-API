using System;

namespace EmailService;

/// <summary>
/// Class <c>EmailConfiguration</c> Represents the configuration settings for sending emails.
/// </summary>
public class EmailConfiguration
{
    /// <summary>
    /// Gets or sets the email address from which emails are sent.
    /// </summary>
    public required string From { get; set; }

    /// <summary>
    /// Gets or sets the SMTP server used for sending emails.
    /// </summary>
    public required string SmtpServer { get; set; }

    /// <summary>
    /// Gets or sets the port number used by the SMTP server.
    /// </summary>
    public int Port { get; set; }

    /// <summary>
    /// Gets or sets the username for authenticating with the SMTP server.
    /// </summary>
    public required string Username { get; set; }

    /// <summary>
    /// Gets or sets the password for authenticating with the SMTP server.
    /// </summary>
    public required string Password { get; set; }
}