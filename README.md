# AutoFixture.Demo

This project demonstrates how AutoFixture can be used to generate test data
for our unit tests. 

Furthermore, customizaton of the AutoFixture pipeline is also demonstated. 
For generation of 'fake' data Bogus is used. This can also be of course, adjusted
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


