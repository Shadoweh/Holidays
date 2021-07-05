using System;

namespace Holidays.Api.Exceptions
{
    public class HolidayApiException : Exception
    {
        public HolidayApiException(string message) : base(message)
        {
        }
    }
}