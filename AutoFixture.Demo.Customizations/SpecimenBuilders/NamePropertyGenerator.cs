﻿using System.Reflection;

namespace AutoFixture.Demo.Customizations.SpecimenBuilders;

public class NamePropertyGenerator 
    : PropertyGeneratorBase, ISpecimenBuilder
{    
    public object Create(object request, ISpecimenContext context)
    {
        if (request is not PropertyInfo propertyInfo)
            return new NoSpecimen();

        var isStringProperty = propertyInfo.PropertyType == typeof(string);

        if (!isStringProperty) 
            return new NoSpecimen();
        
        if (propertyInfo.Name.Contains("firstName", StringComparison.InvariantCultureIgnoreCase))
            return Faker.Name.FirstName();
        
        if (propertyInfo.Name.Contains("lastName", StringComparison.InvariantCultureIgnoreCase))
            return Faker.Name.LastName();
        
        //if (propertyInfo.Name.Contains("name", StringComparison.InvariantCultureIgnoreCase))
        //    return Faker.Name.FirstName() + " " + Faker.Name.LastName();
        
        return new NoSpecimen();

    }
}

