using HFlower.Areas.Identity.Data;
using HFlower.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace HFlower.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly HFlowerContext _context;
        private readonly UserManager<HFlowerUser> _userManager;

        public HomeController(ILogger<HomeController> logger, HFlowerContext context, UserManager<HFlowerUser> userManager)
        {
            _logger = logger;
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user != null) {
                ViewBag.UserName = user.UserName;
            }
            var hFlowerContext = _context.Flower.Include(f => f.categories);
            return View(await hFlowerContext.ToListAsync());
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Flower == null)
            {
                return NotFound();
            }

            var flower = await _context.Flower
                .Include(f => f.categories)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (flower == null)
            {
                return NotFound();
            }

            return View(flower);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}