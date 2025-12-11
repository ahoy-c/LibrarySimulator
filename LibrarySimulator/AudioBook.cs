using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySimulator
{
    public class AudioBook : Book
    {

        private string _durationHour;
        public AudioBook(string title, string author, int publicationYear, string duration)
            : base(title, author, publicationYear)
        {
            this._type = BookType.Audio;
            this._durationHour = duration;
        }

        protected override void ShowCreationMessage()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"The Audio book \"{_title}\" has been created with ID \"{_id}\".");
            Console.ForegroundColor = ConsoleColor.White;
        }
        public override void ShowInformationAboutBook()
        {
            Console.WriteLine($"Title: \"{_title}\", Author \"{_author}\", ID: {_id}, Type: {_type}, Duration: {_durationHour}, " +
                $"Publication Year: {_publicationYear}, Present: {_isPresent}");
        }
    }
}
