using CMS.Models;
using CMS.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CMS.Pages.Admin.ManageUsers
{
    public class UserSearchModel : PageModel
    {
        private readonly IAdminService _adminService;

        public UserSearchModel(IAdminService adminService) => _adminService = adminService;

        public IList<User> User { get; set; } = default!;
        public IActionResult OnPost(string search)
        {
            if (search == null)
                return RedirectToPage("Index");

            User = _adminService.UserSearch(search);

            return Page();
        }
    }
}
