using FixerWrapperApi.Models;
using FixerWrapperApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace FixerWrapperApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExchangeRatesController : ControllerBase
    {
        private readonly IHttpService _httpService;

        public ExchangeRatesController(IHttpService httpService)
        {
            _httpService = httpService;
        }

        [HttpGet]
        public async Task<ActionResult> OnGet()
        {

            ExchangeRate exchangeRate = await _httpService.GetExchangeRatesAsync();
            if (exchangeRate == null)
                return NotFound();

            return Ok(exchangeRate);
        }
    }
}