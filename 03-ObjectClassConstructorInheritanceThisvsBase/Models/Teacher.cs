using System;
namespace _03_ObjectClassConstructorInheritanceThisvsBase.Models
{
	public class Teacher: Person 
	{
		public string Department, MainSubject;
		public decimal BaseSalary;
		public int ExperienceYears;

		public Teacher(string fn, string ln, int age, string email, string id,
				   string dept, string subject, decimal salary, int exp)
			: base(fn, ln, age, email, id)
		{
			this.Department = dept;
			this.MainSubject = subject;
			this.BaseSalary = salary;
			this.ExperienceYears = exp;
		}
		public void ShowTeacherInfo()
		{
			ShowBasicinfo();
			Console.WriteLine($"Kafedra: {Department}, Fənn: {MainSubject}");
		}
		public decimal CalculateSalary()
		{
			return BaseSalary + (ExperienceYears * 50);

		}
	}
}

