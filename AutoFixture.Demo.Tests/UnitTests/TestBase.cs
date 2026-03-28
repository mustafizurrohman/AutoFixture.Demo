// ReSharper disable MemberCanBePrivate.Global
namespace AutoFixture.Demo.Tests.UnitTests;

public abstract class TestBase(ITestOutputHelper outputHelper)
{

    /// <summary>
    /// Prints an object in as formatted JSON in Test Console (only in Debug mode)
    /// </summary>
    /// <param name="obj">Object to print</param>
    protected void PrintObjectInDebug(object obj)
    {
#if DEBUG
        outputHelper.WriteLine(obj.ToFormattedJsonFailSafe());
#endif
    }
}
