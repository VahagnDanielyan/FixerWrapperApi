using FixerWrapperApi.Models;
using FixerWrapperApi.Services.ExchangeRates;
using Microsoft.AspNetCore.Mvc;

namespace FixerWrapperApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExchangeRatesController : ControllerBase
    {
        private readonly IExchangeRatesService _exchangeRatesService;

        public ExchangeRatesController(IExchangeRatesService exchangeRatesService)
        {
            _exchangeRatesService = exchangeRatesService;
        }

        [HttpGet("{baseCurrency}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ExchangeRate>> GetExchangeRatesAsync(string baseCurrency)
        {
            Symbols symbols = await _exchangeRatesService.GetSupportedSymbolsAsync();
            if (!symbols.IsValid(baseCurrency))
            {
                return NotFound($"Invalid baseCurrency - {baseCurrency}");
            }

            ExchangeRate exchangeRate = await _exchangeRatesService.GetExchangeRatesAsync(baseCurrency);
            if (!exchangeRate.Success)
            {
                return BadRequest($"Code - {exchangeRate.Error.Code}, Info - {exchangeRate.Error.Info}");
            }

            return exchangeRate;
        }
    }
}