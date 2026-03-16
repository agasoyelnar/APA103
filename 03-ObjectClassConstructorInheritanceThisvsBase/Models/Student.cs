using System;
namespace _03_ObjectClassConstructorInheritanceThisvsBase.Models
{
	public class Student:Person 
	{
		public string StudentNumber, Faculty;
		public double GPA;
		public int Year;

		public Student(string fn, string ln, int age, string email, string id,
			string number, string faculty, double gpa, int year) : base(fn, ln, age, email, id)
		{
			this.StudentNumber = number;
			this.Faculty = faculty;
			this.GPA = gpa;
			this.Year = year;
		}
		public void ShowStudentInfo()
		{
			ShowBasicinfo();
			Console.WriteLine($"Fakulte: {Faculty}, GPA: {GPA}, Kurs: {Year}");
		}

		public double CalculateScholarship()
		{
			if (GPA >= 90) return 500;
            if (GPA >= 80) return 350;
            if (GPA >= 70) return 200;
			return 0;
        }

    }
}

