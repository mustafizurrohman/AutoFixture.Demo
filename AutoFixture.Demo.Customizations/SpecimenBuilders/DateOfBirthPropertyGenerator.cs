using System.Reflection;

namespace AutoFixture.Demo.Customizations.SpecimenBuilders;

public class DateOfBirthPropertyGenerator : PropertyGeneratorBase, ISpecimenBuilder
{
    public object Create(object request, ISpecimenContext context)
    {
        if (!IsStringProperty(context))
            return new NoSpecimen();

        var propName = GetPropertyName(request);

        var isDobProperty = propName.Contains("date", StringComparison.InvariantCultureIgnoreCase)
                            && propName.Contains("birth", StringComparison.InvariantCultureIgnoreCase);

        if (!isDobProperty)
            return new NoSpecimen();

        var randomTest = new Random();

        var timeSpan = DateTime.Now - DateTime.Now.AddYears(-60);
        var newSpan = new TimeSpan(0, randomTest.Next(0, (int)timeSpan.TotalMinutes), 0);
        var newDate = DateTime.Now.AddYears(-60) + newSpan;

        return newDate;


    }
}

