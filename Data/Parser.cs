using System;

namespace Library
{
    class Parser
    {
        public static int Year;
        public static string Title;
        public static string Author;
        public static string ISBN;

        public static bool Success;
        
        public static void Parse(string row)
        {     
            try
            {
                Year = Convert.ToInt32(row.Split('/')[0]);            
                Title = row.Split('/')[1];
                Author = row.Split('/')[2];
                ISBN = row.Split('/')[3];

                Success = true;
            }
            catch (System.Exception)
            {
                Success = false;
                Logger.PrintError(String.Format("Wrong data format. \nBook entry is {0}. \nValid book format is 'year/title/author/isbn'", row) +
                "\nPlease, check the db source");
            }                                 
        }
    }
}