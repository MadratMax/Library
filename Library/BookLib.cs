using System;
using System.Collections.Generic;

namespace Library
{
    class BookLib : IBookLib
    {
        IList<IBookModel> books;

        public BookLib()
        {
            this.books = new List<IBookModel>();            
        }       

        public IBookModel NewBook {get; set;}

        public void InitializeLib()
        {
            this.books = null;
            this.books = new List<IBookModel>(); 
        }

        public IList<IBookModel> GetBooks()
        {
            return this.books;
        }

        public void AddBook(IBookModel book, bool newBook)
        {
            if(!this.books.Contains(book))
            {                    
                books.Add(book);  
                
                if(newBook)
                {
                    NewBook = book; 
                }                  

                this.SortBooks();                         
            }
        }

        private void SortBooks()
        {
            var sortedBooks = new SortedDictionary<int, IList<string>>();            
            
            foreach (var book in this.books)
            {
                if(sortedBooks.ContainsKey(book.Year))
                {
                    sortedBooks[book.Year].Add(book.BookInfo);
                }
                else
                {
                    sortedBooks.Add(book.Year, new List<string> {book.BookInfo});
                }                    
            }

            this.InitializeLib();

            foreach(KeyValuePair<int, IList<string>> book in sortedBooks)
            {
                if(book.Value.Count > 1)
                {
                    foreach (var item in book.Value)
                    {
                        IBookModel newBook = new BookModel(book.Key + @"/" + item);
                        this.books.Add(newBook);
                    }
                }
                else
                {
                    IBookModel newBook = new BookModel(book.Key + @"/" + book.Value[0]);
                    this.books.Add(newBook);
                }                        
            } 
        }        
    }    
}