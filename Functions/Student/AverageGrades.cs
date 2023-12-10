using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_Lab_1_SQL.Functions.Student
{
    internal class AverageGrades
    {
        public static void ShowAverageGrades()
        {
            while (true)
            {
                using var connection = new DbConnectionManager().GetConnection();
                {
                    using (SqlCommand command = new SqlCommand(
                        @"SELECT
                            DISTINCT Courses.Course,
                            AVG(Courses.Grade) AS AvgGrade,
                            MAX(Courses.Grade) AS MaxGrade,
                            MIN(Courses.Grade) AS MinGrade
                        FROM
                            Courses
                        GROUP BY
                            Courses.Course;", connection))
                    {
                        try
                        {
                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                Console.Clear();
                                Console.WriteLine("\n\n\tListing summary of grades for each course: ");

                                Console.WriteLine("\n\t==========================================");

                                if (reader.HasRows)
                                {
                                    while (reader.Read())
                                    {
                                        string course = reader.GetString(reader.GetOrdinal("Course")).TrimEnd();
                                        double avgGrade = Convert.ToDouble(reader.GetDouble(reader.GetOrdinal("AvgGrade")));
                                        float maxGrade = Convert.ToSingle(reader.GetDouble(reader.GetOrdinal("MaxGrade")));
                                        float minGrade = Convert.ToSingle(reader.GetDouble(reader.GetOrdinal("MinGrade")));


                                        Console.WriteLine($"\n\tCourse: {course}");
                                        Console.WriteLine($"\tAverage Grade: {avgGrade:F2}");
                                        Console.WriteLine($"\tHighest Grade: {maxGrade}");
                                        Console.WriteLine($"\tLowest Grade: {minGrade}");
                                        Console.WriteLine("\n\t==========================================");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("No grades found.");
                                }

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

