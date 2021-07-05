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
        public async Task<IActionResult> Get()
        {
            var countries = await _holidayService.GetCountries();

            return Ok(countries);
        }
    }
}
