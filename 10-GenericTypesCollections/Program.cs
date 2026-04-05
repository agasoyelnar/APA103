using System;
using System.Collections.Generic;
using _10_GenericTypesCollections.Models;

namespace _10_GenericTypesCollections
{
    class Program
    {
        static void Main(string[] args)
        {
            Book book1 = new Book(1, "Martin Eden", "Jack London", 1909, 400);
            Book book2 = new Book(2, "1984", "George Orwell", 1949, 328);
            Book book3 = new Book(3, "Animal Farm", "George Orwell", 1945, 112);
            Book book4 = new Book(4, "Ağ Gəmi", "Cingiz Aytmatov", 1970, 200);
            Book book5 = new Book(5, "Qırıq Budaq", "Elçin", 1998, 350);

            book1.DisplayInfo();
            book2.DisplayInfo();
            book3.DisplayInfo();
            book4.DisplayInfo();
            book5.DisplayInfo();

            Library<Book> milliLibrary = new Library<Book>("Milli Kitabxana");
            milliLibrary.Add(book1);
            milliLibrary.Add(book2);
            milliLibrary.Add(book3);
            milliLibrary.Add(book4);
            milliLibrary.Add(book5);

            Console.WriteLine($"Kitab sayı: {milliLibrary.count()}");
            milliLibrary.FindByIndex(0).DisplayInfo();
            milliLibrary.FindByIndex(2).DisplayInfo();

            Console.WriteLine("butun kitablar:");
            foreach (var book in milliLibrary.GetAll())
                book.DisplayInfo();

            List<Member> members = new List<Member>
            {
                new Member(1, "Ali Məmmədov", "ali@mail.com"),
                new Member(2, "Leyla Həsənova", "leyla@mail.com"),
                new Member(3, "Vüqar Əliyev", "vuqar@mail.com")
            };

            members[0].BorrowBooks(book1);
            members[0].BorrowBooks(book2);
            Console.WriteLine("Ali-nin borc kitabları:");
            members[0].DisplayBorrowedBooks();

            members[0].ReturnBook(1);
            Console.WriteLine("Ali-nin borc kitablari (qaytardiqdan sonra):");
            members[0].DisplayBorrowedBooks();

            members[0].BorrowBooks(book3);
            members[0].BorrowBooks(book4);
            members[0].BorrowBooks(book5);


            BookManager manager = new BookManager();
            manager.AddBook(book1);
            manager.AddBook(book2);
            manager.AddBook(book3);
            manager.AddBook(book4);
            manager.AddBook(book5);

            Console.WriteLine("\nGeorge Orwell kitabları:");
            var orwellBooks = manager.GetBooksByAuthor("George Orwell");
            foreach (var b in orwellBooks)
                b.DisplayInfo();
            Console.WriteLine($"Say: {orwellBooks.Count}");


            Console.WriteLine("\nCingiz Aytmatov kitabları:");
            var aytmatovBooks = manager.GetBooksByAuthor("Cingiz Aytmatov");
            foreach (var b in aytmatovBooks)
                b.DisplayInfo();
            Console.WriteLine($"Say: {aytmatovBooks.Count}");


            Console.WriteLine("\nJack London kitabları:");
            var londonBooks = manager.GetBooksByAuthor("Jack London");
            foreach (var b in londonBooks)
                b.DisplayInfo();
            Console.WriteLine($"Say: {londonBooks.Count}");


            Console.WriteLine("\nDostoyevski kitabları:");
            var unknownBooks = manager.GetBooksByAuthor("Dostoyevski");
            foreach (var b in unknownBooks)
                b.DisplayInfo();
            Console.WriteLine($"Say: {unknownBooks.Count}");

            manager.AddToWaitingQueue("Nigar");
            manager.AddToWaitingQueue("Rəşad");
            manager.AddToWaitingQueue("Səbinə");

            Console.WriteLine($"Növbədə: {manager.WaitingQueue.Count} nəfər");

            Console.WriteLine("Xidmət edilir: " + manager.ServeNextInQueue());

            Console.WriteLine($"Qalan: {manager.WaitingQueue.Count} nəfər");

            Console.WriteLine("Xidmət edilir: " + manager.ServeNextInQueue());
            Console.WriteLine($"Qalan: {manager.WaitingQueue.Count} nəfər");

            Console.WriteLine("Xidmət edilir: " + manager.ServeNextInQueue());

            Console.WriteLine($"Növbədə qalan: {manager.WaitingQueue.Count} nəfər");


            manager.ReturnBook(book1);
            manager.ReturnBook(book2);
            manager.ReturnBook(book3);

            Console.WriteLine($"Stack sayı: {manager.RecentlyReturned.Count}");

            Console.WriteLine("Son kitab: " + manager.GetLastReturnedBook().Title);

            manager.RecentlyReturned.Pop();

            Console.WriteLine($"Stack sayı: {manager.RecentlyReturned.Count}");

            Console.WriteLine("Son kitab: " + manager.GetLastReturnedBook().Title);


            Book search = manager.SearchByTitle("1984");
            if (search != null) search.DisplayInfo();
            else Console.WriteLine("Kitab tapilmadi");

            Book search2 = manager.SearchByTitle("Harry Potter");
            if (search2 != null) search2.DisplayInfo();
            else Console.WriteLine("Kitab tapilmadi");

            Console.WriteLine($"Umumi kitab sayi: {manager.Books.Count}");
            Console.WriteLine($"Umumi uzv sayi: {members.Count}");
            Console.WriteLine($"Novbede adam sayi: {manager.WaitingQueue.Count}");
            Console.WriteLine($"qalan kitab sayi: {manager.RecentlyReturned.Count}");

            int minYear = int.MaxValue;
            int maxYear = int.MinValue;
            foreach (var b in manager.Books)
            {
                if (b.Year < minYear) minYear = b.Year;
                if (b.Year > maxYear) maxYear = b.Year;
            }
            Console.WriteLine($"En kohne kitab ili: {minYear}");
            Console.WriteLine($"En yeni kitab ili: {maxYear}");
        }
    }
}