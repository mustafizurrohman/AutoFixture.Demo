namespace AutoFixture.Demo.Customizations.SpecimenBuilders;

internal class NamePropertyGenerator 
    : PropertyGeneratorBase, ISpecimenBuilder
{
    public NamePropertyGenerator(string localization = "de") 
        : base(localization)
    {
    }

    public object Create(object request, ISpecimenContext context)
    {
        if (IsFirstNameProperty(request))
            return Faker.Name.FirstName();
        
        if (IsLastNameProperty(request))
            return Faker.Name.LastName();
        
        return new NoSpecimen();

    }
}

