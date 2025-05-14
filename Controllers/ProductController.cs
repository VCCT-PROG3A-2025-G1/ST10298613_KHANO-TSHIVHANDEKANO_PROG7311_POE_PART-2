using Microsoft.AspNetCore.Mvc;
using PROG7311_POE_PART_2.Models;
using PROG7311_POE_PART_2.Services;

namespace PROG7311_POE_PART_2.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductService _productService;
        private readonly FarmerService _farmerService;

        public ProductController(ProductService productService, FarmerService farmerService)
        {
            _productService = productService;
            _farmerService = farmerService;
        }

        // Farmer dashboard: view own products
        public async Task<IActionResult> Dashboard()
        {
            if (HttpContext.Session.GetString("Role") != "Farmer")
                return RedirectToAction("Login", "Auth");

            int farmerId = HttpContext.Session.GetInt32("UserId") ?? 0;
            var products = await _productService.GetProductsByFarmerIdAsync(farmerId);
            return View(products);
        }

        public IActionResult Add()
        {
            if (HttpContext.Session.GetString("Role") != "Farmer")
                return RedirectToAction("Login", "Auth");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(Product product)
        {
            if (HttpContext.Session.GetString("Role") != "Farmer")
                return RedirectToAction("Login", "Auth");

            product.FarmerId = HttpContext.Session.GetInt32("UserId") ?? 0;
            await _productService.AddProductAsync(product);
            return RedirectToAction("Dashboard");
        }

        // For employees to view products by farmer
        public async Task<IActionResult> ViewByFarmer(int id, DateTime? startDate, DateTime? endDate, string? category)
        {
            if (HttpContext.Session.GetString("Role") != "Employee")
                return RedirectToAction("Login", "Auth");

            ViewBag.Farmer = await _farmerService.GetFarmerByIdAsync(id);
            var filteredProducts = await _productService.FilterProductsAsync(id, startDate, endDate, category);
            return View(filteredProducts);
        }
    }
}
