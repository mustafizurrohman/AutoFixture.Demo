using AutoFixture.Xunit2;
using System.Reflection;

namespace AutoFixture.Demo.Customizations.Attributes;

/// <summary>
/// Usage [ListLength(xxx)]
/// </summary>
[AttributeUsage(AttributeTargets.Parameter)]
public sealed class ListLengthAttribute : CustomizeAttribute 
{ 
    private readonly int Length;

    public ListLengthAttribute(int length)
    {
        Length = length;
    }

    // TODO: Finish this 
    public override ICustomization GetCustomization(ParameterInfo parameter)
    {
        throw new NotImplementedException();
    }
}
