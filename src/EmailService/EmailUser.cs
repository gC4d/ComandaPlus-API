using System;

namespace EmailService;

/// <summary>
/// Class <c>EmailUser</c> Represents an email user with an email address and username.
/// </summary>
public class EmailUser
{
    /// <summary>
    /// Gets or sets the email address of the user.
    /// </summary>
    public string Address { get; set;}

    /// <summary>
    /// Gets or sets the username of the user.
    /// </summary>
    public string UserName { get; set;}

    /// <summary>
    /// Initializes a new instance of the <see cref="EmailUser"/> class with the specified username and email address.
    /// </summary>
    /// <param name="username">The username of the email user.</param>
    /// <param name="address">The email address of the email user.</param>
    public EmailUser(string username, string address)
    {
        Address = address;
        UserName = username;
    }
}
