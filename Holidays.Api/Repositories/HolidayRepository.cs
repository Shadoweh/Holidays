using Holidays.Api.Exceptions;
using Holidays.Api.Interfaces.Repositories;
using Holidays.Api.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
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
    }
}
