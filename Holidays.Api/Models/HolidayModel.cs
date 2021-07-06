using System.Collections.Generic;

namespace Holidays.Api.Models
{
    public class HolidayModel
    {
        public HolidayDateModel Date { get; set; }
        public IEnumerable<HolidayNameModel> Name { get; set; }
        public string HolidayType { get; set; }
    }
}
