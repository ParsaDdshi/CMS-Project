using CMS.Models;
using CMS.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text.RegularExpressions;

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

        public IActionResult Details(int id)
        {
            var item = _itemService.GetItemById(id);
            var categories = _itemService.GetItemCategories(id);

            if(item == null || categories == null)
                return RedirectToAction("PageNotFound");

            DetailViewModel viewModel = new DetailViewModel()
            {
                ItemId = item.ItemId,
                Title = item.Title,
                Text = item.Text,
                Views = item.Views,
                CreateDate = item.CreateDate,
                CategoriesName = categories
            };

            item.Views++;
            _itemService.Save();

            return View(viewModel);
        }

        public IActionResult ShowItemsByCategory(int id, string categoryName)
        {
            List<Item> items = _itemService.GetCategoryItems(id);

            if(items == null || categoryName == null)
                return RedirectToAction("PageNotFound");

            ViewBag.CategoryName = categoryName;
            return View(items);
        }

        public IActionResult Search(string searchString)
        {
            if(searchString == null)
                return View("Index");

            List<Item> items = _itemService.Search(searchString);
            return View(items);
        }

        public IActionResult About() => View();

        public IActionResult Contact() => View();

        public IActionResult PageNotFound() => View();

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}