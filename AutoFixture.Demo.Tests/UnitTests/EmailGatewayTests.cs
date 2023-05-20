using AutoFixture.Demo.EmailGateway;

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
    /// <param name="message"></param>
    /// <param name="mockGateway"></param>
    /// <param name="sut"></param>
    [Theory]
    [AutoMoqData]
    public void SendEmailToGateway_AutoMoq(EmailMessage message,
        [Frozen] Mock<IEmailGateway> mockGateway,
        EmailMessageBuffer sut)
    {
        // Arrange
        sut.Add(message);

        // Act
        sut.SendAll();

        // Assert
        // Assert that the send method was called once 
        // since only one message was present in buffer
        // We do not care about details of EmailMessage
        mockGateway.Verify(x => x.Send(It.IsAny<EmailMessage>()), Times.Once());
    }
}
