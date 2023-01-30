using CMS.Models;
using CMS.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

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
    }
}
