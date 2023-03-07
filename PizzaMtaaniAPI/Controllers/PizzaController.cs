using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PizzaMtaani.Domain;
using System.Text;

namespace PizzaMtaani.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzaController : ControllerBase
    {
        private readonly ILogger<PizzaController> _logger;

        private readonly Dictionary<string, decimal> _sizePrices = new Dictionary<string, decimal>
    {
        { "Small", 1200.00m },
        { "Medium", 1400.00m },
        { "Large", 1600.00m }
    };

        private readonly Dictionary<string, decimal> _basicToppingPrices = new Dictionary<string, decimal>
    {
        { "Cheese", 50.00m },
        { "Pepperoni", 50.00m },
        { "Ham", 50.00m },
        { "Pineapple", 50.00m }
    };

        private readonly Dictionary<string, decimal> _deluxeToppingPrices = new Dictionary<string, decimal>
    {
        { "Sausage", 200.00m },
        { "Feta Cheese", 200.00m },
        { "Tomatoes", 200.00m },
        { "Olives", 200.00m }
    };

        public PizzaController(ILogger<PizzaController> logger)
        {
            _logger = logger;
        }

        [HttpPost("order-pizza")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult PlacePizzaOrder(List<PizzaOrder> orders)
        {
            _logger.LogError(JsonConvert.SerializeObject(orders));

            if(!ModelState.IsValid)
            {
                return StatusCode(400);
            }
             
            try
            {

                var subTotal = 0.00m;

                var output = new StringBuilder();


                foreach (var order in orders)
                {
                    if (!_sizePrices.ContainsKey(order.Size))
                    {
                        return BadRequest($"Invalid pizza size: {order.Size}");
                    }

                    var sizePrice = _sizePrices[order.Size];
                    var basicToppingPrice = 0.00m;
                    var deluxeToppingPrice = 0.00m;

                    foreach (var topping in order.Toppings)
                    {
                        if (_basicToppingPrices.ContainsKey(topping))
                        {
                            basicToppingPrice += _basicToppingPrices[topping];
                        }
                        else if (_deluxeToppingPrices.ContainsKey(topping))
                        {
                            deluxeToppingPrice += _deluxeToppingPrices[topping];
                        }
                        else
                        {
                            return BadRequest($"Invalid topping: {topping}");
                        }
                    }

                    var totalPrice = sizePrice + basicToppingPrice + deluxeToppingPrice;
                    subTotal += totalPrice;
                    output.AppendLine($"1 {order.Size}, {order.Toppings.Count} Topping Pizza - {string.Join(", ", order.Toppings)}: KES {totalPrice:F2}");
                }

                var vat = Math.Ceiling(subTotal * 0.16m);
                var total = subTotal + vat;

                output.AppendLine($"SUB-TOTAL: KES {subTotal:F2}");
                output.AppendLine($"VAT: KES {vat:F2}");
                output.AppendLine($"TOTAL: KES {total:F2}");
   
                return Ok(output.ToString());
                

              
            }
            catch (Exception ex)
            {
                _logger.LogError(JsonConvert.SerializeObject(ex));

                throw;
            }

        }
    }
}
