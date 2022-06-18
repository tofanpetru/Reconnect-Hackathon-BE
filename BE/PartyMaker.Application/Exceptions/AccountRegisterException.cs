using System;

namespace PartyMaker.Application.Exceptions
{
    public class AccountRegisterException : Exception
    {
        public AccountRegisterException(string message) : base(message) { }
    }
}
