using System.Collections.Generic;
using System.Security.Claims;
using GAP.BussinesLogic.Contract;
using GAP.Transversal.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace GAP.View.Controllers
{
    public class AuthController : Controller
    {
        private readonly IUser iUser;
        public AuthController(IUser user)
        {
            iUser = user;
        }
        public IActionResult Index(string ReturnUrl = null)
        {
            LoginViewModel login = new LoginViewModel() { ReturnUrl = ReturnUrl };
            return View(login);
        }

        [HttpPost]
        public IActionResult Index(LoginViewModel  loginView)
        {
            if (ModelState.IsValid)
            {

                if (iUser.IsValidated(loginView))
                {
                    HttpContext.Session.SetString("User", JsonConvert.SerializeObject(loginView));

                    var userClaims = new List<Claim>()
                    {
                        new Claim(ClaimTypes.Name, "Admin"),
                    };
                    var userIdentity = new ClaimsIdentity(userClaims, "userIdentity");

                    var userPrincipal = new ClaimsPrincipal(new[] { userIdentity });

                    HttpContext.SignInAsync(userPrincipal);

                    return View("../Patient/Index");
                }
            }
            Response.Cookies.Delete("UserAdmin.Cookie");
            loginView.ErrorMessage = "User does not exist";
            return View(loginView);
        }

        public IActionResult Logout()
        {
            Response.Cookies.Delete("UserAdmin.Cookie");
            return View("../Dates/Index");
        }
    }
}