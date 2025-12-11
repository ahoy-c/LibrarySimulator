using System.Runtime.Intrinsics.X86;
using static LibrarySimulator.User;

namespace LibrarySimulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Book book1 = new Book("Pro C# 10 with .NET 6", "Andrew Troelsen", 2022);
            Book book2 = new Book("Harry Potter and the Sorcerer's Stone", "J.K. Rowling", 1997);
            Book book3 = new Book("Clean Code", "Robert C. Martin", 2008);
            Book book4 = new Book("The Pragmatic Programmer", "Andrew Hunt & David Thomas", 1999);
            Book book5 = new Book("Design Patterns: Elements of Reusable Object-Oriented Software", "Erich Gamma, Richard Helm, Ralph Johnson, John Vlissides", 1994);
            Book book6 = new Book("C# in Depth", "Jon Skeet", 2019);
            Book book7 = new Book("Head First Design Patterns", "Eric Freeman & Elisabeth Robson", 2004);
            Book book8 = new Book("Effective C#", "Bill Wagner", 2020);
            Book book9 = new Book("Introduction to Algorithms", "Thomas H. Cormen, Charles E. Leiserson, Ronald L. Rivest, Clifford Stein", 2009);
            Book book10 = new Book("Game Programming Patterns", "Robert Nystrom", 2014);

            User user1 = CreateUser();

            ActionsLoop(user1);

        }
        static User CreateUser()
        {
            User user = null;
            Console.WriteLine("Enter the name of the new user: ");
            string name = Console.ReadLine();
            Console.WriteLine("Select the status: ");
            Console.WriteLine("[1] - Regular user");
            Console.WriteLine("[2] - Admin");
            string num = Console.ReadLine();
            StatusUser status = StatusUser.Regular;

            if(num.Equals("2")) status = StatusUser.Admin;
            user = new User(name, status);

            return user;

        }
        static void ActionsLoop(User user)
        {
            while (true)
            {
                Console.WriteLine();
                if(user.Status == StatusUser.Admin) ActionsAdmin(user);
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
