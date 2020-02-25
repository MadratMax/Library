using System;
using System.Collections.Generic;

namespace Library
{
    interface ILibManager
    {        
        IList<string> ReadBooks();

        void WriteBooks(IList<IBookModel> books);
    }
}