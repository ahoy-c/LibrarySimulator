using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySimulator
{
    public class BookBuilder
    {
        private string _title = "Unknown";
        private string _author = "Unknown";
        private int _publicationYear = 0;        


        public BookBuilder SetTitle(string title) { _title = title; return this; } 
        public BookBuilder SetAuthor(string author) { _author = author; return this; } 
        public BookBuilder SetPublicationYear(int publicationYear) { _publicationYear = publicationYear; return this; } 


        public Book Build() => new Book(_title, _author, _publicationYear);
        public ElectronicBook BuildElectronicBook(string format) => new ElectronicBook(_title, _author, _publicationYear, format);
        public AudioBook BuildAudioBook(string durationMin) => new AudioBook(_title, _author, _publicationYear, durationMin);

    }
}
