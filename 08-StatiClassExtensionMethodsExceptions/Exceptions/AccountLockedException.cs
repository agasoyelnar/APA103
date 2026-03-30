using System;

namespace LoginSystemProject.Exceptions
{
    public class AccountLockedException : Exception
    {
        public AccountLockedException()
            : base("Hesab bloklanib!") { }
    }
}

