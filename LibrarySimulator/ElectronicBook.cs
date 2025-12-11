using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace LibrarySimulator
{
    public class ElectronicBook : Book
    {
        private string _format;
        public ElectronicBook(string title, string author, int publicationYear, string format)
            : base(title, author, publicationYear)
        {
            this._type = BookType.Electronic;
            this._format = format;
        }

        protected override void ShowCreationMessage()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"The Electronic book \"{_title}\" has been created with ID \"{_id}\".");
            Console.ForegroundColor = ConsoleColor.White;
        }
        public override void ShowInformationAboutBook()
        {
            Console.WriteLine($"Title: \"{_title}\", Author \"{_author}\", ID: {_id}, Type: {_type}, Format: {_format}, " +
                $"Publication Year: {_publicationYear}, Present: {_isPresent}");
        }
    }
}