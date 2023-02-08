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
        User GetUserForProfile(int userId);
        void UpdateUser(User user);
    }
}
