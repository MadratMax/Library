using System;

namespace Library
{
    interface IBookModel
    {
        int Year {get;}
        string Title {get;}
        string Author {get;}
        string ISBN {get;}
        string BookInfo {get;}
    }
}