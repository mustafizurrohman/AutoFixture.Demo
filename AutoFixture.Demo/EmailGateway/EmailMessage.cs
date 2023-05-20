namespace AutoFixture.Demo.EmailGateway;

public class EmailMessage
{
    public EmailMessage(string toAddress, string messageBody, bool isImportant)
    {
        ToAddress = toAddress ?? throw new ArgumentNullException(nameof(toAddress));
        MessageBody = messageBody ?? throw new ArgumentNullException(nameof(messageBody));
        IsImportant = isImportant;
    }

    public EmailMessage(string toAddress, string messageBody, bool isImportant, string subject)
    {
        ToAddress = toAddress ?? throw new ArgumentNullException(nameof(toAddress));
        MessageBody = messageBody ?? throw new ArgumentNullException(nameof(messageBody));
        Subject = subject ?? throw new ArgumentNullException(nameof(subject));
        IsImportant = isImportant;
    }


    public string ToAddress { get; private set; }
    public string MessageBody { get; private set; }
    public string? Subject { get; set; }
    public bool IsImportant { get; private set; }
}
