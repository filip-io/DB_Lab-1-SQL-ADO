using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_Lab_1_SQL.Functions.Student
{
    internal class ShowStudents
    {
        public static void ShowAllStudents()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("\n\n\t Please choose sorting order of students");
                Console.WriteLine("\n\t=========================================");
                Console.WriteLine("\n\t\t  1. First name \n\n\t\t  2. Last name");
                Console.WriteLine("\n\t=========================================");
                Console.WriteLine("\n\t Enter the number of your choice and press ENTER.");
                Console.WriteLine("\n\t (Type EXIT and press ENTER to return to main menu.)");
                Console.Write("\n\n\t Your choice: ");

                string nameSorting = Console.ReadLine().ToUpper();

                if (nameSorting != "1" && nameSorting != "2" && nameSorting != "EXIT")
                {
                    Console.WriteLine("\nPlease choose a valid option. Press ENTER to try again.");
                    Console.ReadLine();
                    continue;
                }
                else if (nameSorting == "EXIT")
                {
                    Console.Clear();
                    return;
                }

                string orderBy = (nameSorting == "1") ? "FirstName" : "LastName";

                Console.Clear();
                Console.WriteLine($"\nYou picked sorting by {orderBy}. Do you want to show students in ascending or descending order?");
                Console.Write("\nPlease press 1 for ascending or 2 for descending: ");

                string ascDesc = Console.ReadLine();

                if (ascDesc != "1" && ascDesc != "2")
                {
                    Console.WriteLine("\nPlease choose a valid option. Press ENTER to try again.");
                    Console.ReadLine();
                    continue;
                }

                string sortOrder = (ascDesc == "1") ? "ASC" : "DESC";

                string query = $@"
                        SELECT Students.FirstName, Students.LastName, Classes.ClassName
                        FROM Students
                        JOIN Classes ON Students.Id = Classes.UserId
                        ORDER BY {orderBy} {sortOrder}
                        ";

                using var connection = new DbConnectionManager().GetConnection();
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        try
                        {
                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                Console.Clear();
                                Console.WriteLine($"   \n\n\tStudents in ADO.NET School");
                                Console.WriteLine("\t___________________________________");

                                if (reader.HasRows)
                                {
                                    while (reader.Read())
                                    {
                                        string firstName = reader.GetString(reader.GetOrdinal("FirstName")).TrimEnd();
                                        string lastName = reader.GetString(reader.GetOrdinal("LastName")).TrimEnd();
                                        string className = reader.GetString(reader.GetOrdinal("ClassName")).TrimEnd();

                                        Console.WriteLine($"\n\t{firstName} {lastName} \t\tClass: {className}");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("\n\tNo students found.");
                                }

                                Console.WriteLine("\n\t___________________________________");
                                Console.CursorVisible = false;
                                Console.WriteLine("\n\tPress ENTER to return to Main Menu.");
                                while (Console.ReadKey(true).Key != ConsoleKey.Enter) { }
                                return;
                            }
                        }
                        catch (SqlException ex)
                        {
                            Console.WriteLine($"Error executing SQL query: {ex.Message}");
                        }
                    } 
                }
            }
        }
    }
}
