using FluentAssertions;
using FluentAssertions.Collections;
using FluentAssertions.Execution;
using FluentAssertions.Primitives;

namespace AutoFixture.Demo.Tests.AssertionHelpers;

public static class CollectionAssertionExtensions
{
    public static AndConstraint<GenericCollectionAssertions<T>> BeValidCollection<T>(
        this GenericCollectionAssertions<T> assertions,
        Action<T> itemAssertion,
        string because = "",
        params object[] becauseArgs)
    {
        ArgumentNullException.ThrowIfNull(assertions);
        ArgumentNullException.ThrowIfNull(itemAssertion);

        assertions.Subject
            .Should()
            .NotBeNullOrEmpty(because, becauseArgs);

        using var scope = new AssertionScope();

        foreach (var item in assertions.Subject ?? [])
        {
            itemAssertion(item);
        }

        return new AndConstraint<GenericCollectionAssertions<T>>(assertions);
    }
}