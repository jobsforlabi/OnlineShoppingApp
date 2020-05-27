using OnlineShoppingApp.UI.Models;

namespace OnlineShoppingApp.UI.DataAccess
{
    public interface IUserRepositoy
    {
        User GetUserByEmail(string email);
    }
}