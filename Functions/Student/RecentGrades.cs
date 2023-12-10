using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_Lab_1_SQL.Functions.Student
{
    internal class RecentGrades
    {
        public static void ShowRecentGrades()
        {
            while (true)
            {                
                {
                    using var connection = new DbConnectionManager().GetConnection();
                    {
                        using (SqlCommand command = new SqlCommand(@"SELECT Students.FirstName, Students.LastName, Courses.Course, Courses.Grade, Courses.DateSet
                          FROM Students
                          JOIN Courses ON Students.Id = Courses.UserId
                          WHERE YEAR(Courses.DateSet) = YEAR(GETDATE())
                            AND MONTH(Courses.DateSet) = MONTH(GETDATE())
                          ORDER BY Students.FirstName ASC;", connection))
                        {
                            try
                            {
                                using (SqlDataReader reader = command.ExecuteReader())
                                {
                                    Console.Clear();
                                    Console.WriteLine("\n\n\tListing all grades set in the last month: ");
                                    Console.WriteLine("\t----------------------------------------");

                                    if (reader.HasRows)
                                    {
                                        while (reader.Read())
                                        {
                                            string firstName = reader.GetString(reader.GetOrdinal("FirstName")).TrimEnd();
                                            string lastName = reader.GetString(reader.GetOrdinal("LastName")).TrimEnd();
                                            string course = reader.GetString(reader.GetOrdinal("Course")).TrimEnd();
                                            double grade = reader.GetDouble(reader.GetOrdinal("Grade"));
                                            DateTime dateSet = reader.GetDateTime(reader.GetOrdinal("DateSet"));

                                            // Format date as "YYYY-MM-DD"
                                            string formattedDate = dateSet.ToString("yyyy-MM-dd");

                                            Console.WriteLine($"\n\t{firstName} {lastName} \n\tCourse: {course} \n\tGrade: {grade} \n\tDate set: {formattedDate}");
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("No grades found.");
                                    }

                                    Console.WriteLine("\n\t----------------------------------\n");

                                    Console.CursorVisible = false;
                                    Console.WriteLine("\tPress ENTER to return to Main Menu.");
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