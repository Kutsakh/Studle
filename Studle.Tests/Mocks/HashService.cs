using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Studle.BLL.Interfaces;

namespace Studle.Tests.Mocks
{
    class HashService : IHashService
    {
        public string GetHash(string password)
        {
            return password;
        }
    }
}
