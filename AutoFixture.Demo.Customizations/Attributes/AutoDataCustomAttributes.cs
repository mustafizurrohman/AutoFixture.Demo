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
/// Customizations for person
/// </summary>
[AttributeUsage(AttributeTargets.Method)]
public sealed class AutoDataPersonAttribute(string localization = Localizations.DefaultLocalization) 
    : AutoDataAttribute(() => new Fixture().Customize(new PersonCustomization(localization)))
{
}

/// <summary>
/// Customizations for Contact
/// </summary>
[AttributeUsage(AttributeTargets.Method)]
public sealed class AutoDataContactAttribute(string localization = Localizations.DefaultLocalization) 
    : AutoDataAttribute(() => new Fixture().Customize(new ContactCustomization(localization)))
{
}

/// <summary>
/// AutoMoq customization
/// </summary>
[AttributeUsage(AttributeTargets.Method)]
public sealed class AutoMoqDataAttribute()
    : AutoDataAttribute(() => new Fixture().Customize(new AutoMoqCustomization()));
