using OnlineShoppingApp.UI.Models;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShoppingApp.UI.DataAccess
{
    public class UserRepository : GenericRepository<User>, IUserRepositoy
    {
        public User GetUserByEmail(string email)
        {
            List<User> users = GetAll(v => v.Email == email, v => v.Role).ToList();
            return users.FirstOrDefault();
        }
    }
}