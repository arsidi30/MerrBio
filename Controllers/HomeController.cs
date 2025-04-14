using Microsoft.AspNetCore.Mvc;
using FarmIt.Repositories.Abstract;
using FarmIt.Respositories.Abstract;
using FarmIt.Respositories.Implimentation;
using FarmIt.Repositories.Implementation;

namespace FarmIt.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRecepiesService _productService;
        
        public HomeController(IRecepiesService productService)
        {
            _productService = productService;
            
        }
        public IActionResult Index()
        {
            
           
            return View();
        }

        public IActionResult About()
        {
            

            return View();
            

        }
        public IActionResult Produkte(string term = "", int currentPage = 1)
        {
            var products = _productService.List(term, true, currentPage);

            return View(products);

        }

        public IActionResult ProductDetail(int productId)
        {
            var product = _productService.GetById(productId);
            return View(product);
        }

        
       
    }
}

