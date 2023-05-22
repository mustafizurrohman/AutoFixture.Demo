using Humanizer;
using Humanizer.Localisation;

namespace AutoFixture.Demo.Core.ExtensionMethods;

public static class DateTimeExtensions
{
    public static string GetAgeAsString(this DateTime dateOfBirth)
    {
        var timeDiffInMilliseconds = (DateTime.Now - dateOfBirth).TotalMilliseconds;

        return TimeSpan.FromMilliseconds(timeDiffInMilliseconds)
            .Humanize(maxUnit: TimeUnit.Year, minUnit: TimeUnit.Day, precision: 3);
    }
}
