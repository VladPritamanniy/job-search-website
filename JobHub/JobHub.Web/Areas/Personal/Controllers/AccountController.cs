using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JobHub.Web.Areas.Personal.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Resumes()
        {
            return View("~/Areas/Personal/Views/Account/Resumes.cshtml");
        }

        public IActionResult FavoriteVacancies()
        {
            return View("~/Areas/Personal/Views/Account/FavoriteVacancies.cshtml");
        }

        public IActionResult ChangePassword()
        {
            return View("~/Areas/Personal/Views/Account/ChangePassword.cshtml");
        }
    }
}
