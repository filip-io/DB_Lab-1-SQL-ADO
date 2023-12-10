using System.Data.SqlClient;
using System.Globalization;
using DB_Lab_1_SQL.Functions;
using DB_Lab_1_SQL.Menus;

namespace DB_Lab_1_SQL
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "ADO.NET School's Console App";
            Console.ForegroundColor = ConsoleColor.Green;
            MainMenu.MainMenuLaunch();
        }
    }
}