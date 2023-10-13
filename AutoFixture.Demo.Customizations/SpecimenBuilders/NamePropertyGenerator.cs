namespace AutoFixture.Demo.Customizations.SpecimenBuilders;

internal class NamePropertyGenerator(string localization = Localizations.DefaultLocalization)
        : PropertyGeneratorBase(localization), ISpecimenBuilder
{
    public object Create(object request, ISpecimenContext context)
    {
        if (IsFirstNameProperty(request))
            return Faker.Name.FirstName();
        
        if (IsLastNameProperty(request))
            return Faker.Name.LastName();
        
        return new NoSpecimen();
    }
}
