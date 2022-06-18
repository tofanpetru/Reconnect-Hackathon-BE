using System;

namespace PartyMaker.Application.Exceptions
{
    public class AccountLoginException : Exception
    {
        public AccountLoginException(string message) : base(message) { }
    }
}
