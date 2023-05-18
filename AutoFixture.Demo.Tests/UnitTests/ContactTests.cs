﻿namespace AutoFixture.Demo.Tests.UnitTests;

public class ContactTests
{
    [Theory]
    [AutoDataCustom("fr")]
    // [AutoDataContact]
    public void VerifyThatContactsAreCorrectlyGenerated(List<Contact> contacts)
    {
        using (new AssertionScope())
        {
            contacts
                .Should()
                .NotBeNull();
        }
    }
}

