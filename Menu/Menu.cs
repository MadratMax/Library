using System;

namespace Library
{
    class Menu
    {        
        ILibManager libManager;
        IDataProvider dataProvider;

        public Menu(
            ILibManager libManager,
            IDataProvider dataProvider)
        {
            this.libManager = libManager;
            this.dataProvider = dataProvider;
        }

        public void ShowLib()
        {   
            Console.Clear();
            Console.WriteLine("Year | Title | Author | ISBN");
            System.Console.WriteLine("");
            var separator = @" | ";
            var bookLib = this.dataProvider.Books.GetBooks();            
            
            foreach (var book in bookLib)
            {
                if(dataProvider.Books.NewBook != null &&
                 book.BookInfo == dataProvider.Books.NewBook.BookInfo && 
                 book.Year == dataProvider.Books.NewBook.Year)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }   
                else
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }      
                       
                if (book.Year < 1 || Math.Ceiling(Math.Log10(book.Year)) > 4)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                }                
                
                Console.WriteLine(
                    book.Year + 
                    separator + 
                    book.Title + 
                    separator + 
                    book.Author + 
                    separator + 
                    book.ISBN);

                Console.ResetColor();
            }

            this.ShowAnyKeyMessage();
        }

        public void AddBookMenu()
        {
            Console.Clear();      
            Console.WriteLine("Enter publishing year");
            string _year = Console.ReadLine();

            if (int.TryParse(_year, out int year))
            {
                Console.WriteLine("Enter book title");
                var name = Console.ReadLine().Replace(@"/", @"\");
                Console.WriteLine("Enter book author");
                var author = Console.ReadLine().Replace(@"/", @"\");
                Console.WriteLine("Enter book isbn");
                var isbn = Console.ReadLine().Replace(@"/", @"\");
                var newBook = new BookModel(year, name, author, isbn);                
                var choise = ConsoleMenu.MultipleChoice(false, "[  update db  ]", "[ back to main ]");

                switch (choise)
                {
                    case 0:
                    {
                        this.dataProvider.Books.AddBook(newBook, true);
                        this.dataProvider.WriteToLibrary();                        
                        Logger.PrintMessage("Book added");
                    }
                    break;
                    case 1:
                    {
                        break;
                    }
                }                                     
            }
            else
            {
                Logger.PrintError("Wrong publishing year format");          
            }                  
        }

        public void Quit()
        {
            Console.Clear();
            Environment.Exit(-1);
        }

        private void ShowAnyKeyMessage()
        {
            Console.WriteLine("\n---\nPress any key to back to main");
            Console.ReadKey();
        }
    }
}