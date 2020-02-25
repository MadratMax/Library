using System;
using System.IO;

namespace Library
{
    class Program
    {        
        static void Main(string[] args)
        {
            InitializeDB(args);

            IBookLib books = new BookLib();
            ILibManager libManager = new LibManager(Settings.LibraryFile);
            IDataProvider dataProvider = new DataProvider(libManager, books);

            var menu = new Menu(libManager, dataProvider);

            while (true)
            {
                var choise = ConsoleMenu.MultipleChoice(true, "[ Add new book ]", "[ Open library ]", "[     Quit     ]");
            
                switch (choise)
                {
                    case 0:
                    {
                        menu.AddBookMenu();
                    }
                    break;

                    case 1:
                    {
                        menu.ShowLib();
                    }
                    break;

                    case 2:
                    {
                        menu.Quit();
                    }
                    break;
                }          
            }              
        }

        private static void InitializeDB(string[] args)
        {
            if(args != null && args.Length > 0)
            {
                if(File.Exists(args[0]))
                {
                    Settings.LibraryFile = new FileInfo(args[0]);
                }
                else
                {
                    Logger.PrintCriticalError("Specified library db file does not exist!");
                }
            }
            else
            {
                Logger.PrintCriticalError("Library db file is required!\nPlease, provide a library db file as argument");
            }
        }        
    }        
}
