using System.Net.Mail;
using MailKit;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using MimeKit.Text;
using IMailService = Eencyclopedia.Application.Abstractions.IMailService;
using SmtpClient = MailKit.Net.Smtp.SmtpClient;

namespace Eencyclopedia.Application.Services;

public class MailService : IMailService
{
    public void SendRegistrationEmail(string userEmail, string userName)
    {
        var email = new MimeMessage();
        email.From.Add(MailboxAddress.Parse("Eencyclopedia387@outlook.com"));
        email.To.Add(MailboxAddress.Parse(userEmail));
        email.Subject = "New registration";
        email.Body = new TextPart(TextFormat.Html)
        {
            Text = $"Hello, {userName}," +
                   $" welcome to the eencyclopedia"
        };

        using (var smtp = new SmtpClient())
        {
            smtp.Connect("smtp.outlook.com", 587, SecureSocketOptions.StartTls);
            smtp.Authenticate("Eencyclopedia387@outlook.com", "Deodorantstick1");
            smtp.Send(email);
            smtp.Disconnect(true);
        }
    }
}