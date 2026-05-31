namespace AutoFixture.Demo.Customizations.Customizations;

public class PersonContactCustomization(
    string localization = Localizations.DefaultLocalization) : ICustomization
{
    public void Customize(IFixture fixture)
    {
        ArgumentNullException.ThrowIfNull(fixture);

        fixture.Customize<PersonContact>(composer => composer
            .FromFactory((Models.Person person, Contact contact) =>
            {
                var contactWithRelatedEmail = new Contact(
                    contact.PhoneNumber,
                    contact.Street,
                    contact.City,
                    EmailAddressFactory.CreateFor(person, localization));

                return new PersonContact(person, contactWithRelatedEmail);
            })
            .OmitAutoProperties());
    }
}