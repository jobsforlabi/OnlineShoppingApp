using System;
using System.Security.Cryptography;
using System.Web.Security;

namespace OnlineShoppingApp.UI.ControllerUtilities
{
    public class CryptoProvider
    {
        public string GenerateSalt()
        {
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            byte[] buff = new byte[10];
            rng.GetBytes(buff);
            return Convert.ToBase64String(buff);
        }

        public string CreatePasswordHash(string password, string salt)
        {
            string passwordAndSalt = String.Concat(password, salt);
            string hashedPassword = FormsAuthentication.HashPasswordForStoringInConfigFile(passwordAndSalt, "sha1");
            return hashedPassword;
        }
    }
}