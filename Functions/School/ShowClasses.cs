using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_Lab_1_SQL.Functions.School
{
    internal class ShowClasses
    {
        public static void ShowAllClasses()
        {
            while (true)
            {
                /* Get SqlConnection object via GetConnection method. 
                   Using statement to dispose connection and close it when exiting the code block. */
                using var connection = new DbConnectionManager().GetConnection();
                {
                    // SQL command DISTINCT to select only unique class names from the Classes table
                    using (SqlCommand command = new SqlCommand("SELECT DISTINCT ClassName FROM Classes", connection))
                    {
                        try
                        {
                            // Execute the SQL command and read the results
                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                Console.Clear();
                                Console.WriteLine("\n\tListing all classes: ");
                                Console.WriteLine("\n\t------------------------------");

                                // Check if there are any rows returned
                                if (reader.HasRows)
                                {
                                    // Loop through rows if any found and display the class names
                                    while (reader.Read())
                                    {
                                        string className = reader.GetString(reader.GetOrdinal("ClassName")).TrimEnd();
                                        Console.Write($"\t      {className}");
                                    }
                                }
                                else
                                {
                                    // Message to be displayed if no classes are found
                                    Console.WriteLine("\tNo classes found.");
                                    Console.CursorVisible = false;
                                    Console.WriteLine("\n\tPress ENTER to return to Main Menu.");
                                    while (Console.ReadKey(true).Key != ConsoleKey.Enter) { }
                                    return;
                                }

                                Console.WriteLine("\n\t------------------------------\n");
                            }
                        }
                        catch (SqlException ex)
                        {
                            Console.WriteLine($"Error executing SQL query: {ex.Message}");
                        }
                    }

                    // Let user select class by input
                    Console.Write("\nPlease pick the class you want to display and press ENTER: ");
                    string inputClassName = Console.ReadLine().ToUpper();

                    // Check if user input is a valid class name
                    if (inputClassName == "A" || inputClassName == "B" || inputClassName == "C")
                    {
                        while (true)
                        {
                            Console.Clear();
                            Console.WriteLine($"\nYou picked class {inputClassName}.");
                            Console.WriteLine("-------------------");
                            Console.Write("\nDo you want to sort students by first name or last name? \n\nPlease enter 1 for first name or 2 for last name and press ENTER (or type BACK to pick another class): ");

                            string nameSorting = Console.ReadLine().ToUpper();
                            string orderBy = "";

                            // Check user input for sorting preference
                            if (nameSorting == "1" || nameSorting == "2")
                            {
                                if (nameSorting == "1")
                                {
                                    orderBy = "FirstName";
                                }
                                else if (nameSorting == "2")
                                {
                                    orderBy = "LastName";
                                }
                            }
                            else if (nameSorting == "BACK")
                            {
                                break;
                            }
                            else
                            {
                                // Display error message if invalid user input
                                Console.WriteLine("\nInvalid input. Please choose a valid option. Press ENTER to try again.");
                                while (Console.ReadKey(true).Key != ConsoleKey.Enter) { }
                                continue;
                            }
                            Console.Clear();
                            Console.WriteLine($"\nYou picked sorting by {orderBy}. Do you want to show students in ascending or descending order?");
                            Console.Write("\nPlease press 1 for ascending or 2 for descending: ");

                            string ascDesc = Console.ReadLine();

                            // Check user input for ascending or descending ordering of student names
                            if (ascDesc != "1" && ascDesc != "2")
                            {
                                Console.WriteLine("\nPlease choose a valid option. Press ENTER to try again.");
                                Console.ReadLine();
                                continue;
                            }

                            string sortOrder = (ascDesc == "1") ? "ASC" : "DESC";

                            /* SQL query to retrieve students in user selected class, order by user choice.
                               orderBy and sortOrder not paramterized because syntax not supported. Input is
                               already valided so no risk for SQL injection. ClassName is also already validated
                               and only parameterized for show and practice purposes. */
                            string query = $@"
                                    SELECT Students.FirstName, Students.LastName
                                    FROM Students
                                    JOIN Classes ON Student_ID = Classes.Class_ID
                                    WHERE ClassName = @ClassName
                                    ORDER BY {orderBy} {sortOrder}
                                "; 

                            using (SqlCommand command = new SqlCommand(query, connection))
                            {
                                // Parameterization of user input 'inputClassName'
                                command.Parameters.AddWithValue("@ClassName", inputClassName);
                                try
                                {
                                    Console.Clear();
                                    Console.WriteLine($"\n\n\t    Participants in class {inputClassName}");
                                    using (SqlDataReader reader = command.ExecuteReader())
                                    {
                                        Console.WriteLine("\t--------------------------------");

                                        // Check if there are any rows returned
                                        if (reader.HasRows)
                                        {
                                            // Loop through rows if any found and display the names of students in chosen class
                                            while (reader.Read())
                                            {
                                                string firstName = reader.GetString(reader.GetOrdinal("FirstName")).TrimEnd();
                                                string lastName = reader.GetString(reader.GetOrdinal("LastName")).TrimEnd();
                                                Console.WriteLine($"\n\t\t{firstName} {lastName}");
                                            }
                                        }
                                        else
                                        {
                                            // Message to be displayed if no students are found in the selected class
                                            Console.WriteLine($"\tNo students found in class {inputClassName}");
                                        }
                                        Console.WriteLine("\n\t--------------------------------");

                                        // Hide cursor for a cleaner look
                                        Console.CursorVisible = false;
                                        Console.WriteLine("\n\tPress ENTER to return to Main Menu.");
                                        // Wait for user to explicitly press the ENTER key and do nothing until it is pressed
                                        while (Console.ReadKey(true).Key != ConsoleKey.Enter) { }
                                        return;
                                    }
                                }
                                catch (SqlException ex)
                                {
                                    // Display SQL Exception error to the user if encountered
                                    Console.WriteLine($"Error executing SQL query: {ex.Message}");
                                }
                            }
                        }
                    }
                    else
                    {
                        // Display error message if invalid user input for class name
                        Console.WriteLine("\nInvalid input. Please choose a valid option. Press ENTER to try again.");
                        while (Console.ReadKey(true).Key != ConsoleKey.Enter) { }
                    }
                }
            }
        }
    }
}



