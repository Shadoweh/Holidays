using Holidays.Api.Exceptions;
using Holidays.Api.Interfaces.Repositories;
using Holidays.Api.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Holidays.Api.Repositories
{
    public class HolidayRepository : IHolidayRepository
    {
        private readonly HttpClient _holidayHttpClient;

        public HolidayRepository(HttpClient holidayHttpClient)
        {
            _holidayHttpClient = holidayHttpClient;
        }

        public async Task<IEnumerable<CountryModel>> GetCountries()
        {
            var response = await _holidayHttpClient.GetAsync("?action=getSupportedCountries");
            if (!response.IsSuccessStatusCode)
            {
                throw new HolidayApiException("Failed to retrieve supported countries");
            }

            var content = await response.Content.ReadAsStringAsync();
            var countries = JsonConvert.DeserializeObject<IEnumerable<CountryModel>>(content);

            return countries;
        }

        public async Task<IEnumerable<HolidayModel>> GetHolidaysByCountryAndYear(string country, string region, int year)
        {
            var paramsQuery = new StringBuilder($"?action=getHolidaysForYear&year={year}&country={country}");
            if (!string.IsNullOrEmpty(region))
            {
                paramsQuery.Append($"&region={region}");
            }

            paramsQuery.Append("&holidayType=public_holiday");
            var response = await _holidayHttpClient.GetAsync(paramsQuery.ToString());
            if (!response.IsSuccessStatusCode)
            {
                throw new HolidayApiException("Failed to retrieve holidays");
            }

            var content = await response.Content.ReadAsStringAsync();
            var holidays = JsonConvert.DeserializeObject<IEnumerable<HolidayModel>>(content);

            return holidays;
        }
    }
}
