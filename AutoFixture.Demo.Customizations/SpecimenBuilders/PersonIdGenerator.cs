using System.Reflection;
using AutoFixture.Demo.Entities;

namespace AutoFixture.Demo.Customizations.SpecimenBuilders;

internal class PersonIdGenerator
    : PropertyGeneratorBase, ISpecimenBuilder
{
    public PersonIdGenerator(string localization = Localizations.DefaultLocalization)
        : base(localization)
    {

    }

    /// <summary>
    /// Here we are defining how variables with type PersonID should be generated.
    /// </summary>
    /// <param name="request"></param>
    /// <param name="context"></param>
    /// <returns></returns>
    public object Create(object request, ISpecimenContext context)
    {
        if (!IsPropertyOfType(request, typeof(PersonID)))
            return new NoSpecimen();

        var generatedId = Guid.NewGuid()
            .ToString()
            .Replace("-", string.Empty)
            .Select(c => c.ToString())
            .OrderBy(_ => Guid.NewGuid())
            .Take(10)
            .Aggregate((a, b) => a.ToUpper() + b.ToUpper());

        return new PersonID(generatedId);
    }
}

