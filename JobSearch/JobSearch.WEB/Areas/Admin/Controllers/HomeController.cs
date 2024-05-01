using JobSearch.BLL.DTO;
using JobSearch.BLL.Interfaces;
using JobSearch.WEB.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace JobSearch.WEB.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class HomeController : Controller
	{
        private readonly IUserService _userService;
        private readonly IOptions<JwtOptions> _options;

        public HomeController(IUserService userService, IOptions<JwtOptions> options)
        {
            _userService = userService;
            _options = options;
        }

        public IActionResult Index()
		{
			return View();
		}

        public async Task<IActionResult> Register(UserViewModel userModel)
        {
            await _userService.Register("admin@gmail.com", "qwerty");
            return View("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(UserViewModel userModel)
        {
            if (ModelState.IsValid)
            {
                var tokens = await _userService.Login(userModel.Email, userModel.Password);

                if (!string.IsNullOrEmpty(tokens.AccessToken) && !string.IsNullOrEmpty(tokens.RefreshToken))
                {
                    var cookieOptions = new CookieOptions
                    {
                        HttpOnly = true,
                        Secure = true
                    };
                    Response.Cookies.Append("tasty-cookies", tokens.AccessToken, cookieOptions);

                    cookieOptions.Expires = DateTime.UtcNow.AddDays(_options.Value.RefreshExpires);
                    Response.Cookies.Append("very-tasty-cookies", tokens.RefreshToken, cookieOptions);

                    return RedirectToAction("Index", "Vacancy");
                }
                ModelState.AddModelError(string.Empty, Resources.Resource.Error_UserNotIdentified);
            }
            return View("Index");
        }
    }
}
