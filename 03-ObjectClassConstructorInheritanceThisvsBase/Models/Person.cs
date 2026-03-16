using System;
namespace _03_ObjectClassConstructorInheritanceThisvsBase.Models
{
	public class Person
	{
		public string FirstName, LastName, Email, ID;
		public int Age;

		public Person(string firstname, string lastname, int age, string email, string id)
		{
			this.FirstName = firstname;
			this.LastName = lastname;
            this.Age = age;
            this.Email = email;
			this.ID = id;
		}
        public string GetFullName()
        {
            return FirstName + " " + LastName;
        }
		public void ShowBasicinfo()
		{
			Console.WriteLine($"Ad: {GetFullName ()},Yas: {Age}, Email: {Email}");
		}
    }
}

