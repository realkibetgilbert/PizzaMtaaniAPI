using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PizzaMtaani.Application;
using PizzaMtaani.Domain;
using System.Text;

namespace PizzaMtaani.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzaController : ControllerBase
    {
        private readonly ILogger<PizzaController> _logger;

        private readonly IPizzaOrderService _pizzaOrderService;
        public PizzaController(ILogger<PizzaController> logger,IPizzaOrderService pizzaOrderService)
        {
            _logger = logger;

            _pizzaOrderService = pizzaOrderService;
        }

        [HttpPost("pizza-order")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult PlacePizzaOrder(List<PizzaOrder> orders)
        {
            _logger.LogError(JsonConvert.SerializeObject(orders));

            if(!ModelState.IsValid)
            {
                return StatusCode(400);
            }

            try
            {
                var receipt = _pizzaOrderService.CalculatePrice(orders);

                return Ok(receipt.ToString());  
                
            }
            catch (Exception ex)
            {
                _logger.LogError(JsonConvert.SerializeObject(ex));

                return StatusCode(500);
            }
        }
    }
}
