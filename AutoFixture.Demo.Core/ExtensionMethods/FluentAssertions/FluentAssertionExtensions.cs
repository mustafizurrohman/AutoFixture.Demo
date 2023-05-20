using FluentAssertions;
using FluentAssertions.Execution;
using FluentAssertions.Primitives;
#pragma warning disable S1133

namespace AutoFixture.Demo.Core.ExtensionMethods.FluentAssertions;

//public static class FluentAssertionExtensions
//{
//    /// <summary>
//    /// TODO: Throws an exception
//    /// </summary>
//    /// <param name="assert"></param>
//    [Obsolete("Do not use!")]
//    public static void NotContainNumbers(this StringAssertions assert)
//    {
//        var numbers = assert.Subject.Count(char.IsDigit);

//        var reason = $"Expected {assert.Subject} to not contain any Numbers but found {numbers} numbers.";

//        numbers
//            .Should()
//            .BeLessOrEqualTo(0, reason);
//    }
//}


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
