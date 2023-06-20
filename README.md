# AutoFixture.Demo

This project demonstrates how AutoFixture can be used to generate test data
for our unit tests. 

Furthermore, customizaton of the AutoFixture pipeline is also demonstated. 
For generation of 'fake' data [Bogus](https://github.com/bchavez/Bogus) is used. This can also be of course, adjusted
as per own needs.

See 
```cs
AutoFixture.Demo.Customizations.SpecimenBuilders.PersonIdGenerator
```
for a custom implementation and other classes in Namspace
```cs
AutoFixture.Demo.Customizations.SpecimenBuilders
```
uses Bogus for simplification. 

Note that in a real world scenario such custmomization of the AutoFixture pipeline
is completely unnecessary and defeates the purpose of using AutoFixture. This is done
here only for demonstration purposes.

For Assertions ([FluentAssertions](https://fluentassertions.com/)) is used. Please refer
to the use of extension methods for assertions.

