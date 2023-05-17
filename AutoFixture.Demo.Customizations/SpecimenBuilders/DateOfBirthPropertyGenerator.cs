﻿namespace AutoFixture.Demo.Customizations.SpecimenBuilders;

public class DateOfBirthPropertyGenerator 
    : PropertyGeneratorBase, ISpecimenBuilder
{
    public object Create(object request, ISpecimenContext context)
    {
        if (!IsDateOfBirthProperty(request))
            return new NoSpecimen();

        var randomTest = new Random();

        var timeSpan = DateTime.Now - DateTime.Now.AddYears(-60);
        var newSpan = new TimeSpan(0, randomTest.Next(0, (int)timeSpan.TotalMinutes), 0);
        var newDate = DateTime.Now.AddYears(-60) + newSpan;

        return newDate;


    }
}

 