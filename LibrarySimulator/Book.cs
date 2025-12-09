using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using static System.Reflection.Metadata.BlobBuilder;

namespace LibrarySimulator
{
    public class Book
    {

        private string _title;
        public string Title { get; }
        private string _author;
        private int _publicationYear;
        private bool _isPresent = true;
        private int id;

        static private Dictionary<int, Book> _library = new Dictionary<int, Book>();
        static private List<Book> _allBooks = new List<Book>();

        static private int _lastIdInLibrary = 0;

        public Book(string title, string author, int publicationYear)
        {
            this._title = title;
            this.Title = _title;
            this._author = author;
            this._publicationYear = publicationYear;
            this.id = _lastIdInLibrary;

            _library.Add(id, this);
            _allBooks.Add(this);
            _lastIdInLibrary++;

            Console.WriteLine($"The book \"{title}\" has been created with ID \"{id}\".") ;
            Console.WriteLine();
        }
        static public void ListAllLibraryBooks()
        {
            Console.WriteLine("Books in the library: ");
            foreach(var kvs in _library)
            {
                Console.WriteLine($"- {kvs.Value.Title} (ID: {kvs.Key})");
            }
            Console.WriteLine();
        }
        public void TakeBook() => _isPresent = false;
       
        static public bool IsId(int id) => _library.ContainsKey(id);
        static public bool IsPresent(Book book) => book._isPresent;
        static public Book GetBook(int id) => _library[id];


    }
}