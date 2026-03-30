using System;
using LoginSystemProject.Services;
using LoginSystemProject.Exceptions;

class Program
{
    static void Main()
    {
        LoginSystem system = new LoginSystem();

        while (true)
        {
            try
            {
                Console.Write("Username: ");
                string username = Console.ReadLine();

                Console.Write("Password: ");
                string password = Console.ReadLine();


                if (system.Login(username, password))
                    break;
            }
            catch (InvalidUsernameException ex)
            {
                Console.WriteLine("ERROR: " + ex.Message);
            }
            catch (InvalidPasswordException ex)
            {
                Console.WriteLine("ERROR: " + ex.Message);
            }
            catch (UserNotFoundException ex)
            {
                Console.WriteLine("ERROR: " + ex.Message);
                system.ShowUsers();
            }
            catch (IncorrectPasswordException ex)
            {
                Console.WriteLine("WARNING: " + ex.Message);
            }
            catch (AccountLockedException ex)
            {
                Console.WriteLine("CRITICAL: " + ex.Message + " Contact admin!");
                break;
            }
            catch (Exception ex)
            {
                Console.WriteLine("UNEXPECTED ERROR: " + ex.Message);
            }

            Console.WriteLine("-------------------");
        }
    }
}