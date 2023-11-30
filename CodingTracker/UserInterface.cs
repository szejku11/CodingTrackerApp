using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingTracker
{
    internal static class UserInterface
    {
        public static void Start()
        {
            bool stop = false;
            while (!stop)
            {
                Menu();
                Console.Write("Option: ");
                string decision = Console.ReadLine();

                switch (decision)
                {
                    case "0":
                        stop = true;
                        break;
                    case "1":
                        //DisplayData();
                        Console.WriteLine();
                        Console.WriteLine("Click enter to go back");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    case "2":
                        DbManager.InsertRow();
                        break;
                    case "3":
                        //DatabaseHelper.UpdateRow();
                        break;
                    case "4":
                        //DatabaseHelper.DeleteRow();
                        break;
                    default:
                        Console.Write("Unkown key pressed. Please click enter to try again.");
                        Console.ReadLine();
                        break;
                }

            }
        }

        internal static (string startTime, string endTime) GetInput()
        {
            string? startDate = GetDateTime("Insert START date and time of coding session.");
            if (string.IsNullOrEmpty(startDate)) return (null, null);

            string? endDate = GetDateTime("Insert END date and time of coding session.");
            if (string.IsNullOrEmpty(endDate)) return (null, null);

            return (startDate, endDate);
        }

        private static string GetDateTime(string text)
        {
            Console.Clear();
            Console.WriteLine(text);
            Console.Write("Please use format dd-mm-yyyy hh:MM:ss (0 to go back): ");
            string? date = Console.ReadLine();

            if (date == "0")
            {
                return null;
            }

            while (!DateTime.TryParseExact(date, "dd-MM-yyyy HH:mm:ss", 
                   CultureInfo.InvariantCulture, DateTimeStyles.None, out _))
            {
                Console.Clear();
                Console.WriteLine(text);
                Console.Write("Invalid input, use format dd-mm-yyyy hh:MM:ss (0 to go back): ");
                date = Console.ReadLine();

                if (date == "0")
                {
                    return null;
                }
            }

            return date;
        }
        private static void Menu()
        {
            Console.Clear();
            Console.WriteLine("Coding Tracker Application");
            Console.WriteLine("\nMain menu");
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine("1 - View all records");
            Console.WriteLine("2 - Add new record");
            Console.WriteLine("3 - Update record");
            Console.WriteLine("4 - Delete record");
            Console.WriteLine("0 - Exit");
            Console.WriteLine("-------------------------------------------");
        }
    }
}
