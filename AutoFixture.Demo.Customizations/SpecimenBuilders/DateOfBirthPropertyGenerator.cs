namespace AutoFixture.Demo.Customizations.SpecimenBuilders;

internal class DateOfBirthPropertyGenerator 
    : PropertyGeneratorBase, ISpecimenBuilder
{
    public object Create(object request, ISpecimenContext context)
    {
        if (!IsDateOfBirthProperty(request))
            return new NoSpecimen();

        var now = DateTime.Now;

        var generatedDateTime = Faker.Date.Between(now.AddYears(-100), now.AddDays(-1));
            
        return generatedDateTime;
    }
}

 