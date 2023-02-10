using CMS.Models;
using System.Reflection.Metadata;

namespace CMS.Services.Interfaces
{
    public interface IAccountService
    {
        void InsertUser(User user);
        void Save();
        bool IsExistByEmail(string email);
        bool IsExistByUserName(string userName);
        User GetUserForLogin(string userNameOrEmail, string password);
        User GetUserById(int userId);
        void AddItemToUserFavItems(int userId, int itemId);
        void RemoveItemFromUserFavItems(int userId, int itemId);
        bool IsItemExistInUFI(int itemId, int userId); // UFI = User Favourite Items
        List<Item> GetUserFavouriteItems(int userId);
    }
}
