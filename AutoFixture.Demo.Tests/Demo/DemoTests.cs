﻿using System.Collections.Immutable;
using AutoFixture.Demo.Core.Constants;
using AutoFixture.Demo.Tests.AssertionHelpers;
using AutoFixture.Demo.Tests.UnitTests;

namespace AutoFixture.Demo.Tests.Demo;

/// <summary>
/// Using primary constructor- new C# 12 feature
/// </summary>
/// <param name="outputHelper">Output helper helps us in logging info in the debug screen</param>
public class DemoTests(ITestOutputHelper outputHelper) : TestBase(outputHelper)
{

    /// <summary>
    /// Demo 1 : 
    /// This does generates person and checks that the generated values are in accordance
    /// to the business rules
    /// TODO: Change customization and see effects
    /// TODO: Add new property to person and demonstrate that no refactor is necessary here
    /// </summary>
    /// <param name="persons"></param>
    [Theory]
    // [AutoData]
    // [AutoDataPerson]
    [AutoDataCustom(localization: Localizations.German)]
    public void VerifyThatPersonsAreCorrectlyGenerated(List<Person> persons)
    {
        PrintObject(persons);

        // ASSERT
        using (new AssertionScope())
        {
            persons.ShouldBeValidPersons();
        }

    }

    /// <summary>
    /// Demo 2: Person with specific data
    /// </summary>
    [Fact]
    public void VerifyThatCreatedOnWasCorrectlySet()
    {
        // ARRANGE
        var now = DateTime.Now;

        var fixture = new Fixture()
            .Customize(new AllCustomization());

        // Set a fixed value of CreatedOn and use the rules in AllCustomization
        var personBuilder = fixture.Build<Person>()
            .With(p => p.CreatedOn, now);

        // ACT
        var persons = personBuilder.CreateMany().ToImmutableList();

        PrintObject(persons);

        // ASSERT
        using (new AssertionScope())
        {
            persons.Select(p => p.CreatedOn)
                .Distinct()
                .First()
                .Should()
                .BeCloseTo(now, TimeSpan.FromMicroseconds(1),
                    because: "Each person should have the same date of birth as specified above");

            persons.Select(p => p.CreatedOn)
                .Distinct()
                .Should()
                .HaveCount(1,
                    because: "All Persons should have only 1 fixed date of birth");
        }
    }

    /// <summary>
    /// Demo 3 : Person with specific data + customization
    /// </summary>
    [Fact]
    public void VerifyThatDateIsValidatedOnUpdateDateOfBirthMethod()
    {
        // ARRANGE
        var now = DateTime.Now;
        var oneWeekInTheFuture = now.AddDays(7);

        var fixture = new Fixture()
            .Customize(new AllCustomization());

        // Set a fixed value of CreatedOn and use the rules in AllCustomization
        var person = fixture.Build<Person>()
            .With(p => p.CreatedOn, now)
            .Create();

        PrintObject(person);

        // ACT
        var action = () => person.UpdateDateOfBirth(oneWeekInTheFuture);

        // ASSERT
        action.Should()
            .ThrowExactly<ArgumentException>();

    }

    /// <summary>
    /// Demo 4: Manual mocking
    /// </summary>
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
        mockGateway.Verify(mg => mg.Send(It.IsAny<EmailMessage>()), Times.Once());
    }

    /// <summary>
    /// Demo 5: Auto mocking
    /// [Frozen] ensures that the same instance of mockGateway is used
    /// to create other instances of object- EMailMessageBuffer in this case
    /// For this to work mockGateway should be frozen first and then
    /// EmailMessageBuffer should be created
    /// </summary>
    /// <param name="messages">Messages</param>
    /// <param name="mockGateway">Mock of Email Gateway</param>
    /// <param name="sut">System under test</param>
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
        // We do not care about contents of EmailMessage
        mockGateway.Verify(mg => mg.Send(It.IsAny<EmailMessage>()), Times.Exactly(messages.Count));
    }

}
