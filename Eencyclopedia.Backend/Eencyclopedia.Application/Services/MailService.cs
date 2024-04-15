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
        email.From.Add(MailboxAddress.Parse(userEmail));
        email.To.Add(MailboxAddress.Parse(userEmail));
        email.Subject = "Test subject";
        email.Body = new TextPart(TextFormat.Html)
        {
            Text = $"Hello, {userName}," +
                   $" welcome to the eencyclopedia"
        };

        using (var smtp = new SmtpClient())
        {
            smtp.Connect("smtp.ethereal.email", 587, SecureSocketOptions.StartTls);
            smtp.Authenticate("emelia.baumbach31@ethereal.email", "Wtvasdm2juws2Fcc6f");
            smtp.Send(email);
            smtp.Disconnect(true);
        }
    }
}