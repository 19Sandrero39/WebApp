using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Data;
using Domain.Entities;
using System.Linq;

namespace Web.Controllers
{
    public class BasketsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BasketsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: BasketsController
        public ActionResult Index()
        {
            var baskets = _context.Baskets
                .Include(b => b.BasketProducts)
                .ThenInclude(bp => bp.Product)
                .ToList();
            return View(baskets);
        }

        // GET: BasketsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: BasketsController/Create
        public ActionResult Create()
        {
            ViewBag.ProductId = new SelectList(_context.Products, "Id", "Name");
            return View(new Basket());
        }

        // POST: BasketsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Basket basket, int productId, int quantity)
        {
            if (ModelState.IsValid)
            {
                // Save the basket to generate an ID
                _context.Baskets.Add(basket);
                _context.SaveChanges();

                // Получаем продукт из базы данных
                var product = _context.Products.Find(productId);

                if (product == null)
                {
                    ViewBag.ProductId = new SelectList(_context.Products, "Id", "Name", productId);
                    return View(basket);
                }

                // Создаем новую запись BasketProduct
                var basketProduct = new BasketProduct
                {
                    ProductId = productId,
                    BasketId = basket.Id,
                    Quantity = quantity,
                    // Price = product.Price, // Раскомментируйте и добавьте поле Price в BasketProduct если нужно сохранять цену
                };

                _context.BasketProducts.Add(basketProduct);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            ViewBag.ProductId = new SelectList(_context.Products, "Id", "Name", productId);
            return View(basket);
        }

        // GET: Baskets/GetProductPrice
        [HttpGet]
        public JsonResult GetProductPrice(int productId)
        {
            var product = _context.Products.Find(productId);
            if (product == null)
            {
                return Json(new { price = 0 }); // Или другой вариант обработки ошибки
            }
            return Json(new { price = product.Price });
        }


        // GET: BasketsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: BasketsController/Edit/5
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

        // GET: BasketsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: BasketsController/Delete/5
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