using Holidays.Api.Interfaces.Repositories;
using Holidays.Api.Interfaces.Services;
using Holidays.Api.Models;
using Holidays.Api.Models.Response;
using System;
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

        public async Task<IEnumerable<HolidaysByMonthResponseModel>> GetHolidaysGrouppedByMonth(string country, string region, int year)
        {
            var holidays = await _holidayRepository.GetHolidaysByCountryAndYear(country, region, year);
            var holidaysByMonth = holidays.GroupBy(x => x.Date.Month);
            var result = holidaysByMonth.Select(x => new HolidaysByMonthResponseModel
            {
                Month = x.Key,
                Holidays = x.Select(y => new HolidayResponseModel
                {
                    Date = new DateTime(y.Date.Year, y.Date.Month, y.Date.Day),
                    Name = (y.Name.FirstOrDefault(z => z.Language == "en") ?? y.Name.First()).Name
                })
            });

            return result;
        }
    }
}
