using System.Diagnostics;

namespace AutoFixture.Demo.EmailGateway;

public class EmailGateway : IEmailGateway
{
    public void Send(EmailMessage message)
    {
        // simulate sending email
        Debug.WriteLine("Sending email to: " + message.ToAddress);
    }
}
