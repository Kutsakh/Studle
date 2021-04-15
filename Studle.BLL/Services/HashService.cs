using System.Security.Cryptography;
using System.Text;
using Studle.BLL.Interfaces;

namespace Studle.BLL.Services
{
    public sealed class HashService : IHashService
    {
        public string GetHash(string password)
        {
            var sh = new SHA1CryptoServiceProvider();
            sh.ComputeHash(Encoding.ASCII.GetBytes(password));
            var re = sh.Hash;
            var sb = new StringBuilder();
            foreach (var b in re)
            {
                sb.Append(b.ToString("x2"));
            }

            return sb.ToString();
        }
    }
}
