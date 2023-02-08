using CMS.Models;
using CMS.Services.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CMS.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;
        public AccountController(IAccountService accountService) => _accountService = accountService;

        #region Register
        public IActionResult Register() => View();

        [HttpPost]
        public IActionResult Register(RegisterViewModel registerViewModel)
        {
            if(!ModelState.IsValid) 
                return View(registerViewModel);

            if (_accountService.IsExistByEmail(registerViewModel.Email.ToLower()))
            {
                ModelState.AddModelError("Email", "The entered email is duplicate.");
                return View(registerViewModel);
            }
            if (_accountService.IsExistByUserName(registerViewModel.UserName.ToLower()))
            {
                ModelState.AddModelError("UserName", "The entered user name is duplicate.");
                return View(registerViewModel);
            }

            User user = new User()
            {
                Email = registerViewModel.Email.ToLower(),
                UserName = registerViewModel.UserName.ToLower(),
                Password= registerViewModel.Password,
                RegisterDate= DateTime.Now
            };

            _accountService.InsertUser(user);
            _accountService.Save();

            return View("SuccessRegister", user);
        }
        #endregion

        #region Login
        public IActionResult Login() => View();

        [HttpPost]
        public IActionResult Login(LoginViewModel loginViewModel)
        {
            if(!ModelState.IsValid)
                return View(loginViewModel);

            User user = _accountService.GetUserForLogin(loginViewModel.UserNameOrEmail.ToLower(), loginViewModel.Password);

            if (user == null)
            {
                ModelState.AddModelError("UserNameOrEmail", "The information entered is not correct.");
                return View(loginViewModel);
            }

            List<Claim> claims = new List<Claim>()
            {
                new Claim("UserId", user.UserId.ToString()),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim("Email", user.Email),
                new Claim("Password", user.Password)
            };

            ClaimsIdentity identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            ClaimsPrincipal principal = new ClaimsPrincipal(identity);
            AuthenticationProperties properties = new AuthenticationProperties()
            {
                IsPersistent = loginViewModel.RememberMe
            };

            HttpContext.SignInAsync(principal, properties);

            return Redirect("/");
        }

        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Redirect("/");
        }
        #endregion

        public IActionResult UserProfile()
        {
            User user = _accountService.GetUserForProfile(int.Parse(User.FindFirst("UserId").Value));
            if(user == null)
                return NotFound();

            UserProfileViewModel userProfileViewModel = new UserProfileViewModel()
            {
                UserId = user.UserId,
                UserName = user.UserName,
                Email= user.Email,
                RegisterDate = user.RegisterDate
            };

            return View(userProfileViewModel);
        }
    }
}
