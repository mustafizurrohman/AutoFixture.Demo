using AutoFixture.Demo.Customizations.Customizations;
using AutoFixture.Xunit2;

namespace AutoFixture.Demo.Customizations.Attributes;

public class AutoDataCustomAttribute : AutoDataAttribute
{
    public AutoDataCustomAttribute(string localization = "de")
        : base(() => new Fixture().Customize(new AllCustomization(localization)))
    {

    }
}

public class AutoDataPersonAttribute : AutoDataAttribute
{
    public AutoDataPersonAttribute(string localization = "de")
        : base(() => new Fixture().Customize(new PersonCustomization(localization)))
    {

    }
}

public class AutoDataContactAttribute : AutoDataAttribute
{
    public AutoDataContactAttribute(string localization = "de")
        : base(() => new Fixture().Customize(new ContactCustomization(localization)))
    {

    }
}