using System;

namespace LoginSystemProject.Exceptions
{
    public class InvalidUsernameException : Exception
    {
        public InvalidUsernameException()
            : base("Username bos ve ya 3 simvoldan azdir") { }

        public InvalidUsernameException(string message)
            : base(message) { }
    }
}