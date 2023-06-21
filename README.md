# AutoFixture.Demo

This project demonstrates how AutoFixture can be used to generate test data
for our unit tests. 

Furthermore, customization of the AutoFixture pipeline is also demonstrated. 
For generation of 'fake' data [Bogus](https://github.com/bchavez/Bogus) is used. This can also be of course, adjusted
as per own needs.

See 
```cs
AutoFixture.Demo.Customizations.SpecimenBuilders.PersonIdGenerator
```
for a custom implementation and other classes in Namespace
```cs
AutoFixture.Demo.Customizations.SpecimenBuilders
```
uses Bogus for simplification. 

> :warning: **Note:** In a real world scenario such customization of the AutoFixture pipeline
is completely unnecessary and defeats the purpose of using AutoFixture. This is done
here only for demonstration purposes.

For Assertions [FluentAssertions](https://fluentassertions.com/) is used. Please refer
to the use of extension methods for assertions in the following namespace-

```cs
AutoFixture.Demo.Tests.AssertionHelpers
```

Have fun writing better tests with AutoFixture and FluentAssertions. 