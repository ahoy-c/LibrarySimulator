using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Reflection.Metadata.BlobBuilder;

namespace LibrarySimulator
{
    public class User
    {
        private string _fullName;
        private StatusUser _status;
        private List<Book> _BorrowedBooks;

        static private List<User> _allUsers = new List<User>();
        public enum StatusUser
        {
            Regular,
            Admin
        }
        public StatusUser Status { get; }
        public User(string fullName, StatusUser status)
        {
            this._fullName = fullName;
            this._status = status;
            this._BorrowedBooks = new List<Book>();
            this.Status = status;

            _allUsers.Add(this);
        }

        public void ShowBooks()
        {
            Console.WriteLine();
            if (_BorrowedBooks.Count > 0)
            {
                Console.WriteLine($"{_fullName} currently has {_BorrowedBooks.Count} books in their personal account: ");
                foreach (Book book in _BorrowedBooks) Console.WriteLine($"* \"{book.Title}\", ID: {book.Id}");
            }
            else Console.WriteLine($"{_fullName}currently has no books in their personal account.");
        }
        public void TryTakeBook()
        {
            Book.ListAllLibraryBooks();
            Console.Write("Please enter the ID of the book you want to borrow: ");
            int id = Convert.ToInt32(Console.ReadLine());

            if (Book.IsId(id))
            {
                Book book = Book.GetBook(id);
                if (Book.IsPresent(book))
                {
                    _BorrowedBooks.Add(book);
                    book.TakeBook();
                    Console.WriteLine($"The book \"{book.Title}\" has been added to {_fullName}'s personal account.");
                }
                else
                {
                    Console.WriteLine("This book is currently not available in the library.");
                }
            }
            else Console.WriteLine($"No book found with ID \"{id}\".");
        }
        public void TryReturnBook()
        {
            ShowBooks();
            Console.WriteLine();

            Console.Write("Please enter the ID of the book you want to return: ");
            int id = Convert.ToInt32(Console.ReadLine());

            if (Book.IsId(id))
            {
                if (!Book.IsPresent(Book.GetBook(id)))
                {
                    _BorrowedBooks.Remove(Book.GetBook(id));
                    Console.WriteLine("You have successfully returned the book");
                }
                else Console.WriteLine("You don't have this book");
            }
            else Console.WriteLine("A book with this ID does not exist");
            Console.WriteLine();
        }
    }
}