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
        private List<Book> _BorrowedBooks;

        static private List<User> _allUsers = new List<User>();

        public User(string fullName)
        {
            this._fullName = fullName;
            this._BorrowedBooks = new List<Book>();

            _allUsers.Add(this);
        }

        public void ShowBooks()
        {
            if (_BorrowedBooks.Count > 0)
            {
                Console.WriteLine($"{_fullName} currently has {_BorrowedBooks.Count} books in their personal account: ");
                foreach (Book book in _BorrowedBooks) Console.WriteLine($"* \"{book.Title}\"");               
            }
            else Console.WriteLine($"{_fullName}currently has no books in their personal account.");
            Console.WriteLine();
        }
        public void TryTakeBook(int id)
        {
            if(Book.IsId(id))
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
            Console.WriteLine();

        }
    }
}