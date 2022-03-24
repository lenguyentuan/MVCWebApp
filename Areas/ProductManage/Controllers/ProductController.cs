using System.Collections.Generic;
using System.Linq;
using App.Models;
using App.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace App.Controllers
{
    [Area("ProductManage")]
    public class ProductController : Controller
    {
        private readonly ILogger<ProductController> _logger;
        private readonly ProductInitService _productService;
        [TempData]
        public string StatusMessage { set; get; }
        public ProductController(ILogger<ProductController> logger, ProductInitService productService)
        {
            _logger = logger;
            _productService = productService;
        }
        public IActionResult Index()
        {
            var products = _productService.ToList();
            return View(products);
        }
        public IActionResult Detail(int? id)
        {
            if (id == null) return NotFound($"Can not find product has Id = {id}");
            var product = _productService.Where(p => p.Id == id).FirstOrDefault();
            if (product == null)
            {
                StatusMessage = $"Can not find product has id = {id}";
                return Redirect("/Product/Index");
            }
            return View(product);
        }
    }
}