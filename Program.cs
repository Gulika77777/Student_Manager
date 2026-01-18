using Student_Manager.Function;
using Student_Manager.Models;
using System;
using System.Collections.Generic;

Function function = new Function();

while (true)
{
    Console.WriteLine("\n===== Student Manager =====");
    Console.WriteLine("1. Add New Student");
    Console.WriteLine("2. View All Students");
    Console.WriteLine("3. Search Student by ID");
    Console.WriteLine("4. Update Student Grade");
    Console.WriteLine("5. Search Students by Name");
    Console.WriteLine("6. Search Student by Roll Number");
    Console.WriteLine("7. Sort Students");
    Console.WriteLine("8. Filter by Name and Grade");
    Console.WriteLine("9. Exit");
    Console.Write("Choose an option: ");

    string? choice = Console.ReadLine();

    try
    {
        switch (choice)
        {
            case "1":
                Console.Write("Student Name: ");
                string name = Console.ReadLine() ?? string.Empty;

                Console.Write("Roll Number: ");
                if (!int.TryParse(Console.ReadLine(), out int rollNumber))
                {
                    Console.WriteLine("Invalid roll number.");
                    break;
                }

                Console.Write("Grade (A-F): ");
                if (!char.TryParse(Console.ReadLine(), out char grade))
                {
                    Console.WriteLine("Invalid grade.");
                    break;
                }

                function.CreateNewStudent(name, rollNumber, grade);
                Console.WriteLine("Student added successfully!");
                break;

            case "2":
                function.ShowAllStudent();
                break;

            case "3":
                Console.Write("Enter Student ID: ");
                if (!int.TryParse(Console.ReadLine(), out int findId))
                {
                    Console.WriteLine("Invalid ID.");
                    break;
                }
                function.FindStudentById(findId);
                break;

            case "4":
                Console.Write("Enter Student ID: ");
                if (!int.TryParse(Console.ReadLine(), out int updId))
                {
                    Console.WriteLine("Invalid ID.");
                    break;
                }

                Console.Write("New Grade (A-F): ");
                if (!char.TryParse(Console.ReadLine(), out char newGrade))
                {
                    Console.WriteLine("Invalid grade.");
                    break;
                }

                function.UpdateStudentGrade(updId, newGrade);
                Console.WriteLine("Grade updated successfully!");
                break;

            case "5":
                Console.Write("Enter name to search: ");
                string searchName = Console.ReadLine() ?? string.Empty;

                var resultsByName = function.SearchByName(searchName);
                if (resultsByName.Count == 0)
                    Console.WriteLine("No students found.");
                else
                    foreach (var s in resultsByName)
                        Console.WriteLine($"{s.Id}: {s.Name}, Roll: {s.RollNumber}, Grade: {s.Grade}");
                break;

            case "6":
                Console.Write("Enter Roll Number: ");
                if (!int.TryParse(Console.ReadLine(), out int searchRoll))
                {
                    Console.WriteLine("Invalid roll number.");
                    break;
                }

                var studentByRoll = function.SearchByRollNumber(searchRoll);
                if (studentByRoll == null)
                    Console.WriteLine("Student not found.");
                else
                    Console.WriteLine($"{studentByRoll.Id}: {studentByRoll.Name}, Roll: {studentByRoll.RollNumber}, Grade: {studentByRoll.Grade}");
                break;

            case "7":
                Console.WriteLine("Sort by: 1-Name, 2-Grade, 3-RollNumber");
                string? sortOption = Console.ReadLine();

                List<Student> sortedList = new();

                switch (sortOption)
                {
                    case "1":
                        sortedList = function.SortByName();
                        break;
                    case "2":
                        sortedList = function.SortByGrade();
                        break;
                    case "3":
                        sortedList = function.SortByRollNumber();
                        break;
                    default:
                        Console.WriteLine("Invalid sort option.");
                        break;
                }

                foreach (var s in sortedList)
                    Console.WriteLine($"{s.Id}: {s.Name}, Roll: {s.RollNumber}, Grade: {s.Grade}");
                break;

            case "8":
                Console.Write("Enter name to filter: ");
                string filterName = Console.ReadLine() ?? string.Empty;

                Console.Write("Enter Grade to filter (A-F): ");
                if (!char.TryParse(Console.ReadLine(), out char filterGrade))
                {
                    Console.WriteLine("Invalid grade.");
                    break;
                }

                var filteredList = function.FilterByNameAndGrade(filterName, filterGrade);
                if (filteredList.Count == 0)
                    Console.WriteLine("No students match the filter.");
                else
                    foreach (var s in filteredList)
                        Console.WriteLine($"{s.Id}: {s.Name}, Roll: {s.RollNumber}, Grade: {s.Grade}");
                break;

            case "9":
                Console.WriteLine("Program ended.");
                return;

            default:
                Console.WriteLine("Invalid choice, please try again.");
                break;
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine("Error: " + ex.Message);
    }
}
