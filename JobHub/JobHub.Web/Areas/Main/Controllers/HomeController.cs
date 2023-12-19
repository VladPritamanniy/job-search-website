using JobHub.BLL.WrapperQuery;
using JobHub.Web.Areas.Main.Models;
using JobHub.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using JobHub.Web.Configuration;

namespace JobHub.Web.Areas.Main.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            string productName = "Tea";
            var products = WrapperQuery.WrapperProduct.GetProductsByName(productName);
            var users = Mapper.Map(products);
            var productsList = new ProductListModel() { Items = users };
            return View("~/Areas/Main/Views/Home/Index.cshtml", productsList);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}