using FluentAssertions.Primitives;
using System.Text.RegularExpressions;

namespace AutoFixture.Demo.Tests;

public static class EmailAssertionExtensions
{
    // A robust email regex (simplified but practical)
    private static readonly Regex EmailRegex = new(
        @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
        RegexOptions.Compiled | RegexOptions.IgnoreCase);

    public static AndConstraint<StringAssertions> BeValidEmail(
        this StringAssertions assertions,
        string because = "",
        params object[] becauseArgs)
    {
        string subject = assertions.Subject;

        Execute.Assertion
            .ForCondition(!string.IsNullOrWhiteSpace(subject))
            .BecauseOf(because, becauseArgs)
            .FailWith("Expected {context:string} to be a valid email, but found <null> or empty.");

        Execute.Assertion
            .ForCondition(EmailRegex.IsMatch(subject))
            .BecauseOf(because, becauseArgs)
            .FailWith("Expected {context:string} to be a valid email, but '{0}' is not valid.", subject);

        return new AndConstraint<StringAssertions>(assertions);
    }
}
