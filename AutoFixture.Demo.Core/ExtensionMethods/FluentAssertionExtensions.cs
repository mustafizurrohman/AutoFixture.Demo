using FluentAssertions;
using FluentAssertions.Execution;
using FluentAssertions.Primitives;

namespace AutoFixture.Demo.Core.ExtensionMethods;

/*
public static class FluentAssertionExtensions
{
    public static StringAssertions Should(this string instance)
    {
        return new StringAssertions(instance);
    }
}

public class StringAssertions : ReferenceTypeAssertions<string, StringAssertions>
{
    public StringAssertions(string instance) : base(instance)
    {
    }
    
    protected override string Identifier => "StringAssertion";

    
    public AndConstraint<string> ContainNoNumbers(string instance, string because = "", params object[] becauseArgs)
    {
        // https://fluentassertions.com/extensibility/#building-your-own-extensions
        // https://stackoverflow.com/questions/59105851/how-do-i-write-customassertion-using-fluentassertions
        Execute.Assertion
            .BecauseOf(because, becauseArgs)
            .ForCondition(!string.IsNullOrEmpty(instance))
            .FailWith("Input cannot be null or empty or just white spaces")
            .Then
            .Given(() => instance)
            .ForCondition(input => input.Any(char.IsDigit))
            .FailWith($"Expected {1} to contain no numbers, but found {1}", _ => instance, input => input.Where(char.IsDigit));

        return new AndConstraint<string>(this);
    } 
}
*/