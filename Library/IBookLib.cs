using System;
using System.Collections.Generic;

namespace Library
{
    interface IBookLib
    {
        IList<IBookModel> GetBooks();

        IBookModel NewBook {get; set;}

        void AddBook(IBookModel bookModel, bool newBook);    

        void InitializeLib();  
    }
}