using AutoFixture.Demo.Customizations.Customizations;
using AutoFixture.Xunit2;

namespace AutoFixture.Demo.Customizations.Attributes;

public class AutoDataCustomAttribute : AutoDataAttribute
{
    public AutoDataCustomAttribute()
        : base(() => new Fixture().Customize(new AllCustomization()))
    {

    }
}

public class AutoDataPersonAttribute : AutoDataAttribute
{
    public AutoDataPersonAttribute()
        : base(() => new Fixture().Customize(new PersonCustomization()))
    {

    }
}

public class AutoDataContactAttribute : AutoDataAttribute
{
    public AutoDataContactAttribute()
        : base(() => new Fixture().Customize(new ContactCustomization()))
    {

    }
}