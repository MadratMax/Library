using System;

namespace Library
{
    interface IDataProvider
    {
        IBookLib Books {get;}

        void WriteToLibrary();

        IBookLib ReadFromLibrary();
    }
}