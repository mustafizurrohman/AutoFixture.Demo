namespace AutoFixture.Demo.Customizations.SpecimenBuilders;

internal class EmailPropertyGenerator 
    : PropertyGeneratorBase, ISpecimenBuilder
{    
    public object Create(object request, ISpecimenContext context)
    {
        if (IsEmailProperty(request))
            return Faker.Internet.Email();

        return new NoSpecimen();
    }
}

