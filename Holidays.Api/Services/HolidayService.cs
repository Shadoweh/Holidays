using Holidays.Api.Interfaces.Repositories;
using Holidays.Api.Interfaces.Services;
using Holidays.Api.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Holidays.Api.Services
{
    public class HolidayService : IHolidayService
    {
        private readonly IHolidayRepository _holidayRepository;

        public HolidayService(IHolidayRepository holidayRepository)
        {
            _holidayRepository = holidayRepository;
        }

        public async Task<IEnumerable<string>> GetCountries()
        {
            var countries = await _holidayRepository.GetCountries();

            return countries.Select(x => x.FullName);
        }
    }
}
