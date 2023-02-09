using CMS.Context;
using CMS.Models;
using CMS.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CMS.Services
{
    public class AccountService : IAccountService
    {
        private readonly CMSContext _context;
        private readonly IItemService _itemService;
        public AccountService(CMSContext context, IItemService itemService)
        {
            _itemService= itemService;
            _context = context;
        }

        public void AddItemToUserFavItems(int userId, int itemId)
        {
            Item item = _itemService.GetItemById(itemId);
            User user = GetUserById(userId);

            _context.UserFavouriteItems.Add(new UserFavouriteItem()
            {
                UserId= userId,
                ItemId= itemId,
                Item = item,
                User= user
            });
        }

        public User GetUserForLogin(string userNameOrEmail, string password)
        {
            return _context.Users.SingleOrDefault(u =>
                (u.UserName == userNameOrEmail || u.Email == userNameOrEmail) && u.Password == password);
        }

        public User GetUserById(int userId) => _context.Users.SingleOrDefault(u => u.UserId == userId);

        public void InsertUser(User user) => _context.Users.Add(user);

        public bool IsExistByEmail(string email) => _context.Users.Any(u => u.Email == email);

        public bool IsExistByUserName(string userName) => _context.Users.Any(u => u.UserName == userName);

        public void Save() => _context.SaveChanges();

        // UFI = User Favourite Items
        public bool IsItemExistInUFI(int itemId, int userId) => _context.UserFavouriteItems.Any(i => i.UserId== userId && i.ItemId == itemId);

        public void RemoveItemFromUserFavItems(int userId, int itemId)
        {
            Item item = _itemService.GetItemById(itemId);
            User user = GetUserById(userId);

            _context.UserFavouriteItems.Remove(new UserFavouriteItem()
            {
                UserId = userId,
                ItemId = itemId,
            });
        }

        public List<Item> GetUserFavouriteItems(int userId) => _context.UserFavouriteItems
            .Where(u => u.UserId == userId).Include(i => i.Item).Select(i => i.Item).ToList();
    }
}
