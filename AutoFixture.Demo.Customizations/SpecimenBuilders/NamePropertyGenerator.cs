namespace AutoFixture.Demo.Customizations.SpecimenBuilders;

internal sealed class NamePropertyGenerator(string localization = Localizations.DefaultLocalization)
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