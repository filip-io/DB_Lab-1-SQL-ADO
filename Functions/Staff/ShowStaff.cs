using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_Lab_1_SQL.Functions.Staff
{
    internal class ShowStaff
    {
        public static void ShowAllStaff()
        {
            while (true)
            {
                Console.Clear();
                Console.Write("\nDo you want to show all staff members or staff members with a specific role? \n\nPlease type 1 for all staff or 2 for specific role and press ENTER (or type EXIT to return to main menu): ");

                string showStaffChoice = Console.ReadLine().ToUpper();
                string showStaff = "";

                if (showStaffChoice == "1" || showStaffChoice == "2")
                {
                    if (showStaffChoice == "1")
                    {
                        showStaff = "All";
                    }
                    else if (showStaffChoice == "2")
                    {
                        showStaff = "ByRole";
                    }
                }
                else if (showStaffChoice == "EXIT")
                {
                    return;
                }
                else
                {
                    Console.WriteLine("\nInvalid input. Please choose a valid option. Press ENTER to try again.");
                    while (Console.ReadKey(true).Key != ConsoleKey.Enter) { }
                    continue;
                }

                if (showStaff == "All")
                {
                    using var connection = new DbConnectionManager().GetConnection();
                    {
                        using (SqlCommand command = new SqlCommand(
                        @"SELECT Staff.FirstName, Staff.LastName, StaffRole.Role
                          FROM Staff
                          JOIN StaffRole ON Staff.Id = StaffRole.UserId", connection))
                        {
                            try
                            {
                                using (SqlDataReader reader = command.ExecuteReader())
                                {
                                    Console.Clear();
                                    Console.WriteLine("\n\n\tListing all staff of ADO.NET School: ");
                                    Console.WriteLine("\t--------------------------------------");

                                    if (reader.HasRows)
                                    {
                                        while (reader.Read())
                                        {
                                            string firstName = reader.GetString(reader.GetOrdinal("FirstName")).TrimEnd();
                                            string lastName = reader.GetString(reader.GetOrdinal("LastName")).TrimEnd();
                                            string role = reader.GetString(reader.GetOrdinal("Role")).TrimEnd();

                                            Console.WriteLine($"\n\t {firstName} {lastName}  \n\t {role}");
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("No staff found.");
                                    }

                                    Console.WriteLine("\n\t--------------------------------------\n");
                                }
                            }
                            catch (SqlException ex)
                            {
                                Console.WriteLine($"Error executing SQL query: {ex.Message}");
                            }
                            Console.CursorVisible = false;
                            Console.WriteLine("\n\tPress ENTER to return to Main Menu.");
                            while (Console.ReadKey(true).Key != ConsoleKey.Enter) { }
                            Console.Clear();
                            return;
                        }
                    }
                }
                else if (showStaff == "ByRole")
                {
                    Console.Clear();
                    Console.Write("\n  Please choose role of the staff members you want to show:\n\n  1 for [Teacher]\n  2 for [Administrator]\n  3 for [Principal]\n\n  Enter choice and press ENTER: ");

                    string roleChoiceString = Console.ReadLine();
                    int.TryParse(roleChoiceString, out int roleChoice);

                    string role;

                    switch (roleChoice)
                    {
                        case 1:
                            role = "Teacher";
                            break;
                        case 2:
                            role = "Administrator";
                            break;
                        case 3:
                            role = "Principal";
                            break;
                        default:
                            Console.WriteLine("\nInvalid input. Please choose a valid option. Press ENTER to try again.");
                            while (Console.ReadKey(true).Key != ConsoleKey.Enter) { }
                            continue;
                    }

                    string query = @"
                        SELECT Staff.FirstName, Staff.LastName, StaffRole.Role
                        FROM Staff
                        JOIN StaffRole ON Staff.Id = StaffRole.UserId
                        WHERE Role = @Role
                    ";

                    using var connection = new DbConnectionManager().GetConnection();
                    {
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@Role", role);
                            try
                            {
                                Console.Clear();
                                using (SqlDataReader reader = command.ExecuteReader())
                                {
                                    Console.Clear();
                                    Console.WriteLine($"\n\n\tListing all {role.ToLower()}'s of ADO.NET School: ");
                                    Console.WriteLine("\t-------------------------------------------");

                                    if (reader.HasRows)
                                    {
                                        while (reader.Read())
                                        {
                                            string firstName = reader.GetString(reader.GetOrdinal("FirstName")).TrimEnd();
                                            string lastName = reader.GetString(reader.GetOrdinal("LastName")).TrimEnd();
                                            string chosenRole = reader.GetString(reader.GetOrdinal("Role")).TrimEnd().ToLower();

                                            Console.WriteLine($"\n\t {firstName} {lastName}  \n\t {role}");
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine($"\n\t\tNo {role.ToLower()}'s found.");
                                    }

                                    Console.WriteLine("\n\t-------------------------------------------\n");

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
}