// ReSharper disable MemberCanBePrivate.Global
namespace AutoFixture.Demo.Tests.UnitTests;

public abstract class TestBase
{
    protected ITestOutputHelper OutputHelper { get; }

    protected TestBase(ITestOutputHelper outputHelper)
    {
        OutputHelper = outputHelper;
    }

    /// <summary>
    /// Prints an object in as formatted JSON in Test Console (only in Debug mode)
    /// </summary>
    /// <param name="obj">Object to print</param>
    protected void PrintObject(object obj)
    {
#if DEBUG
        OutputHelper.WriteLine(obj.ToFormattedJsonFailSafe());
#endif
    }
}
