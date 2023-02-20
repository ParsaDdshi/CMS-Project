using CMS.Context;
using CMS.Models;
using CMS.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CMS.Services
{
    public class AdminService : IAdminService
    {
        private readonly CMSContext _context;
        private readonly IItemService _itemService;
        private readonly IAccountService _accountService;
        public AdminService(CMSContext context, IItemService itemService, IAccountService accountService) 
        {
            _context = context;
            _itemService = itemService;
            _accountService = accountService;
        }

        #region Item Admin Section

        public List<Category> GetAllCategories() => _itemService.GetCategories();

        public List<Item> GetAllItems() => _context.Items.ToList();

        public List<Item> GetCategoryItems(int categoryId) => _itemService.GetCategoryItems(categoryId);

        public AdminItemViewModel GetItemViewModelById(int itemId) => _context.Items.Where(i => i.ItemId == itemId)
            .Select(i => new AdminItemViewModel()
            {
                ItemId = i.ItemId,
                Title = i.Title,
                Text = i.Text, 
                Views = i.Views,
                CreateDate = i.CreateDate
            }).FirstOrDefault();

        public List<int> GetItemCategoryId(int itemId) => _context.CategoriesToItems
            .Where(i => i.ItemId == itemId).Select(c => c.CategoryId).ToList();

        public void InsertCategoryToItem(CategoryToItem categoryToItem) => _context.CategoriesToItems.Add(categoryToItem);

        public void InsertItem(Item item) => _context.Items.Add(item);

        public Item GetItemById(int itemId) => _itemService.GetItemById(itemId);

        public void DeleteItemsFromCategoryToItems(int itemId) => _context.CategoriesToItems
            .Where(i => i.ItemId == itemId).ToList().ForEach(i => _context.CategoriesToItems.Remove(i));

        public void RemoveItem(int itemId)
        {
            Item item = GetItemById(itemId);
            _context.Items.Remove(item);
        }

        public List<Item> ItemSearch(string search) => _itemService.Search(search);

        #endregion

        #region User Admin Section

        public List<User> GetAllUsers() => _context.Users.ToList();

        public void AddUser(User user) => _context.Users.Add(user);

        public User GetUserById(int userId) => _accountService.GetUserById(userId);

        public bool IsUserExist(int userId) => _context.Users.Any(u => u.UserId == userId);

        public void RemoveUser(User user) => _context.Users.Remove(user);

        public void RemoveUserFavItems(int userId) => _context.UserFavouriteItems
            .Where(u => u.UserId == userId).ToList().ForEach(i => _context.UserFavouriteItems.Remove(i));

        public List<User> GetUsersByRole(bool isAdmin) => isAdmin == true ? 
            _context.Users.Where(u => u.IsAdmin == isAdmin).ToList() : 
            _context.Users.Where(u => u.IsAdmin == isAdmin).ToList();

        public List<User> UserSearch(string search) => _context.Users
            .Where(u => u.UserName.Contains(search) || u.Email.Contains(search)).ToList();

        #endregion

        #region Category Admin Section

        public void InsertCategory(Category category) => _context.Categories.Add(category);

        public Category GetCategoryById(int categoryId) => _context.Categories
            .FirstOrDefault(c => c.CategoryId == categoryId);

        public bool IsCategoryExist(int categoryId) => _context.Categories.Any(c => c.CategoryId == categoryId);

        public void RemoveCategory(Category category) => _context.Categories.Remove(category);

        public void DeletCategoriesFromCategoryToItems(int categoryId) => _context.CategoriesToItems
            .Where(i => i.ItemId == categoryId).ToList().ForEach(i => _context.CategoriesToItems.Remove(i));

        public List<Category> CategorySearch(string search) => _context.Categories
            .Where(c => c.CategoryName.Contains(search)).ToList();

        #endregion

        public void Save() => _context.SaveChanges();
    }
}
