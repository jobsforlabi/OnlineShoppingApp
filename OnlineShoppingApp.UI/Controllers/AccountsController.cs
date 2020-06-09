using OnlineShoppingApp.UI.Alerts;
using OnlineShoppingApp.UI.ControllerUtilities;
using OnlineShoppingApp.UI.DataAccess;
using OnlineShoppingApp.UI.Models;
using System.Globalization;
using System.Web.Mvc;
using System.Web.Security;

namespace OnlineShoppingApp.UI.Controllers
{
    public class AccountsController : OnlineShoppingBaseController
    {
        private UserRepository userRepository = null;
        private CryptoProvider cryptoProvider = null;
        public AccountsController()
        {
            userRepository = new UserRepository();
            cryptoProvider = new CryptoProvider();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User user)
        {
            User validUser = userRepository.GetUserByEmail(user.Email);

            if(validUser != null && validUser.Password == cryptoProvider.CreatePasswordHash(user.Password, validUser.Salt))
            {
                FormsAuthentication.SetAuthCookie(validUser.Email, false);
                CurrentUser = validUser;
                return RedirectToAction<CategoryController>(x => x.Index());
            }
            else
            {
                return View(user).WithError("Username or password invalid!");
            }
        }

        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignUp([Bind(Exclude = "Id")] User user)
        {
            string password = user.Password;
            string matchPassword = user.MatchPassword;
            ModelState.Remove("Salt");
            user.Salt = cryptoProvider.GenerateSalt();
            user.Password = cryptoProvider.CreatePasswordHash(user.Password, user.Salt);
            user.MatchPassword = cryptoProvider.CreatePasswordHash(user.MatchPassword, user.Salt);
            ModelState.Add("Salt", new ModelState { Value = new ValueProviderResult(null, user.Salt, CultureInfo.CurrentCulture) });

            if (ModelState.IsValid)
            {                
                userRepository.Insert(user);
                return RedirectToAction<AccountsController>(x => x.Login()).WithSuccess("User created!");
            }
            else
            {
                user.Password = password;
                user.MatchPassword = matchPassword;
                return View(user).WithError("Unable to create user. Please enter valid data!");
            }
        }
    }
}