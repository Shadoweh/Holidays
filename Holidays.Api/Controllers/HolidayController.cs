using Holidays.Api.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Holidays.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]/[action]")]
    public class HolidayController : Controller
    {
        private readonly IHolidayService _holidayService;

        public HolidayController(IHolidayService holidayService)
        {
            _holidayService = holidayService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCountries()
        {
            var countries = await _holidayService.GetCountries();

            return Ok(countries);
        }

        [HttpGet]
        public async Task<IActionResult> GetHolidaysGrouppedByMonth(string country, int year, string region = null)
        {
            if (string.IsNullOrEmpty(country) || year == 0)
            {
                return BadRequest("Empty country or year");
            }

            var holidaysByMonth = await _holidayService.GetHolidaysGrouppedByMonth(country, region, year);

            return Ok(holidaysByMonth);
        }
    }
}
