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

            Book.ListAllLibraryBooks();

            User user1 = new User("Rozhdestvenskiy Ivan");

            user1.TryTakeBook(1);
            user1.TryTakeBook(0);

            user1.ShowBooks();


        }
    }
}
