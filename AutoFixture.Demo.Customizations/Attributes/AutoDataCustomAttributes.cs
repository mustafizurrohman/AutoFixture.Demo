using AutoFixture.AutoMoq;
using AutoFixture.Demo.Customizations.Customizations;
using AutoFixture.Xunit2;

namespace AutoFixture.Demo.Customizations.Attributes;

[AttributeUsage(AttributeTargets.Method)]
public sealed class AutoDataCustomAttribute : AutoDataAttribute
{
    public AutoDataCustomAttribute(string localization = Localizations.DefaultLocalization)
        : base(() => new Fixture().Customize(new AllCustomization(localization)))
    {

    }
}

[AttributeUsage(AttributeTargets.Method)]
public sealed class AutoDataPersonAttribute : AutoDataAttribute
{
    public AutoDataPersonAttribute(string localization = Localizations.DefaultLocalization)
        : base(() => new Fixture().Customize(new PersonCustomization(localization)))
    {

    }
}

[AttributeUsage(AttributeTargets.Method)]
public sealed class AutoDataContactAttribute : AutoDataAttribute
{
    public AutoDataContactAttribute(string localization = Localizations.DefaultLocalization)
        : base(() => new Fixture().Customize(new ContactCustomization(localization)))
    {

    }
}

// AutoMoq
[AttributeUsage(AttributeTargets.Method)]
public sealed class AutoMoqDataAttribute : AutoDataAttribute
{
    public AutoMoqDataAttribute()
        : base(() => new Fixture().Customize(new AutoMoqCustomization()))
    {

    }
}
