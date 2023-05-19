// ReSharper disable MemberCanBePrivate.Global
namespace AutoFixture.Demo.Tests.UnitTests;

public abstract class TestBase
{
    protected ITestOutputHelper OutputHelper { get; }

    protected TestBase(ITestOutputHelper outputHelper)
    {
        OutputHelper = outputHelper;
    }

    protected void PrintObject(object obj)
    {
        OutputHelper.WriteLine(obj.ToFormattedJsonFailSafe());
    }
}

