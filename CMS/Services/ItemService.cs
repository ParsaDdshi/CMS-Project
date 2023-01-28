using CMS.Context;
using CMS.Models;
using CMS.Services.Interfaces;

namespace CMS.Services
{
    public class ItemService : IItemService
    {
        private readonly CMSContext _context;
        public ItemService(CMSContext context) => _context = context;

        public List<Category> GetCategories() => _context.Categories.ToList();

        public List<Item> GetFavouriteItems(int count = 6) => _context.Items.OrderByDescending(i => i.Views).Take(count).ToList();

        public List<Item> GetItems(int count = 9) => _context.Items.OrderBy(i => i.CreateDate).Take(count).ToList();      
    }
}
