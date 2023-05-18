namespace AutoFixture.Demo.EmailGateway;

public interface IEmailGateway
{
    void Send(EmailMessage message);
}