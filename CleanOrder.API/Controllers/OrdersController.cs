using CleanOrder.Application.Services;
using CleanOrder.Domain.Entities;
using Microsoft.AspNetCore.Mvc;


namespace CleanOrder.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController:ControllerBase
    {

        private readonly OrderService _orderService;

        public OrdersController(OrderService orderService)
        {
            _orderService = orderService;
        }



        [HttpPut("{id}/ship")]
        public async Task<IActionResult> Ship(int id)
        {

            if (id <= 0)
            {
                return BadRequest("Order ID must be greater than zero.");
            }

            await _orderService.ShipOrderAsync(id);

            return NoContent();
        }



        [HttpPut("{id}/cancel")]
        public async Task<IActionResult> Cancel(int id)
        {

            if (id <= 0)
            {
                return BadRequest("Order ID must be greater than zero.");
            }

                await _orderService.CancelOrderAsync(id);

                return NoContent(); 
        }



        [HttpPost]
        public async Task<IActionResult> Create()
        {
            await _orderService.CreateOrderAsync();

            return StatusCode(201);
        }



        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var orders = await _orderService.GetAllOrdersAsync();

            return Ok(orders);
        }




        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {


            if(id <= 0)
            {
                return BadRequest("Order ID must be greater than zero.");
            }


            var order = await _orderService.GetOrderByIdAsync(id);

            if (order == null)
            {
                return NotFound();
            }

            return Ok(order);
        }






    }
}
