using AutoFixture.Demo.Customizations.SpecimenBuilders;
using AutoFixture.Demo.Entities;

namespace AutoFixture.Demo.Customizations.Customizations;

public class NameCustomization(string localization = Localizations.DefaultLocalization) 
    : ICustomization
{
    private string Localization { get; } = localization;

    public void Customize(IFixture fixture)
    {
        ArgumentNullException.ThrowIfNull(fixture);

        fixture.Customizations.Add(new NamePropertyGenerator(Localization));
    }

    private sealed class NamePropertyGenerator(string localization = Localizations.DefaultLocalization)
        : PropertyGeneratorBase(localization), ISpecimenBuilder
    {
        private NameParts? _currentNameParts;

        public object Create(object request, ISpecimenContext context)
        {
            if (IsFirstNameProperty(request))
            {
                var nameParts = GetOrCreateNameParts();

                nameParts.FirstNameConsumed = true;
                ClearNamePartsIfConsumed();

                return nameParts.FirstName;
            }

            if (IsLastNameProperty(request))
            {
                var nameParts = GetOrCreateNameParts();

                nameParts.LastNameConsumed = true;
                ClearNamePartsIfConsumed();

                return nameParts.LastName;
            }

            return new NoSpecimen();
        }

        private NameParts GetOrCreateNameParts()
        {
            return _currentNameParts ??= CreateNameParts();
        }

        private NameParts CreateNameParts()
        {
            var fullNameParts = Faker.Name
                .FullName()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

            if (fullNameParts.Length >= 2)
            {
                return new NameParts(
                    FirstName: fullNameParts[0],
                    LastName: fullNameParts[^1]);
            }

            return new NameParts(
                FirstName: Faker.Name.FirstName(),
                LastName: Faker.Name.LastName());
        }

        private void ClearNamePartsIfConsumed()
        {
            if (_currentNameParts is { FirstNameConsumed: true, LastNameConsumed: true })
            {
                _currentNameParts = null;
            }
        }

        private sealed record NameParts(string FirstName, string LastName)
        {
            public bool FirstNameConsumed { get; set; }
            public bool LastNameConsumed { get; set; }
        }
    }
}

public class EmailCustomization(string localization = Localizations.DefaultLocalization) 
    : ICustomization
{
    private string Localization { get; } = localization;

    public void Customize(IFixture fixture)
    {
        ArgumentNullException.ThrowIfNull(fixture);

        fixture.Customizations.Add(new EmailPropertyGenerator(Localization));
    }

    private sealed class EmailPropertyGenerator(string localization = Localizations.DefaultLocalization)
        : PropertyGeneratorBase(localization), ISpecimenBuilder
    {
        public object Create(object request, ISpecimenContext context)
        {
            if (IsEmailProperty(request))
                return Faker.Internet.Email();

            return new NoSpecimen();
        }
    }

}

public class DobCustomization(string localization = Localizations.DefaultLocalization) 
    : ICustomization
{
    private string Localization { get; } = localization;

    public void Customize(IFixture fixture)
    {
        ArgumentNullException.ThrowIfNull(fixture);

        fixture.Customizations.Add(new DateOfBirthPropertyGenerator(Localization));
    }

    private sealed class DateOfBirthPropertyGenerator(string localization = Localizations.DefaultLocalization)
        : PropertyGeneratorBase(localization), ISpecimenBuilder
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
}

public class PhoneNumberCustomization(string localization = Localizations.DefaultLocalization) 
    : ICustomization
{
    private string Localization { get; } = localization;

    public void Customize(IFixture fixture)
    {
        ArgumentNullException.ThrowIfNull(fixture);

        fixture.Customizations.Add(new PhoneNumberPropertyGenerator(Localization));
    }

    private sealed class PhoneNumberPropertyGenerator(string localization = Localizations.DefaultLocalization)
        : PropertyGeneratorBase(localization), ISpecimenBuilder
    {
        public object Create(object request, ISpecimenContext context)
        {
            if (!IsPhoneNumberProperty(request))
                return new NoSpecimen();

            return Faker.Phone.PhoneNumber();
        }
    }


}

public class StreetCustomization(string localization = Localizations.DefaultLocalization) 
    : ICustomization
{
    private string Localization { get; } = localization;

    public void Customize(IFixture fixture)
    {
        ArgumentNullException.ThrowIfNull(fixture);

        fixture.Customizations.Add(new StreetPropertyGenerator(Localization));
    }

    private sealed class StreetPropertyGenerator(string localization = Localizations.DefaultLocalization)
        : PropertyGeneratorBase(localization), ISpecimenBuilder
    {
        public object Create(object request, ISpecimenContext context)
        {
            if (!IsStreetProperty(request))
                return new NoSpecimen();

            return Faker.Address.StreetAddress();
        }
    }

}

public class CityCustomization(string localization = Localizations.DefaultLocalization) 
    : ICustomization
{
    private string Localization { get; } = localization;

    public void Customize(IFixture fixture)
    {
        ArgumentNullException.ThrowIfNull(fixture);

        fixture.Customizations.Add(new CityPropertyGenerator(Localization));
    }

    private sealed class CityPropertyGenerator(string localization = Localizations.DefaultLocalization)
        : PropertyGeneratorBase(localization), ISpecimenBuilder
    {
        public object Create(object request, ISpecimenContext context)
        {
            if (!IsCityProperty(request))
                return new NoSpecimen();

            return Faker.Address.City();
        }
    }

}

public class PersonIDCustomization(string localization = Localizations.DefaultLocalization) 
    : ICustomization
{
    private string Localization { get; } = localization;

    public void Customize(IFixture fixture)
    {
        ArgumentNullException.ThrowIfNull(fixture);

        fixture.Customizations.Add(new PersonIdGenerator(Localization));
    }

    private sealed class PersonIdGenerator(string localization = Localizations.DefaultLocalization)
        : PropertyGeneratorBase(localization), ISpecimenBuilder
    {

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

            // Custom logic to generate string for PersonID
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
}

public class BoolCustomization(string localization = Localizations.DefaultLocalization) 
    : ICustomization
{
    private string Localization { get; } = localization;

    public void Customize(IFixture fixture)
    {
        ArgumentNullException.ThrowIfNull(fixture);

        fixture.Customizations.Add(new BoolPropertyGenerator(Localization));
    }

    private sealed class BoolPropertyGenerator(string localization = Localizations.DefaultLocalization)
        : PropertyGeneratorBase(localization), ISpecimenBuilder
    {
        public object Create(object request, ISpecimenContext context)
        {
            if (!IsPropertyOfType(request, typeof(bool)))
                return new NoSpecimen();

            return Faker.Random.Number(10, 1000) % 5 == 0;
        }
    }
}

public class EmailBodyCustomization(string localization = Localizations.DefaultLocalization)
    : ICustomization
{
    private string Localization { get; } = localization;

    public void Customize(IFixture fixture)
    {
        ArgumentNullException.ThrowIfNull(fixture);

        fixture.Customizations.Add(new EmailMessageBodyPropertyGenerator(Localization));
    }

    private sealed class EmailMessageBodyPropertyGenerator(string localization = Localizations.DefaultLocalization)
        : PropertyGeneratorBase(localization), ISpecimenBuilder
    {
        public object Create(object request, ISpecimenContext context)
        {
            if (!IsEmailMessageProperty(request))
                return new NoSpecimen();

            return Faker.Lorem.Paragraph(10);
        }
    }

}
