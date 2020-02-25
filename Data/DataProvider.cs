using System;

namespace Library
{
    class DataProvider : IDataProvider
    {
        private ILibManager libManager;

        private IBookLib books;

        public DataProvider(ILibManager libManager, IBookLib books)
        {
            this.libManager = libManager;
            this.books = books;

            this.ReadFromLibrary();
        }

        public IBookLib Books => this.books;

        public void WriteToLibrary()
        {            
            this.libManager.WriteBooks(Books.GetBooks());
        }

        public IBookLib ReadFromLibrary()
        {    
            var bookList = this.libManager.ReadBooks();
            this.books.InitializeLib();
            
            foreach (var book in bookList)
            {
                var newBook = new BookModel(book);
                this.books.AddBook(newBook, false);
            }
            
            return this.books;
        }
    }
}