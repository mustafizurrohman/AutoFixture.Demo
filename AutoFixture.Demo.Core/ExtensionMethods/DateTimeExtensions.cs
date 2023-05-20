using Humanizer;
using Humanizer.Localisation;

namespace AutoFixture.Demo.Core.ExtensionMethods;

public static class DateTimeExtensions
{
    public static string GetTimeDiffAsString(this DateTime dateTime)
    {
        var timeDiffInMilliseconds = (DateTime.Now - dateTime).TotalMilliseconds;

        return TimeSpan.FromMilliseconds(timeDiffInMilliseconds)
            .Humanize(maxUnit: TimeUnit.Year, minUnit: TimeUnit.Day, precision: 3);
    }
}
