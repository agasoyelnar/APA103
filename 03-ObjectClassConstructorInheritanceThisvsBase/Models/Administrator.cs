using System;
namespace _03_ObjectClassConstructorInheritanceThisvsBase.Models
{
	public class Administrator:Person 
	{
		public string Position, Department;
		public int AccessLevel;

		public Administrator(string fn, string ln, int age, string email,
			string id, string position, string dept, int level)
			: base(fn, ln, age, email, id) 
		{
			this.Position = position;
			this.Department = dept;
			this.AccessLevel = level;
		}
		public void ShowAdminInfo()
		{
			ShowBasicinfo();
			Console.WriteLine($"Vezife: {Position}, sobe: {Department}, seviyye: {AccessLevel}");
		}
        public void GrantAccess(Student s)
        {
            Console.WriteLine($"{GetFullName()} → {s.GetFullName()} girişi verildi.");
        }
    }
}

