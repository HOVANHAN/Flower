using HFlower.Areas.Identity.Data;
using HFlower.Infrastructure;
using HFlower.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HFlower.Controllers
{
    public class CartController : Controller
    {
        private readonly HFlowerContext _context;

        public CartController(HFlowerContext context)
        {
            _context = context;
        }
        // GET: CartController
        public IActionResult Index()
        {
            List<Flower> flowers = HttpContext.Session.GetJson<List<Flower>>("Flowers");
            string message = TempData["Message"] as string;
            ViewBag.Message = message;
            return View(flowers);
        }

        public IActionResult AddToCart(int id)
        {
            Flower? flower = _context.Flower.FirstOrDefault(x => x.Id == id);
            if (flower != null)
            {
                List<Flower> flowers = HttpContext.Session.GetJson<List<Flower>>("Flowers") ?? new List<Flower>();

                // Check if the flower already exists in the cart
                var existingFlower = flowers.FirstOrDefault(f => f.Id == flower.Id);
                if (existingFlower != null)
                {
                    // Display a message indicating that the flower is already in the cart
                    TempData["Message"] = "The flower is already in the cart.";
                }
                else
                {

                    flowers.Add(flower);
                }

                HttpContext.Session.SetJson("Flowers", flowers);
            }

            return RedirectToAction("Index", "Cart");
        }

        public IActionResult Remove(int id)
        {
            // Retrieve the cart from the session
            List<Flower> flowers = HttpContext.Session.GetJson<List<Flower>>("Flowers");

            Flower flowerToRemove = flowers.FirstOrDefault(f => f.Id == id);

            if (flowerToRemove != null)
            {

                flowers.Remove(flowerToRemove);


                HttpContext.Session.SetJson("Flowers", flowers);
            }

            // Redirect to the cart page or any other desired page
            return RedirectToAction("Index", "Cart", new { message = "Flower added to cart" });
        }
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CartController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CartController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CartController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CartController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CartController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CartController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
