using FixerWrapperApi.Models;
using FixerWrapperApi.Services.ExchangeRates;
using Microsoft.AspNetCore.Mvc;

namespace FixerWrapperApi.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ExchangeRatesController : ControllerBase
    {
        private readonly IExchangeRatesService _exchangeRatesService;

        public ExchangeRatesController(IExchangeRatesService exchangeRatesService)
        {
            _exchangeRatesService = exchangeRatesService;
        }

        [HttpGet]
        public async Task<ActionResult> GettExchangeRates()
        {
            ExchangeRate exchangeRate = await _exchangeRatesService.GetExchangeRatesAsync();
            if (exchangeRate == null)
            {
                return NotFound();
            }

            return Ok(exchangeRate);
        }
    }
}