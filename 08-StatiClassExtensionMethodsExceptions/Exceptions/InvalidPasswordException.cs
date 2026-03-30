using System;

namespace LoginSystemProject.Exceptions
{
    public class InvalidPasswordException : Exception
    {
        public InvalidPasswordException()
            : base("Password bos ve ya 6 simvoldan azdir") { }

        public InvalidPasswordException(string message)
            : base(message) { }
    }
}