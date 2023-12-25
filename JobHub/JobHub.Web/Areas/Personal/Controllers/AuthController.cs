using JobHub.BLL.WrapperQuery;
using JobHub.Web.Areas.Personal.Models;
using JobHub.Web.Configuration;
using JobHub.Web.Helpers;
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
                HttpContext.Response.Cookies.Append("userName", CryptographyHelper.Encrypt(user.Name));
                HttpContext.Response.Cookies.Append("userEmail", CryptographyHelper.Encrypt(user.Email));
                HttpContext.Response.Cookies.Append("userID", CryptographyHelper.Encrypt(user.ID.ToString()));
                return Redirect("/");
            }
            return View("~/Areas/Personal/Views/Auth/Login.cshtml");
        }

        [HttpPost]
        public IActionResult SignUp(UserModel model)
        {
            var userModel = Mapper.Map(model);
            WrapperQuery.WrapperAuth.WritePasswordCredential(userModel);
            HttpContext.Response.Cookies.Append("userName", CryptographyHelper.Encrypt(model.Name));
            HttpContext.Response.Cookies.Append("userEmail", CryptographyHelper.Encrypt(model.Email));
            HttpContext.Response.Cookies.Append("userID", CryptographyHelper.Encrypt(model.ID.ToString()));
            return Redirect("/");
        }

        public RedirectResult SignOut()
        {
            Response.Cookies.Delete("userName");
            Response.Cookies.Delete("userEmail");
            Response.Cookies.Delete("userID");
            return Redirect("/");
        }
    }
}
