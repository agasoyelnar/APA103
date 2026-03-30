using System;

namespace LoginSystemProject.Exceptions
{
    public class IncorrectPasswordException : Exception
    {
        public int AttemptsLeft { get; set; }

        public IncorrectPasswordException(int attemptsLeft)
            : base($"Password sehvdir! Qalan cehd sayi: {attemptsLeft}")
        {
            AttemptsLeft = attemptsLeft;
        }
    }
}

