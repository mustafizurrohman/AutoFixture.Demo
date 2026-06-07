using AutoFixture.AutoMoq;
using AutoFixture.Demo.Customizations.Customizations;
using AutoFixture.Xunit2;

namespace AutoFixture.Demo.Customizations.Attributes;

/// <summary>
/// All customizations
/// </summary>
[AttributeUsage(AttributeTargets.Method)]
public sealed class AutoDataCustomAttribute(string localization = Localizations.DefaultLocalization) 
    : AutoDataAttribute(() => new Fixture().Customize(new AllCustomization(localization)))
{
}

/// <summary>
/// AutoMoq customization
/// </summary>
[AttributeUsage(AttributeTargets.Method)]
public sealed class AutoMoqDataAttribute()
    : AutoDataAttribute(() => new Fixture().Customize(new AutoMoqCustomization()));
