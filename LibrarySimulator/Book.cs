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

        protected string _title;
        protected string _author;
        protected int _publicationYear;
        protected bool _isPresent = true;
        protected int _id;
        protected BookType _type;
        public string Title { get; }
        public int Id { get; }

        static private Dictionary<int, Book> _library = new Dictionary<int, Book>();
        static private List<Book> _allBooks = new List<Book>();

        static private int _lastIdInLibrary = 0;
        protected enum BookType
        {
            Regular,
            Electronic,
            Audio
        }

        public Book(string title, string author, int publicationYear)
        {
            this._title = title;
            this.Title = _title;
            this._author = author;
            this._publicationYear = publicationYear;
            this._id = _lastIdInLibrary;
            this.Id = _id;
            this._type = BookType.Regular;

            _library.Add(_id, this);
            _allBooks.Add(this);
            _lastIdInLibrary++;

            ShowCreationMessage();
        }

        protected virtual void ShowCreationMessage()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"The book \"{_title}\" has been created with ID \"{_id}\".");
            Console.ForegroundColor = ConsoleColor.White;
        }
        static public void ListAllLibraryBooks()
        {
            Console.WriteLine("\nBooks available in the library:");
            foreach (var kvs in _library)
            {
                if (kvs.Value._isPresent) { Console.WriteLine($"- {kvs.Value._title} (ID: {kvs.Key})"); }
            }
            Console.WriteLine("Books currently borrowed:");
            foreach (var kvs in _library)
            {
                if (!kvs.Value._isPresent) { Console.WriteLine($"- {kvs.Value._title} (ID: {kvs.Key})"); }
            }
            Console.WriteLine();
        }

        public virtual void ShowInformationAboutBook()
        {
            Console.WriteLine($"Title: {_title}, Author {_author}, ID: {_id}, Type: {_type}, Publication Year: {_publicationYear}, Present: {_isPresent}");
        }

        static public void RemoveBook(int id)
        {
            _library.Remove(id);
        }
        public void TakeBook() => _isPresent = false;
        static public bool IsId(int id) => _library.ContainsKey(id);
        static public bool IsPresent(Book book) => book._isPresent;
        static public Book GetBook(int id) => _library[id];


    }
}