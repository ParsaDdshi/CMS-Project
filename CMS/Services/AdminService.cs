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
        public AdminService(CMSContext context, IItemService itemService) 
        {
            _context = context;
            _itemService= itemService;
        }

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

        public void Save() => _context.SaveChanges();

        public Item GetItemById(int itemId) => _itemService.GetItemById(itemId);

        public void DeleteCategoryToItems(int itemId) => _context.CategoriesToItems
            .Where(i => i.ItemId == itemId).ToList().ForEach(i => _context.CategoriesToItems.Remove(i));

        public void RemoveItem(int itemId)
        {
            Item item = GetItemById(itemId);
            _context.Items.Remove(item);
        }
    }
}
