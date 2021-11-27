using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookExchange.WebUI.Exceptions
{
    public class UsernameException : Exception
    {
        public UsernameException()
        {
        }

        public UsernameException(string message) : base(message)
        {
        }
    }
}