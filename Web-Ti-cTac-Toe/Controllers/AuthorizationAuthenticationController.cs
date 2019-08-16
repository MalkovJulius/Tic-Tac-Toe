using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Web_Ti_cTac_Toe.Controllers
{
    public class AuthorizationAuthenticationController : Controller
    {
        // GET: AuthorizationAuthentication
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public void PrimaryProcessingSignIn(string name, string passWord)
        {
            var hashPass = HashPassword(passWord);
            //TODO: Find Person with this name and get his password, it decrypt, chech equality hash password withot salt
        }

        [HttpPost]
        public void PrimaryProcessingSignUp(string name, string passWord, string email)
        {
            var salt = GenerationSalt(5);
            var hashPass = HashPassword(passWord);
            var EncryptPass = Encrypt(hashPass, salt);
            var midPass = EncryptPass + ":" + salt;
            //TODO: put the new Person in the DB
        }

        private string GenerationSalt(int length )
        {
            var crypto = new RNGCryptoServiceProvider();
            var salt = new byte[length];
            crypto.GetBytes(salt);
            return salt.ToString();
        }

        //TODO:realize it method
        private string HashPassword(string pass)
        {
            byte[] bytePass = Convert.FromBase64String(pass);
            SHA512 hashPass = new SHA512Managed();
            return hashPass.ComputeHash(bytePass).ToString();
        }

        private string Encrypt(string pass, string salt)
        {
            //I should use AES
            var cipher = new RijndaelManaged()
            {
                KeySize = 256,
                BlockSize = 128,
                Padding = PaddingMode.ISO10126,
                Mode = CipherMode.CBC,
                Key = Encoding.UTF8.GetBytes(salt)
            };
            var x = Convert.FromBase64String("slovo");
            var cryptoTransform = cipher.CreateEncryptor();
            byte[] textInByte = Encoding.UTF8.GetBytes(pass);
            byte[] result = cryptoTransform.TransformFinalBlock(textInByte, 0, textInByte.Length);
            return Convert.ToString(result);
        }

        //TODO: make decription
        private string Decrypt()
        {
            return "";
        }

        //TODO: To Do equal password
        private bool EqualPassword(string firstPass, string secodPass)
        {
            return true;
        }
    }   
}