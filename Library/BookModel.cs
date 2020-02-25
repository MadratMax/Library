using System;

namespace Library
{
    class BookModel : IBookModel
    {
        string title;
        string author;
        string isbn;
        int year;

        public BookModel(int year, string title, string author, string isbn)
        {            
            this.year = year;
            this.title = title;
            this.author = author;
            this.isbn = isbn;
        }

        public BookModel(string bookInfo)
        {            
            Parser.Parse(bookInfo);

            if(Parser.Success)
            {
                this.year = Parser.Year;
                this.title = string.IsNullOrWhiteSpace(Parser.Title) ? "???" : Parser.Title;
                this.author = string.IsNullOrWhiteSpace(Parser.Author) ? "???" : Parser.Author;
                this.isbn = string.IsNullOrWhiteSpace(Parser.ISBN) ? "???" : Parser.ISBN;
            }
            else
            {
                this.year = 0;
                this.title = "error";
                this.author = "error";
                this.isbn = "error";
            }
        }

        public int Year => this.year;

        public string Title => this.title;

        public string Author => this.author;

        public string ISBN => this.isbn;

        public string BookInfo => this.GetInfo();

        private string GetInfo()
        {
            var separator = @"/";
            return this.title + separator + this.author + separator + this.isbn;
        }
    }
}