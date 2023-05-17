﻿namespace AutoFixture.Demo.Customizations.SpecimenBuilders;

internal class StreetPropertyGenerator
    : PropertyGeneratorBase, ISpecimenBuilder
{
    public object Create(object request, ISpecimenContext context)
    {
        if (!IsStreetProperty(request))
            return new NoSpecimen();

        return Faker.Address.StreetAddress();
    }
}
