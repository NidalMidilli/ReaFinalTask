using BusinessLayer.Abstract;
using BusinessLayer.Validations;
using DataAccess.Concrete;
using EntityLayer;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ReaFinalTaskAdmin.Controllers
{
    public class LoginController : Controller
    {
        IUserService userService;
        Context con = new Context();
        public LoginController(IUserService userService)
        {
            this.userService = userService;
        }
        [HttpGet]
        public IActionResult LoginPanel(string returnUrl)
        {
            TempData["returnUrl"] = returnUrl;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> LoginPanel(User user)
        {
            var values = con.Users.FirstOrDefault(x => x.userName == user.userName && x.password == user.password);
            if (values != null)
            {
                var claims = new List<Claim> {
                    new Claim(ClaimTypes.Name, values.userName),
                    new Claim(ClaimTypes.Role,values.userRole)
                };
                var identity = new ClaimsIdentity(claims, "Login");

                ClaimsPrincipal claimprincipal = new ClaimsPrincipal(identity);
                await HttpContext.SignInAsync(claimprincipal);

                if (TempData["returnUrl"] != null)
                {
                    if (Url.IsLocalUrl(TempData["returnUrl"].ToString()))
                    {
                        return Redirect(TempData["returnUrl"].ToString());
                    }
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            return View();
        }
        [HttpGet]
        public IActionResult RegisterPanel()
        {
            return View();
        }
        [HttpPost]
        public IActionResult RegisterPanel(User user)
        {
            UserValidator userValidator = new UserValidator();
            ValidationResult results = userValidator.Validate(user);

            userService.AddUser(user);
            return RedirectToAction("LoginPanel");

        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
