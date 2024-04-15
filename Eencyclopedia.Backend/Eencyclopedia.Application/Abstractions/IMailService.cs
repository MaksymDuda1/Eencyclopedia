namespace Eencyclopedia.Application.Abstractions;

public interface IMailService
{ 
    void SendRegistrationEmail(string userEmail, string userName);
}