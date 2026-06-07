#nullable enable

using System.Collections;
using System.Reflection;
using AutoFixture.Xunit2;
using Xunit;

namespace AutoFixture.Demo.Customizations.Attributes;

[AttributeUsage(AttributeTargets.Parameter, AllowMultiple = false, Inherited = false)]
public sealed class CollectionCountAttribute(int length) : CustomizeAttribute
{
    private readonly int _length = length >= 0
        ? length
        : throw new ArgumentOutOfRangeException(
            nameof(length),
            "Collection count must be greater than or equal to 0.");

    public override ICustomization GetCustomization(ParameterInfo parameter)
    {
        ArgumentNullException.ThrowIfNull(parameter);

        EnsureUsedOnXunitTestMethod(parameter);
        EnsureUsedOnListParameter(parameter);

        return new ListLengthCustomization(parameter, _length);
    }

    private static void EnsureUsedOnXunitTestMethod(ParameterInfo parameter)
    {
        if (parameter.Member is not MethodInfo method)
        {
            throw new InvalidOperationException(
                $"{nameof(CollectionCountAttribute)} can only be used on test method parameters.");
        }

        var isXunitTestMethod = method
            .GetCustomAttributes(inherit: true)
            .OfType<FactAttribute>()
            .Any();

        if (!isXunitTestMethod)
        {
            throw new InvalidOperationException(
                $"{nameof(CollectionCountAttribute)} can only be used on parameters of xUnit test methods marked with [Fact] or [Theory].");
        }
    }

    private static void EnsureUsedOnListParameter(ParameterInfo parameter)
    {
        if (!parameter.ParameterType.IsGenericType ||
            parameter.ParameterType.GetGenericTypeDefinition() != typeof(List<>))
        {
            throw new InvalidOperationException(
                $"{nameof(CollectionCountAttribute)} can only be used on List<T> parameters.");
        }
    }

    private sealed class ListLengthCustomization(ParameterInfo parameter, int length) : ICustomization
    {
        public void Customize(IFixture fixture)
        {
            ArgumentNullException.ThrowIfNull(fixture);

            fixture.Customizations.Insert(
                0,
                new ListLengthSpecimenBuilder(parameter, length));
        }
    }

    private sealed class ListLengthSpecimenBuilder(ParameterInfo parameter, int length) : ISpecimenBuilder
    {
        public object Create(object request, ISpecimenContext context)
        {
            ArgumentNullException.ThrowIfNull(context);

            if (!Equals(request, parameter))
            {
                return new NoSpecimen();
            }

            var itemType = parameter.ParameterType.GetGenericArguments()[0];
            var listType = typeof(List<>).MakeGenericType(itemType);

            var list = (IList)Activator.CreateInstance(listType)!;

            for (var i = 0; i < length; i++)
            {
                list.Add(context.Resolve(itemType));
            }

            return list;
        }
    }
}