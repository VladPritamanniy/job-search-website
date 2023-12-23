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
        public IActionResult SignIn(UserModel model)
        {
            var mappedModel = Mapper.Map(model);
            var userModel = WrapperQuery.WrapperAuth.FindPasswordCredential(mappedModel);
            var user = Mapper.Map(userModel);
            if (user != null)
            {
                HttpContext.Response.Cookies.Append("userName", user.Name);
                HttpContext.Response.Cookies.Append("userEmail", user.Email);
                HttpContext.Response.Cookies.Append("userID", user.ID.ToString());
                return Redirect("/");
            }
            return View("~/Areas/Personal/Views/Auth/Login.cshtml");
        }

        [HttpPost]
        public IActionResult SignUp(UserModel model)
        {
            var userModel = Mapper.Map(model);
            WrapperQuery.WrapperAuth.WritePasswordCredential(userModel);
            HttpContext.Response.Cookies.Append("userName", model.Name);
            HttpContext.Response.Cookies.Append("userEmail", model.Email);
            HttpContext.Response.Cookies.Append("userID", model.ID.ToString());
            return Redirect("/");
        }

        public RedirectResult SignOut()
        {
            HttpContext.Response.Cookies.Append("userName", string.Empty);
            HttpContext.Response.Cookies.Append("userEmail", string.Empty);
            HttpContext.Response.Cookies.Append("userID", string.Empty);
            return Redirect("/");
        }
    }
}
