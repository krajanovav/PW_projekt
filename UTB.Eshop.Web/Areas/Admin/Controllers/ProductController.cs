using Microsoft.AspNetCore.Mvc;
using System.Data.Common;
using UTB.Eshop.Application.Abstraction;
using UTB.Eshop.Domain.Entities;
using UTB.Eshop.Infrastructure.Database;

namespace UTB.Eshop.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IProductAdminService _productAdminService;

        public ProductController(IProductAdminService productAdminService)
        {
            _productAdminService = productAdminService;
        }

        public IActionResult Index()
        {
            IList<Product> products = _productAdminService.Select();
            var sortedList=DatabaseFake.Products.OrderBy(x => x.Id).ToList();
            return View(sortedList);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int Id)
        {
            // Získání produktu z databáze
            var std = DatabaseFake.Products.Where(s => s.Id == Id).FirstOrDefault();

            return View(std);
        }

        [HttpPost]
        public IActionResult Edit(Product product)
        {
            // Aktualizace produktu v databázi
            _productAdminService.Edit(product);
            
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            _productAdminService.Create(product);

            return RedirectToAction(nameof(Index));
        }

        
        public IActionResult Delete(int Id)
        {
            bool deleted = _productAdminService.Delete(Id);

            if (deleted)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return NotFound();
            }
        }
    }
}
