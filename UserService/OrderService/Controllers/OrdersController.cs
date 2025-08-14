using Microsoft.AspNetCore.Mvc;
using OrderService.DTOS;
using OrderService.Models;

namespace OrderService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly OrdersDbContext _context;
        private readonly HttpClient _httpClient;

        public OrdersController(OrdersDbContext context, IHttpClientFactory httpClientFactory)
        {
            _context = context;
            _httpClient = httpClientFactory.CreateClient();
        }
        [HttpPost]
        public async Task<IActionResult> CreateOrder(Order order)
        {
            var response = await _httpClient.GetAsync($"http://localhost:5057/api/users/{order.UserId}");

            if (!response.IsSuccessStatusCode)
                return BadRequest("User not found");

            // Nếu thành công, parse dữ liệu
            var user = await response.Content.ReadFromJsonAsync<UserDto>();

            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            return Ok(order);
        }
    }
}