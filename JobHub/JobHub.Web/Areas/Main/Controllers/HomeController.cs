using JobHub.BLL.WrapperQuery;
using JobHub.Web.Areas.Main.Models;
using JobHub.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using JobHub.Web.Configuration;
using dotless.Core.Parser.Tree;
using JobHub.Web.Helpers;

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
            var vacancies = WrapperQuery.WrapperVacancy.GetList();
            var vacanciesMap = Mapper.Map(vacancies);
            var vacanciesList = new VacancyListModel() { Items = vacanciesMap };
            return View("~/Areas/Main/Views/Home/Index.cshtml", vacanciesList);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}