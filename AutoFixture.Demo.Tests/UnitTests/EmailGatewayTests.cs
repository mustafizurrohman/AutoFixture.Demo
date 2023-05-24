namespace AutoFixture.Demo.Tests.UnitTests;

public class EmailGatewayTests : TestBase
{
    public EmailGatewayTests(ITestOutputHelper outputHelper)
        : base(outputHelper)
    {
    }

    [Fact]
    public void SendEmailToGateway_ManualMoq()
    {
        // Arrange
        var fixture = new Fixture();

        var mockGateway = new Mock<IEmailGateway>();

        var sut = new EmailMessageBuffer(mockGateway.Object);
        sut.Add(fixture.Create<EmailMessage>());
        
        // Act
        sut.SendAll();

        // Assert
        // Assert that the send method was called once 
        // since only one message was present in buffer
        // We do not care about details of EmailMessage
        mockGateway.Verify(x => x.Send(It.IsAny<EmailMessage>()), Times.Once());
    }

    /// <summary>
    /// [Frozen] ensures that the same instance of mockGateway is used
    /// to create other instances of object- EMailMessageBuffer in this case
    /// For this to work mockGateway should be frozen first and then
    /// EmailMessageBuffer should be created
    /// </summary>
    /// <param name="messages"></param>
    /// <param name="mockGateway"></param>
    /// <param name="sut"></param>
    [Theory]
    [AutoMoqData]
    public void SendEmailToGateway_AutoMoq(List<EmailMessage> messages,
        [Frozen] Mock<IEmailGateway> mockGateway,
        EmailMessageBuffer sut)
    {
        // Arrange
        sut.AddRange(messages);

        // Act
        sut.SendAll();

        // Assert
        // Assert that the send method was called the same number of times 
        // as there are messages in the buffer
        // We do not care about details of EmailMessage
        mockGateway.Verify(x => x.Send(It.IsAny<EmailMessage>()), Times.Exactly(messages.Count));
    }

    [Theory]
    [AutoMoqData]
    public void SendEmailToGateway_ManualMoq_SendLimited(int num1, int num2)
    {
        // Arrange
        var min = Math.Min(num1, num2);
        var max = Math.Max(num1, num2);

        var fixture = new Fixture();

        var mockGateway = new Mock<IEmailGateway>();

        var sut = new EmailMessageBuffer(mockGateway.Object);
        sut.AddRange(fixture.CreateMany<EmailMessage>(max));

        var numberOfMessagesToSend = fixture.CreateInt(min, max - 1);

        // Act
        sut.SendLimited(numberOfMessagesToSend);

        // Assert
        mockGateway.Verify(x => x.Send(It.IsAny<EmailMessage>()), Times.Exactly(numberOfMessagesToSend));
    }

}
