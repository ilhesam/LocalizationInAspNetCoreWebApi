using System.Globalization;

namespace LocalizationInAspNetCoreWebApi;

public static class Extensions
{
    public static CultureInfo GetCurrentCulture() => CultureInfo.CurrentCulture;
}