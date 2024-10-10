using Core.OrderService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BookShop.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        private readonly OrderService _orderService;
        public ProfileController(OrderService orderService)
        {
            _orderService = orderService;
        }
        public async Task< IActionResult> Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var data=await _orderService.GetUserOrders(Convert.ToInt32(userId));
            return View(data);
        }

    }
}
