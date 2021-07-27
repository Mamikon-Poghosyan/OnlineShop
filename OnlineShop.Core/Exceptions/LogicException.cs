using System;

namespace OnlineShop.Core.Exceptions
{
    public class LogicException : Exception
    {
        public LogicException(string message)
            : base(message)
        {
        }
    }
}
