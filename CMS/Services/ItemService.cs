using CMS.Context;
using CMS.Models;
using CMS.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CMS.Services
{
    public class ItemService : IItemService
    {
        private readonly CMSContext _context;
        public ItemService(CMSContext context) => _context = context;

        public List<Category> GetCategories() => _context.Categories.ToList();

        public List<Item> GetFavouriteItems(int count = 6) => _context.Items.OrderByDescending(i => i.Views).Take(count).ToList();

        public Item GetItemById(int? id) => _context.Items.FirstOrDefault(i => i.ItemId == id);
        public List<Item> GetCategoryItems(int categoryId)
        {
            return _context.CategoriesToItems.Where(c => c.CategoryId == categoryId)
                .Include(i => i.Item).Select(i => i.Item).ToList();
        }

        public List<Category> GetItemCategories(int itemId)
        {
            return _context.CategoriesToItems.Where(i => i.ItemId == itemId)
                .Include(c => c.Category).Select(c => c.Category).ToList();
        }

        public List<Item> GetItems(int count = 9) => _context.Items.OrderBy(i => i.CreateDate).Take(count).ToList();

        public void Save() => _context.SaveChanges();
    }
}
