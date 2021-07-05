using Holidays.Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Holidays.Api.Interfaces.Repositories
{
    public interface IHolidayRepository
    {
        Task<IEnumerable<CountryModel>> GetCountries();
    }
}
