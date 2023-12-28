using JobHub.BLL.WrapperQuery;
using JobHub.Web.Configuration;
using Microsoft.AspNetCore.Mvc;

namespace JobHub.Web.Areas.Main.Controllers
{
    public class InfoController : Controller
    {
        public IActionResult Vacancy(int id)
        {
            var item = WrapperQuery.WrapperVacancy.GetItem(id);
            var vacancy = Mapper.Map(item);
            return View("~/Areas/Main/Views/Info/Vacancy.cshtml", vacancy);
        }
    }
}
