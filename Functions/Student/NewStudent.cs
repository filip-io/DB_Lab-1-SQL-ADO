using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB_Lab_1_SQL.Functions.School;

namespace DB_Lab_1_SQL.Functions.Student
{
    internal class NewStudent
    {
        public static void AddStudent()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("\nYou are about to add a new student. Instructions will follow.");
                Console.WriteLine("\nPress ENTER to continue.");
                while (Console.ReadKey(true).Key != ConsoleKey.Enter) { }

                while (true)
                {
                    Console.Clear();
                    Console.WriteLine("\n\n\t Please choose which course the new student enrolls in");
                    Console.WriteLine("\n\t=======================================");
                    Console.WriteLine("\n\t\t  1. Programming \n\n\t\t  2. Finance \n\n\t\t  3. HiFi");
                    Console.WriteLine("\n\t=======================================");
                    Console.WriteLine("\n\t Enter the number of your choice and press ENTER.");
                    Console.WriteLine("\n\t Type EXIT and press ENTER to return to main menu.");
                    Console.Write("\n\n\t Course no: ");

                    string chosenCourse = Console.ReadLine().ToUpper();
                    string newStudentCourse = "";

                    if (chosenCourse == "1" || chosenCourse == "2" || chosenCourse == "3")
                    {
                        if (chosenCourse == "1")
                        {
                            newStudentCourse = "Programming";
                        }
                        else if (chosenCourse == "2")
                        {
                            newStudentCourse = "Finance";
                        }
                        else if (chosenCourse == "3")
                        {
                            newStudentCourse = "HiFi";
                        }
                    }
                    else if (chosenCourse == "EXIT")
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
                        Console.WriteLine($"\n\t   New student will be enrolled in: \n\n\t\t   [ {newStudentCourse} ]");
                        Console.WriteLine("\n\t=======================================");
                        Console.WriteLine($"\n");

                        Console.WriteLine($"\nPlease enter first name of new student and press ENTER. ");
                        Console.WriteLine($"(Or type BACK to change course).");
                        Console.Write("\nFirst name: ");

                        string inputFirstName = ValidateName.FormatName(Console.ReadLine(), "first name");

                        if (inputFirstName == "invalid")
                        {
                            continue;
                        }
                        else if (inputFirstName == "Back")
                        {
                            break;
                        }

                        Console.WriteLine($"\nFirst name of new student will be set to: [ {inputFirstName} ]");

                        while (true)
                        {
                            Console.Write("\nPlease enter last name of new student (or type BACK and press ENTER to change first name): ");

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
                                Console.WriteLine($"\n\t   Name of new student:");
                                Console.WriteLine($"\n\t   {inputFirstName} {inputLastName}");
                                Console.WriteLine("\n\t=======================================");
                                Console.WriteLine($"\n");
                                Console.WriteLine("\nPlease type OK if naming is correct or type BACK to change last name.");

                                Console.Write("Confirmation: ");

                                string nameValidation = Console.ReadLine().ToUpper();

                                if (nameValidation == "OK")

                                    while (true)
                                    {
                                        Console.Clear();
                                        Console.WriteLine("\n\n\t Please choose which class the new student should join:");
                                        Console.WriteLine("\n\t=======================================================");
                                        Console.WriteLine("\n\t\t  1. Class A \n\n\t\t  2. Class B \n\n\t\t  3. Class C");
                                        Console.WriteLine("\n\t=======================================================");
                                        Console.WriteLine("\n\t Enter the number of your choice and press ENTER.");
                                        Console.WriteLine("\n\t Type EXIT and press ENTER to return to main menu.");
                                        Console.Write("\n\n\t Class no: ");

                                        string chosenClass = Console.ReadLine().ToUpper();
                                        string newStudentClass = "";

                                        if (chosenClass == "1" || chosenClass == "2" || chosenClass == "3")
                                        {
                                            if (chosenClass == "1")
                                            {
                                                newStudentClass = "A";
                                            }
                                            else if (chosenClass == "2")
                                            {
                                                newStudentClass = "B";
                                            }
                                            else if (chosenClass == "3")
                                            {
                                                newStudentClass = "C";
                                            }
                                        }
                                        else if (chosenClass == "EXIT")
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


                                        string insertNewStudentQuery = @"
                                            INSERT INTO Students (FirstName, LastName)
                                            VALUES (@FirstName, @LastName);
                                            SELECT SCOPE_IDENTITY();
                                        ";

                                        using var connection = new DbConnectionManager().GetConnection();
                                        {
                                            using (SqlCommand command = new SqlCommand(insertNewStudentQuery, connection))
                                                try
                                                {
                                                    command.Parameters.AddWithValue("@FirstName", inputFirstName);
                                                    command.Parameters.AddWithValue("@LastName", inputLastName);

                                                    decimal userIdDecimal = Convert.ToDecimal(command.ExecuteScalar());
                                                    int userId = (int)userIdDecimal;

                                                    string insertStudentCourseQuery = @"
                                                    INSERT INTO Courses (UserId, Course) 
                                                    VALUES (@UserId, @newStudentCourse);
                                                ";

                                                    using (SqlCommand insertStudentRoleCommand = new SqlCommand(insertStudentCourseQuery, connection))
                                                    {
                                                        insertStudentRoleCommand.Parameters.AddWithValue("@UserId", userId);
                                                        insertStudentRoleCommand.Parameters.AddWithValue("@newStudentCourse", newStudentCourse);

                                                        insertStudentRoleCommand.ExecuteNonQuery();
                                                    }

                                                    using (SqlCommand insertStudentClassCommand = new SqlCommand(
                                                        @"INSERT INTO Classes (UserId, ClassName)
                                                      VALUES (@UserId, @ClassName)", connection))
                                                    {
                                                        insertStudentClassCommand.Parameters.AddWithValue("@UserId", userId);
                                                        insertStudentClassCommand.Parameters.AddWithValue("@ClassName", newStudentClass);

                                                        insertStudentClassCommand.ExecuteNonQuery();
                                                    }
                                                    Console.Clear();
                                                    Console.WriteLine("\n\n\t----------------------------------");
                                                    Console.WriteLine("\n\t New student successfully added!");
                                                    Console.WriteLine($"\n\t   Name: \t{inputFirstName} {inputLastName}");
                                                    Console.WriteLine($"\t   Course: \t{newStudentCourse}");
                                                    Console.WriteLine($"\t   Class: \t{newStudentClass}");
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
