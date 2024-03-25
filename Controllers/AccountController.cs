using AuthorizationFilterDEmo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace AuthorizationFilterDEmo.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserContext context;
        public AccountController(UserContext userContext)
        {
            context = userContext;
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Login login)
        {
            if (ModelState.IsValid)
            {
                    User user = context.Users
                                       .Where(u => u.UserName == login.UserName && u.Password == login.Password)
                                       .FirstOrDefault();

                    if (user != null)
                    {
                        HttpContext.Session.SetString("UserName",user.UserName);
                        HttpContext.Session.SetString("UserId", user.UserId);
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Invalid User Name or Password");
                        return View(login);
                    }
                
            }
            else
            {
                return View(login);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            HttpContext.Session.SetString("UserName", "");
            HttpContext.Session.SetString("UserId", "");
            return RedirectToAction("Index", "Home");
        }
    }
}

