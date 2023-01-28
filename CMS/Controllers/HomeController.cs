using CMS.Models;
using CMS.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CMS.Controllers
{
    public class HomeController : Controller
    {
        private readonly IItemService _itemService;
        public HomeController(IItemService itemService) => _itemService = itemService;

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult ShowItemsByCategory(int id, string categoryName)
        {
            List<Item> items = _itemService.GetCategoryItems(id);
            ViewBag.CategoryName = categoryName;
            return View(items);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}