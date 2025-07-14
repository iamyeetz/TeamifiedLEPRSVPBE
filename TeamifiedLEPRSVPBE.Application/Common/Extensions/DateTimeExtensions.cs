using System.Globalization;

public static class DateTimeExtensions
{
    public static DateTime ParseFromJsString(this string jsDate)
    {
        int parenIndex = jsDate.IndexOf('(');
        if (parenIndex != -1)
            jsDate = jsDate.Substring(0, parenIndex).Trim();

        jsDate = jsDate.Replace("GMT", "").Trim();

        if (DateTimeOffset.TryParseExact(
            jsDate,
            "ddd MMM dd yyyy HH:mm:ss zzz",
            CultureInfo.InvariantCulture,
            DateTimeStyles.None,
            out var dto))
        {
            return dto.DateTime; 
        }

        throw new FormatException("Invalid JS date format.");
    }
}