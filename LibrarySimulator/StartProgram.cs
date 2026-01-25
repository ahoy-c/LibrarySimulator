using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static LibrarySimulator.User;

namespace LibrarySimulator
{
    public class StartProgram
    {
        public StartProgram()
        {
            LibraryCreateBooks();

            User user1 = CreateUser();

            ActionsLoop(user1);
        }

        static void LibraryCreateBooks()
        {
            var book1 = new BookBuilder()
            .SetTitle("Pro C# 10 with .NET 6")
            .SetAuthor("Andrew Troelsen")
            .SetPublicationYear(2022)
            .Build();

            var book2 = new BookBuilder()
                .SetTitle("Harry Potter and the Sorcerer's Stone")
                .SetAuthor("J.K. Rowling")
                .SetPublicationYear(1997)
                .Build();

            var book3 = new BookBuilder()
                .SetTitle("Clean Code")
                .SetAuthor("Robert C. Martin")
                .SetPublicationYear(2008)
                .Build();

            var book4 = new BookBuilder()
                .SetTitle("The Pragmatic Programmer")
                .SetAuthor("Andrew Hunt & David Thomas")
                .SetPublicationYear(1999)
                .Build();

            var book5 = new BookBuilder()
                .SetTitle("Design Patterns: Elements of Reusable Object-Oriented Software")
                .SetAuthor("Erich Gamma, Richard Helm, Ralph Johnson, John Vlissides")
                .SetPublicationYear(1994)
                .Build();

            var book6 = new BookBuilder()
                .SetTitle("C# in Depth")
                .SetAuthor("Jon Skeet")
                .SetPublicationYear(2019)
                .Build();

            var book7 = new BookBuilder()
                .SetTitle("Head First Design Patterns")
                .SetAuthor("Eric Freeman & Elisabeth Robson")
                .SetPublicationYear(2004)
                .Build();

            var book8 = new BookBuilder()
                .SetTitle("Effective C#")
                .SetAuthor("Bill Wagner")
                .SetPublicationYear(2020)
                .Build();

            var book9 = new BookBuilder()
                .SetTitle("Introduction to Algorithms")
                .SetAuthor("Thomas H. Cormen, Charles E. Leiserson, Ronald L. Rivest, Clifford Stein")
                .SetPublicationYear(2009)
                .Build();

            var book10 = new BookBuilder()
                .SetTitle("Game Programming Patterns")
                .SetAuthor("Robert Nystrom")
                .SetPublicationYear(2014)
                .Build();
            var ebook = new BookBuilder()
            .SetTitle("Omori")
            .SetAuthor("Someone")
            .SetPublicationYear(2025)
            .BuildElectronicBook("PDF");

            var audiobook = new BookBuilder()
                .SetTitle("Omori Audio")
                .SetAuthor("Someone")
                .SetPublicationYear(2025)
                .BuildAudioBook("120");
        }
        static User CreateUser()
        {
            Console.WriteLine("Enter the name of the new user: ");
            string name = Console.ReadLine();

            Console.WriteLine("Select the status: ");
            Console.WriteLine("[1] - Regular user");
            Console.WriteLine("[2] - Admin");
            string num = Console.ReadLine();
            StatusUser status = StatusUser.Regular;

            if (num.Equals("2")) status = StatusUser.Admin;
            User user = new User(name, status);

            return user;

        }
        static void ActionsLoop(User user)
        {
            while (true)
            {
                Console.WriteLine();
                if (user.Status == StatusUser.Admin) ActionsAdmin(user);
                else ActionsRegular(user);

                Console.WriteLine("Press Enter to continue or Escape to Exit…");
                if (Console.ReadKey().Key == ConsoleKey.Escape) return;

            }

            static void ActionsRegular(User user1)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;

                Console.WriteLine("What would you like to do?");

                Console.WriteLine("[1] - Show all books in the library");
                Console.WriteLine("[2] - Borrow a book");
                Console.WriteLine("[3] - Return a book");
                Console.WriteLine("[4] - Show all books in the user's account");

                Console.ForegroundColor = ConsoleColor.White;

                string acti = Console.ReadLine();
                switch (acti)
                {
                    case "1": Book.ListAllLibraryBooks(); break;
                    case "2": user1.TryTakeBook(); break;
                    case "3": user1.TryReturnBook(); break;
                    case "4": user1.ShowBooks(); break;
                }
            }
            static void ActionsAdmin(User user1)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;

                Console.WriteLine("What would you like to do?");

                Console.WriteLine("[1] - Show all books in the library");
                Console.WriteLine("[2] - Borrow a book");
                Console.WriteLine("[3] - Return a book");
                Console.WriteLine("[4] - Show all books in the user's account");
                Console.WriteLine("[5] - Create a new book");
                Console.WriteLine("[4] - Remove a book");

                Console.ForegroundColor = ConsoleColor.White;

                string acti = Console.ReadLine();
                switch (acti)
                {
                    case "1": Book.ListAllLibraryBooks(); break;
                    case "2": user1.TryTakeBook(); break;
                    case "3": user1.TryReturnBook(); break;
                    case "4": user1.ShowBooks(); break;
                    case "5": CreateBook(); break;
                    case "6": RemoveBook(); break;
                }
                static void CreateBook()
                {
                    Console.Write("Enter the title: ");
                    string title = Console.ReadLine();

                    Console.Write("Enter the author: ");
                    string author = Console.ReadLine();

                    Console.Write("Enter the year the book was published:");
                    int year = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("Select the type of book: [1] - Regular, [2] - E-book, [3] - Audio");
                    Book book = null;

                    switch (Console.ReadLine())
                    {
                        case "1":
                            book = new Book(title, author, year);
                            book.ShowInformationAboutBook();
                            break;

                        case "2":
                            Console.WriteLine("Enter the book format (EPUB, FB2, PDF): ");
                            string format = Console.ReadLine();
                            book = new ElectronicBook(title, author, year, format);
                            book.ShowInformationAboutBook();
                            break;

                        case "3":
                            Console.WriteLine("Enter the duration of the audiobook (Hours): ");
                            string duration = Console.ReadLine();
                            book = new AudioBook(title, author, year, duration);
                            book.ShowInformationAboutBook();
                            break;
                        default: break;
                    }
                }
                static void RemoveBook()
                {
                    Console.WriteLine("Enter the ID of the book you want to delete:");
                    int id = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine($"Are you sure you want to delete \"{Book.GetBook(id).Title}\" with ID {Book.GetBook(id).Id}?");
                    Console.WriteLine("[1] - Yes");
                    Console.WriteLine("[2] - No");
                    if (Console.ReadLine().Equals("1"))
                    {
                        Book.RemoveBook(id);
                        Console.WriteLine("The book has been deleted");
                    }
                    else return;
                }
            }

        }
    }
}
