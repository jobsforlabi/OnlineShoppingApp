using OnlineShoppingApp.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShoppingApp.UI.DataAccess
{
    public class UserRepository : GenericRepository<User>, IUserRepositoy
    {
        public User GetUserByEmail(string email)
        {
            List<User> users = GetAll().ToList();

            if (users != null && users.Any())
            {
                IEnumerable<User> matchingUsers = users.Where(x => x.Email == email);

                if (matchingUsers != null && matchingUsers.Any())
                {
                    return matchingUsers.First();
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }
    }
}