using CMS.Models;

namespace CMS.Services.Interfaces
{
    public interface IAccountService
    {
        void InsertUser(User user);
        void Save();
        bool IsExistByEmail(string email);
        bool IsExistByUserName(string userName);
    }
}
