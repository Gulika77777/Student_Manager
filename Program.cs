using Student_Manager.Function;
using System.Text;

Function function = new Function();

while (true)
{
    Console.WriteLine("\n===== Student Manager =====");

    Console.WriteLine("1. Add New Student");
    Console.WriteLine("2. View All Students");
    Console.WriteLine("3. Search Student by ID");
    Console.WriteLine("4. Update Student Grade");
    Console.WriteLine("5. Exit");
    Console.Write("Choose an option: ");

    string choice = Console.ReadLine();

    try
    {
        switch (choice)
        {
            case "1":
                Console.Write("Enter ID: ");
                int id = int.Parse(Console.ReadLine());

                Console.Write("Student Name: ");
                string name = Console.ReadLine();

                Console.Write("Roll Number: ");
                int rollNumber = int.Parse(Console.ReadLine());

                Console.Write("Grade (A-F): ");
                char grade = char.Parse(Console.ReadLine());

                function.CreateNewStudent(id, name, rollNumber, grade);
                Console.WriteLine("Student added successfully!");
                break;

            case "2":
                function.ShowAllStudent();
                break;

            case "3":
                Console.Write("Enter ID: ");
                int findId = int.Parse(Console.ReadLine());
                function.FindStudentById(findId);
                break;

            case "4":
                Console.Write("Enter ID: ");
                int updId = int.Parse(Console.ReadLine());

                Console.Write("New Grade (A-F): ");
                char newGrade = char.Parse(Console.ReadLine());

                function.UpdateStudentGrade(updId, newGrade);
                Console.WriteLine("Grade updated successfully!");
                break;

            case "5":
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

