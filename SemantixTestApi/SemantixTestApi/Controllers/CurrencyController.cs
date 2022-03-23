using Microsoft.AspNetCore.Mvc;
using SemantixTestApi.Services.Contract;
using SemantixTestApi.Shared.Enum;

namespace SemantixTestApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CurrencyController : ControllerBase
    {
        private readonly ICurrencyService _service;

        public CurrencyController(ICurrencyService service) => _service = service;

        [HttpGet("Dolar")]
        public async Task<IActionResult> Dolar() => await GetResult(CurrencyType.USD);

        [HttpGet("Euro")]
        public async Task<IActionResult> Euro() => await GetResult(CurrencyType.EUR);

        [HttpGet("Libra")]
        public async Task<IActionResult> Libra() => await GetResult(CurrencyType.GBP);

        private async Task<IActionResult> GetResult(CurrencyType type)
        {
            try
            {
                var result = await _service.GetCurrencyAsync(type);

                if (result is null) return NotFound();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}