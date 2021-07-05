using Holidays.Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Holidays.Api.Interfaces.Services
{
    public interface IHolidayService
    {
        Task<IEnumerable<string>> GetCountries();
    }
}
