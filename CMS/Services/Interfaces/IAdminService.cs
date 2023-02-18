using CMS.Models;

namespace CMS.Services.Interfaces
{
    public interface IAdminService
    {

        #region Items Admin Section
        List<Item> GetAllItems();
        List<Item> GetCategoryItems(int categoryId);
        List<Category> GetAllCategories();
        void InsertItem(Item item);
        void InsertCategoryToItem(CategoryToItem categoryToItem);
        AdminItemViewModel GetItemViewModelById(int itemId);
        Item GetItemById(int itemId);
        List<int> GetItemCategoryId(int itemId);
        void DeleteItemsFromCategoryToItems(int itemId);
        void RemoveItem(int itemId);

        #endregion

        #region User Admin Section

        List<User> GetAllUsers();
        void AddUser(User user);
        User GetUserById(int userId);
        bool IsUserExist(int userId);
        void RemoveUser(User user);
        void RemoveUserFavItems(int userId);
        List<User> GetUsersByRole(bool isAdmin);

        #endregion

        #region Category Admin Section

        void InsertCategory(Category category);
        Category GetCategoryById(int categoryId);
        bool IsCategoryExist(int categoryId);
        void RemoveCategory(Category category);
        void DeletCategoriesFromCategoryToItems(int categoryId);

        #endregion
        void Save();
    }
}
