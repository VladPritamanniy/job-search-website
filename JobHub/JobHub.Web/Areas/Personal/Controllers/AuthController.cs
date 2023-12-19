using JobHub.BLL.WrapperQuery;
using JobHub.Web.Areas.Personal.Models;
using JobHub.Web.Configuration;
using Microsoft.AspNetCore.Mvc;

namespace JobHub.Web.Areas.Personal.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Login()
        {
            return View("~/Areas/Personal/Views/Auth/Login.cshtml");
        }

        public IActionResult Registration()
        {
            return View("~/Areas/Personal/Views/Auth/Registration.cshtml");
        }

        [HttpPost]
        public IActionResult SignIn(AuthModel model)
        {
            var userModel = Mapper.Map(model);
            var isAutorize = WrapperQuery.WrapperAuth.FindPasswordCredential(userModel);
            if (isAutorize)
            {
                return RedirectToAction("Index", "Home");
            }
            return View("~/Areas/Personal/Views/Auth/Login.cshtml");
        }

        [HttpPost]
        public IActionResult SignUp(AuthModel model)
        {
            var userModel = Mapper.Map(model);
            WrapperQuery.WrapperAuth.WritePasswordCredential(userModel);
            return RedirectToAction("Index", "Home");
        }
    }
}
