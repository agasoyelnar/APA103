using System;
namespace LoginSystemProject.Exceptions
{
    public class UserNotFoundException : Exception
    {
        public UserNotFoundException()
            : base("User tapilmadi") { }

        public UserNotFoundException(string username)
            : base("User tapilmadi") { }
    }
}
