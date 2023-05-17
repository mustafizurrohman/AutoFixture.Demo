using System.Reflection;

namespace AutoFixture.Demo.Customizations.SpecimenBuilders;

public class NamePropertyGenerator 
    : PropertyGeneratorBase, ISpecimenBuilder
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

