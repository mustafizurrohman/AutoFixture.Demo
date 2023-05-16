using AutoFixture.Demo.Customizations.SpecimenBuilders;

namespace AutoFixture.Demo.Customizations.Customizations;

public class PersonCustomization : CompositeCustomization
{
    public PersonCustomization()
        : base(
            new NameCustomization(),
            new EmailCustomization(),
            new DobCustomization(),
            new PhoneNumberCustomization()
        ) {
    }

}

