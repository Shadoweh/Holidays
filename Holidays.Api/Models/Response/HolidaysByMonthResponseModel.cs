using System.Collections.Generic;

namespace Holidays.Api.Models.Response
{
    public class HolidaysByMonthResponseModel
    {
        public int Month { get; set; }
        public IEnumerable<HolidayResponseModel> Holidays { get; set; }
    }
}
