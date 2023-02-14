using CMS.Models;

namespace CMS.Services.Interfaces
{
    public interface IAdminService
    {
        List<Item> GetAllItems();
        List<Item> GetCategoryItems(int categoryId);
        List<Category> GetAllCategories();
        void InsertItem(Item item);
        void InsertCategoryToItem(CategoryToItem categoryToItem);
        AdminItemViewModel GetItemViewModelById(int itemId);
        Item GetItemById(int itemId);
        List<int> GetItemCategoryId(int itemId);
        void DeleteCategoryToItems(int itemId);
        void RemoveItem(int itemId);
        void Save();
    }
}
