using System;

namespace Studle.BLL.Infrastructure
{
    internal class ValidationException : Exception
    {
        public ValidationException(string message, string prop)
            : base(message)
        {
            Property = prop;
        }

        public string Property
        {
            get;
            protected set;
        }
    }
}
