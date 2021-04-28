using Studle.BLL.Interfaces;

namespace Studle.Tests.Mocks
{
    internal class HashService : IHashService
    {
        public string GetHash(string password)
        {
            return password;
        }
    }
}
