using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB_Lab_1_SQL.Functions.School;

namespace DB_Lab_1_SQL.Functions.Staff
{
    internal class NewStaff
    {
        public static void AddStaff()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("\nYou are about to add a new employee. Instructions will follow.");
                Console.WriteLine("\nPress ENTER to continue.");
                while (Console.ReadKey(true).Key != ConsoleKey.Enter) { }

                while (true)
                {
                    Console.Clear();
                    Console.WriteLine("\n\n\t Please choose the role of new employee");
                    Console.WriteLine("\n\t=======================================");
                    Console.WriteLine("\n\t\t  1. Teacher \n\n\t\t  2. Administrator \n\n\t\t  3. Principal");
                    Console.WriteLine("\n\t=======================================");
                    Console.WriteLine("\n\t Enter the number of your choice and press ENTER.");
                    Console.WriteLine("\n\t Type EXIT and press ENTER to return to main menu.");
                    Console.Write("\n\n\t Role: ");

                    string chosenEmployeeRole = Console.ReadLine().ToUpper();
                    string newEmployeeRole = "";

                    if (chosenEmployeeRole == "1" || chosenEmployeeRole == "2" || chosenEmployeeRole == "3")
                    {
                        if (chosenEmployeeRole == "1")
                        {
                            newEmployeeRole = "Teacher";
                        }
                        else if (chosenEmployeeRole == "2")
                        {
                            newEmployeeRole = "Administrator";
                        }
                        else if (chosenEmployeeRole == "3")
                        {
                            newEmployeeRole = "Principal";
                        }
                    }
                    else if (chosenEmployeeRole == "EXIT")
                    {
                        Console.Clear();
                        return;
                    }

                    else
                    {
                        Console.WriteLine("\nInvalid input. Please choose a valid option. Press ENTER to try again.");
                        while (Console.ReadKey(true).Key != ConsoleKey.Enter) { }
                        continue;
                    }

                    while (true)
                    {
                        Console.Clear();
                        Console.WriteLine("\n\t=======================================");
                        Console.WriteLine($"\n\t   New employee role will be set to: \n\n\t\t   [ {newEmployeeRole} ]");
                        Console.WriteLine("\n\t=======================================");
                        Console.WriteLine($"\n");

                        Console.Write($"\nPlease enter first name of new employee and press ENTER: ");

                        string inputFirstName = ValidateName.FormatName(Console.ReadLine(), "first name");

                        if (inputFirstName == "invalid")
                        {
                            continue;
                        }

                        Console.WriteLine($"\nFirst name of new employee will be set to: [ {inputFirstName} ]");

                        while (true)
                        {
                            Console.Write("\nPlease enter last name of new employee (or type BACK and press ENTER to change first name): ");

                            string inputLastName = ValidateName.FormatName(Console.ReadLine(), "last name");

                            if (inputLastName == "invalid")
                            {
                                continue;
                            }
                            else if (inputLastName == "Back")
                            {
                                inputFirstName = "invalid";
                                Console.Clear();
                                break;
                            }

                            while (true)
                            {
                                Console.Clear();
                                Console.WriteLine("\n\t=======================================");
                                Console.WriteLine($"\n\t   Name of new staff member:");
                                Console.WriteLine($"\n\t   {inputFirstName} {inputLastName}");
                                Console.WriteLine("\n\t=======================================");
                                Console.WriteLine($"\n");
                                Console.WriteLine("\nPlease type OK if naming is correct or type BACK to change last name.");

                                Console.Write("Confirmation: ");

                                string nameValidation = Console.ReadLine().ToUpper();

                                if (nameValidation == "OK")

                                    while (true)
                                    {
                                        string insertNewStaffQuery = @"
                                                INSERT INTO Staff (FirstName, LastName)
                                                VALUES (@FirstName, @LastName);
                                                SELECT SCOPE_IDENTITY();
                                                ";
                                        using var connection = new DbConnectionManager().GetConnection();
                                        {
                                            using (SqlCommand command = new SqlCommand(insertNewStaffQuery, connection))
                                                try
                                                {
                                                    command.Parameters.AddWithValue("@FirstName", inputFirstName);
                                                    command.Parameters.AddWithValue("@LastName", inputLastName);

                                                    decimal userIdDecimal = Convert.ToDecimal(command.ExecuteScalar());
                                                    int userId = (int)userIdDecimal;

                                                    string insertStaffRoleQuery = @"
                                                                INSERT INTO StaffRole (UserId, Role)
                                                                VALUES (@UserId, @newEmployeeRole);
                                                            ";

                                                    using (SqlCommand insertStaffRoleCommand = new SqlCommand(insertStaffRoleQuery, connection))
                                                    {
                                                        insertStaffRoleCommand.Parameters.AddWithValue("@UserId", userId);
                                                        insertStaffRoleCommand.Parameters.AddWithValue("@newEmployeeRole", newEmployeeRole);
                                                        insertStaffRoleCommand.ExecuteNonQuery();
                                                    }
                                                    Console.Clear();
                                                    Console.WriteLine("\n\n\t----------------------------------");
                                                    Console.WriteLine("\n\t New employee successfully added!");
                                                    Console.WriteLine($"\n\t   Name: {inputFirstName} {inputLastName}");
                                                    Console.WriteLine($"\t   Role: {newEmployeeRole}");
                                                    Console.WriteLine("\n\t----------------------------------");

                                                    Console.CursorVisible = false;
                                                    Console.WriteLine("\n\tPress ENTER to return to Main Menu.");
                                                    while (Console.ReadKey(true).Key != ConsoleKey.Enter) { }
                                                    return;
                                                }
                                                catch (SqlException ex)
                                                {
                                                    Console.WriteLine($"Error executing SQL query: {ex.Message}");
                                                }
                                        }
                                    }
                                else if (nameValidation == "BACK")
                                {
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("\nInvalid input. Please choose a valid option. Press ENTER to try again.");
                                    while (Console.ReadKey(true).Key != ConsoleKey.Enter) { }
                                    continue;
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
