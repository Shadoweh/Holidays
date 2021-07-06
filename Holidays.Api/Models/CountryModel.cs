using System;
using System.Collections.Generic;

namespace Holidays.Api.Models
{
    public class CountryModel
    {
        public string CountryCode { get; set; }
        public IEnumerable<string> Regions { get; set; }
        public IEnumerable<string> HolidayTypes { get; set; }
        public string FullName { get; set; }
        public HolidayDateModel FromDate { get; set; }
        public HolidayDateModel ToDate { get; set; }
    }
}
