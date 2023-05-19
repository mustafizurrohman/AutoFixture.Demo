﻿// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable ClassNeverInstantiated.Global

using AutoFixture.Demo.Core.ExtensionMethods;
using Humanizer;
using Humanizer.Localisation;

namespace AutoFixture.Demo.Models; 

/// <summary>
/// Primitive obsession in this class.
/// Will remain to just demonstrate some features of AutoFixture
/// </summary>
public class Person
{
    private static DateTime Now => DateTime.Now;

    public string FirstName { get; set; } 
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }

    public DateTime CreatedOn = Now;
    
    public string FullName => FirstName + " " + LastName;

    public string Age => DateOfBirth.GetTimeDiffAsString();

    public Person(string firstName, string lastName, DateTime dateOfBirth)
    {
        FirstName = firstName ?? throw new ArgumentNullException(nameof(firstName));
        LastName = lastName ?? throw new ArgumentNullException(nameof(lastName));
        DateOfBirth = dateOfBirth;
    }

    public void UpdateDateOfBirth(DateTime updatedDob)
    {
        if (updatedDob > CreatedOn)
            throw new ArgumentException("Person must have Date of birth before the entry was created");

        if (updatedDob > Now)
            throw new ArgumentException("Person cannot have Date of birth in the future");

        DateOfBirth = updatedDob;
    }
    
    public override string ToString()
    {
        return FullName;
    }
}
