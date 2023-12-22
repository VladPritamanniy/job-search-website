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
            var mappedModel = Mapper.Map(model);
            var userModel = WrapperQuery.WrapperAuth.FindPasswordCredential(mappedModel);
            var user = Mapper.Map(userModel);
            if (user != null)
            {
                HttpContext.Response.Cookies.Append("userName", user.Name);
                return Redirect("/");
            }
            return View("~/Areas/Personal/Views/Auth/Login.cshtml");
        }

        [HttpPost]
        public IActionResult SignUp(AuthModel model)
        {
            var userModel = Mapper.Map(model);
            WrapperQuery.WrapperAuth.WritePasswordCredential(userModel);
            HttpContext.Response.Cookies.Append("userName", userModel.Name);
            return Redirect("/");
        }
    }
}
