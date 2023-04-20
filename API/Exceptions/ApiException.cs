using System.Globalization;

namespace API.Exceptions;

public class ApiException : Exception
{
    public int Code { get; set; } = 500;
    public object Errors { get; set; }

    public ApiException(string message) :
        base(string.Format(CultureInfo.CurrentCulture, message))
    {
    }
}