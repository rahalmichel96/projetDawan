using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookExchange.WebUI.Exceptions
{
    public class EmailException : Exception
    {
        public EmailException()
        {
        }

        public EmailException(string message) : base(message)
        {
        }
    }
}