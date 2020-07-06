using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShopCore31.Application.OrdersAdmin;
using System.Threading.Tasks;

namespace ShopCore31.UI.Controllers
{
    [Route("[controller]")]
    [Authorize(Policy = "Manager")]
    public class OrdersController : Controller
    {
        // Methods for Orders

        [HttpGet("")]
        public IActionResult GetOrders(
            int status,
            [FromServices] GetOrders getOrders) =>
                Ok(getOrders.Do(status));

        [HttpGet("{id}")]
        public IActionResult GetOrder(
            int id,
            [FromServices] GetOrder getOrder) =>
                Ok(getOrder.Do(id));

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrder(
            int id,
            [FromServices] UpdateOrder updateOrder)
        {
            var success = await updateOrder.DoAsync(id) > 0;

            if (success)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
