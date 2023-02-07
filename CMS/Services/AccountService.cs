using CMS.Context;
using CMS.Models;
using CMS.Services.Interfaces;

namespace CMS.Services
{
    public class AccountService : IAccountService
    {
        private readonly CMSContext _context;
        public AccountService(CMSContext context) => _context = context;

        public User GetUserForLogin(string userNameOrEmail, string password)
        {
            return _context.Users.SingleOrDefault(u =>
                (u.UserName == userNameOrEmail || u.Email == userNameOrEmail) && u.Password == password);
        }

        public void InsertUser(User user) => _context.Users.Add(user);

        public bool IsExistByEmail(string email) => _context.Users.Any(u => u.Email == email);

        public bool IsExistByUserName(string userName) => _context.Users.Any(u =>u.UserName == userName);

        public void Save() => _context.SaveChanges();
    }
}
