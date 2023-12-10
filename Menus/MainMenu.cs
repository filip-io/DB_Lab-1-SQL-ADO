using DB_Lab_1_SQL.Functions.School;
using DB_Lab_1_SQL.Functions.Staff;
using DB_Lab_1_SQL.Functions.Student;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_Lab_1_SQL.Menus
{
    internal class MainMenu
    {
        public static void MainMenuLaunch()
        {
            {
                while (true)
                {
                    Console.Clear();
                    Console.WriteLine("\n\n\t=== Welcome to ADO.NET School! ===");
                    Console.WriteLine("\n\tWhat would you like to do?");

                    Console.WriteLine("\n\t1. Show students");
                    Console.WriteLine("\t2. Show classes and participants");
                    Console.WriteLine("\t3. Add new student");
                    Console.WriteLine("\t4. Show recent grades");
                    Console.WriteLine("\t5. Show average grades");
                    Console.WriteLine("\t6. Show staff members");
                    Console.WriteLine("\t7. Add new staff member");
                    Console.WriteLine("\t8. Exit");

                    Console.Write("\n\tEnter your choice (1-8) and press ENTER: ");

                    Console.CursorVisible = true;
                    string userChoice = Console.ReadLine();

                    if (userChoice == "8")
                    {
                        Console.Clear();
                        Console.WriteLine("\n\n\tThank you for visiting! Closing the application...\n\n\n");
                        break;
                    }

                    switch (userChoice)
                    {
                        case "1":
                            ShowStudents.ShowAllStudents();
                            break;
                        case "2":
                            ShowClasses.ShowAllClasses();
                            break;
                        case "3":
                            NewStudent.AddStudent();
                            break;
                        case "4":
                            RecentGrades.ShowRecentGrades();
                            break;
                        case "5":
                            AverageGrades.ShowAverageGrades();
                            break;
                        case "6":
                            ShowStaff.ShowAllStaff();
                            break;
                        case "7":
                            NewStaff.AddStaff();
                            break;

                        default:
                            Console.WriteLine("\nInvalid choice! Please enter a number from 1 to 7. Press ENTER to try again.");
                            while (Console.ReadKey(true).Key != ConsoleKey.Enter) { }
                            Console.Clear();
                            continue;
                    }
                }
            }
        }
    }
}
