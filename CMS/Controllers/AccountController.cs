using CMS.Models;
using CMS.Services.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
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
            if (_accountService.IsExistByUserName(registerViewModel.UserName))
            {
                ModelState.AddModelError("UserName", "The entered user name is duplicate.");
                return View(registerViewModel);
            }

            User user = new User()
            {
                Email = registerViewModel.Email.ToLower(),
                UserName = registerViewModel.UserName,
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

            User user = _accountService.GetUserForLogin(loginViewModel.UserNameOrEmail, loginViewModel.Password);

            if (user == null)
            {
                ModelState.AddModelError("UserNameOrEmail", "The information entered is not correct.");
                return View(loginViewModel);
            }

            SignIn(user, loginViewModel.RememberMe);

            return Redirect("/");
        }

        public IActionResult Logout()
        {
            SignOut();
            return Redirect("/");
        }
        #endregion

        #region User Profile
        public IActionResult UserProfile()
        {
            User user = _accountService.GetUserById(int.Parse(User.FindFirst("UserId").Value));
            if(user == null)
                return NotFound();

            UserProfileViewModel userProfileViewModel = new UserProfileViewModel()
            {
                UserName = user.UserName,
                Email= user.Email,
                RegisterDate = user.RegisterDate
            };

            return View(userProfileViewModel);
        }
        #endregion

        #region Edit Information
        public IActionResult EditInformation()
        {
            User user = _accountService.GetUserById(int.Parse(User.FindFirst("UserId").Value));
            if (user == null)
                return NotFound();

            EditInformationViewModel editInformationViewModel = new EditInformationViewModel()
            {
                UserName = user.UserName,
                Email = user.Email,
            };

            return View(editInformationViewModel);
        }

        [HttpPost]
        [Authorize]
        public IActionResult EditInformation(EditInformationViewModel editInformationViewModel)
        {
            User user = _accountService.GetUserById(int.Parse(User.FindFirst("UserId").Value));

            if (user == null)
                return NotFound();

            if (editInformationViewModel.Password != user.Password)
            {
                ModelState.AddModelError("Password", "Your password is incorrect.");
                return View(editInformationViewModel);
            }

            user.Email = editInformationViewModel.Email;
            user.UserName = editInformationViewModel.UserName;

            _accountService.Save();

            bool rememberMe = bool.Parse(User.FindFirst("RememberMe").Value);
            SignOut();
            SignIn(user, rememberMe);

            return Redirect("UserProfile");
        }
        #endregion

        #region Change Password
        [Authorize]
        public IActionResult ChangePassword() => View();

        [HttpPost]
        [Authorize]
        public IActionResult ChangePassword(ChangePasswordViewModel changePasswordViewModel)
        {
            User user = _accountService.GetUserById(int.Parse(User.FindFirst("UserId").Value));

            if(!ModelState.IsValid)
                return View(changePasswordViewModel);

            if (user == null)
                return NotFound();

            if (changePasswordViewModel.OldPassword != user.Password)
            {
                ModelState.AddModelError("OldPassword", "The password entered is incorrect.");
                return View(changePasswordViewModel);
            }

            user.Password = changePasswordViewModel.NewPassword;
            _accountService.Save();

            return Redirect("UserProfile");
        }
        #endregion

        #region User Favourite Items
        [Authorize]
        public IActionResult AddItemToUserFavItems(int userId, int itemId)
        {
            _accountService.AddItemToUserFavItems(userId, itemId);
            _accountService.Save();
            return RedirectToAction("Details","Home" ,new {id = itemId});
        }

        [Authorize]
        public void RemoveItemFromUserFavItems(int userId, int itemId)
        {
            _accountService.RemoveItemFromUserFavItems(userId, itemId);
            _accountService.Save();
        }

        [Authorize]
        public IActionResult UserFavouriteItems(int userId)
        {
            List<Item> items = _accountService.GetUserFavouriteItems(userId);
            return View(items);
        }

        [Authorize]
        public IActionResult RemoveItemFromUserFavItemsInDetailsPage(int userId, int itemId)
        {
            RemoveItemFromUserFavItems(userId, itemId);
            return RedirectToAction("Details", "Home", new { id = itemId });
        }

        [Authorize] 
        // UFI = User Favourite Items
        public IActionResult RemoveItemFromUserFavItemsInUFIPage(int userId, int itemId)
        {
            RemoveItemFromUserFavItems(userId, itemId);
            return RedirectToAction("UserFavouriteItems", "Account", new { userId = userId });
        }
        #endregion

        private void SignIn(User user, bool rememberMe)
        {
            List<Claim> claims = new List<Claim>()
            {
                new Claim("UserId", user.UserId.ToString()),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim("Email", user.Email),
                new Claim("Password", user.Password),
                new Claim("RegisterDate", user.RegisterDate.ToString()),
                new Claim("IsAdmin", user.IsAdmin.ToString()),
                new Claim("RememberMe", rememberMe.ToString())
            };

            ClaimsIdentity identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            ClaimsPrincipal principal = new ClaimsPrincipal(identity);
            AuthenticationProperties properties = new AuthenticationProperties()
            {
                IsPersistent = rememberMe
            };

            HttpContext.SignInAsync(principal, properties);
        }

        private void SignOut() => HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
    }
}
