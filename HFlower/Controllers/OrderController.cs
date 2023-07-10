using HFlower.Areas.Identity.Data;
using HFlower.Infrastructure;
using HFlower.Models;
using Microsoft.AspNetCore.Mvc;

namespace HFlower.Controllers
{
    public class OrderController : Controller
    {
        private readonly HFlowerContext _context;

        public OrderController(HFlowerContext hFlowerContext) {
            _context = hFlowerContext;
        }
        public IActionResult Index()
        {
            List<Flower> flowers = HttpContext.Session.GetJson<List<Flower>>("Flowers");
            string message = TempData["Message"] as string;
            ViewBag.Message = message;
            return View(flowers);
        }
    }
}
