using System;
using System.Collections.Generic;
using System.IO;

namespace Library
{
    class LibManager : ILibManager
    {
        FileInfo file;

        public LibManager(FileInfo file)
        {
            this.file = file;
        }

        public IList<string> ReadBooks()
        {
            string line = string.Empty;;
            var rows = new List<string>();
            StreamReader sb = null;

            using (var fs = new FileStream(this.file.Name, FileMode.Open, FileAccess.Read))
            {
                using (sb = new StreamReader(fs))
                {                
                    while ((line = sb.ReadLine()) != null)
                    {                        
                        rows.Add(line);
                    }
                }
            }           

            return rows;
        }

        public void WriteBooks(IList<IBookModel> books)
        {
            CheckDb();

            FileStream fs = null;
            StreamWriter sw = null;

            using (fs = new FileStream(this.file.Name, FileMode.Open, FileAccess.Write))
            {
                using (sw = new StreamWriter(fs))
                {               
                    foreach (var book in books)
                    {
                        sw.WriteLine(book.Year + @"/" + book.BookInfo, Environment.NewLine);  
                    }                                                   
                }      
            }
        }

        private void CheckDb()
        {
            if(!File.Exists(file.Name))
            {
                Logger.PrintCriticalError("Library data file does not exist!");
            }
        }      
    }
}