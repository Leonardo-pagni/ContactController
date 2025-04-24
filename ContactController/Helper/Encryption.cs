using System.Security.Cryptography;
using System.Text;

namespace ContactController.Helper
{
    public static class Encryption
    {
        public static string GenerateHash(this string password)
        {
            var hash = SHA1.Create();
            var encodind = new ASCIIEncoding();
            var array = encodind.GetBytes(password);

            array = hash.ComputeHash(array);

            var strHexa = new StringBuilder();

            foreach( var i in array )
            {
                strHexa.Append(i.ToString("x2"));
            }

            return strHexa.ToString();
        }
    }
}
