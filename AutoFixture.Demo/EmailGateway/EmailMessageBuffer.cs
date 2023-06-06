namespace AutoFixture.Demo.EmailGateway;

public class EmailMessageBuffer
{
    private readonly List<EmailMessage> _emails = new();

    public EmailMessageBuffer(IEmailGateway emailGateway)
    {
        EmailGateway = emailGateway;
    }

    private IEmailGateway EmailGateway { get; }
    
    public int UnsentMessagesCount => _emails.Count;

    public int ImportantUnsentMessagesCount => _emails.Count(email => email.IsImportant);

    public int UnImportantUnsentMessagesCount => _emails.Count(email => !email.IsImportant);

    public void SendAll()
    {
        foreach (var email in _emails.ToList())
        {
            Send(email);
            _emails.Remove(email);
        }
    }

    private void Send(EmailMessage email)
    {
        EmailGateway.Send(email);
    }

    public void Add(EmailMessage message)
    {
        _emails.Add(message);
    }

    public void AddRange(IEnumerable<EmailMessage> emails)
    {
        _emails.AddRange(emails);
    }

    public void SendLimited(int maximumMessagesToSend)
    {
        var limitedBatchOfMessages = _emails.Take(maximumMessagesToSend).ToArray();
        
        foreach (var email in limitedBatchOfMessages)
        {
            Send(email);
            _emails.Remove(email);
        }
    }
}
