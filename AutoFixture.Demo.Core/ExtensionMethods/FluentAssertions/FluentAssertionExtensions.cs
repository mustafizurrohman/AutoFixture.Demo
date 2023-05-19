using FluentAssertions;
using FluentAssertions.Execution;
using FluentAssertions.Primitives;

namespace AutoFixture.Demo.Core.ExtensionMethods.FluentAssertions;

public static class FluentAssertionExtensions
{
    public static void NotContainNumbers(this StringAssertions assert, string because = "", params object[] becauseArgs)
    {
        assert.Subject
            .Should()
            .MatchRegex(@"[a-zA-Z]", because, becauseArgs);
    }
}


public class CustomStringAssertions
    : ReferenceTypeAssertions<string, StringAssertions>
{

    public CustomStringAssertions(string inputString)
        : base(inputString)
    {

    }

    protected override string Identifier => "string";

    [CustomAssertion]
    public AndConstraint<CustomStringAssertions> ContainsNoNumbers
        (string inputString, string because = "", params object[] becauseArgs)
    {
        Execute.Assertion
            .BecauseOf(because, becauseArgs)
            .ForCondition(!string.IsNullOrWhiteSpace(inputString))
            .FailWith("You cannot assert on a empty or null string")
            .Then
            .Given(() => Subject)
            .ForCondition(input => input.Any(char.IsDigit))
            .FailWith("Excepted {context:string} to contain no digits {reason}, but found {1}.",
                _ => inputString,
                ptc => ptc.Where(char.IsDigit));

        return new AndConstraint<CustomStringAssertions>(this);
    }
}