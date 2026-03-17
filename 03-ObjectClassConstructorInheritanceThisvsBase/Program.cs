using System;
using _03_ObjectClassConstructorInheritanceThisvsBase.Models;

class Program
{
    static void Main(string[] args)
    {
        Student s1 = new Student("Gunel", "Alizeda", 20, "aliz@gmail.com", "S001", "20001", "komputer", 88.5, 2);
        Student s2 = new Student("Amin", "Eliyev", 21, "amin@gmail.com", "S002", "20002", "IT", 90.5, 4);
        Student s3 = new Student("Samir", "Quliyev", 20, "az@gmail.com", "S003", "20003", "muhendislik", 80.5, 2);

        Teacher t1 = new Teacher("Nihad", "Amirov", 33, "amir@gmail.com", "T001", "Proqramist", "C#",800, 15);
        Teacher t2 = new Teacher("Aysu", "Amirova", 30, "asu@gmail.com", "T002", "Proqramist", "C#",750, 15);

        Administrator admin = new Administrator("Tural", "İsmayılov", 50, "t@gmail.com", "A001", "Dekan", "Tədris", 5);

        s1.ShowStudentInfo(); Console.WriteLine($"Teqaud: {s1.CalculateScholarship()} AZN");

        s2.ShowStudentInfo(); Console.WriteLine($"Teqaud: {s2.CalculateScholarship()} AZN");
        s3.ShowStudentInfo(); Console.WriteLine($"Teqaud: {s3.CalculateScholarship()} AZN");

        t1.ShowTeacherInfo(); Console.WriteLine($"Maaş: {t1.CalculateSalary()} AZN");
        t2.ShowTeacherInfo(); Console.WriteLine($"Maaş: {t2.CalculateSalary()} AZN");

        admin.ShowAdminInfo();
        admin.GrantAccess(s1);

        Console.WriteLine($"Ümumi teqaud: {s1.CalculateScholarship() + s2.CalculateScholarship() + s3.CalculateScholarship()} AZN");
        Console.WriteLine($"Ümumi maaş: {t1.CalculateSalary() + t2.CalculateSalary()} AZN");

    }
}

