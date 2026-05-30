using FluentAssertions;
using FluentAssertions.Execution;
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
        var subject = assertions.Subject;

        AssertionChain
            .GetOrCreate()
            .BecauseOf(because, becauseArgs)
            .ForCondition(!string.IsNullOrWhiteSpace(subject))
            .FailWith("Expected {context:string} to be a valid email{reason}, but found <null> or empty.")
            .Then
            .ForCondition(subject is not null && EmailRegex.IsMatch(subject))
            .FailWith("Expected {context:string} to be a valid email{reason}, but found {0}.", subject);

        return new AndConstraint<StringAssertions>(assertions);
    }
}