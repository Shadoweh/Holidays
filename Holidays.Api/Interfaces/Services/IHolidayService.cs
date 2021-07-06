using Holidays.Api.Models.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Holidays.Api.Interfaces.Services
{
    public interface IHolidayService
    {
        Task<IEnumerable<string>> GetCountries();
        Task<IEnumerable<HolidaysByMonthResponseModel>> GetHolidaysGrouppedByMonth(string country, string region, int year);
    }
}
