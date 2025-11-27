using Student_Manager.Function;

Function function = new Function();

while (true)
{
    Console.WriteLine("\n===== Student Manager =====");
    Console.WriteLine("1. ახალი სტუდენტის დამატება");
    Console.WriteLine("2. ყველა სტუდენტის ნახვა");
    Console.WriteLine("3. სტუდენტის ძებნა ID-ის მიხედვით");
    Console.WriteLine("4. მოსწავლის შეფასების შეცვლა");
    Console.WriteLine("5. Exit");
    Console.Write("აირჩიეთ ოპერაცია: ");

    string choice = Console.ReadLine();

    try
    {
        switch (choice)
        {
            case "1":
                Console.Write("შეიყვანეთ ID: ");
                int id = int.Parse(Console.ReadLine());

                Console.Write("სტუდენტის სახელი: ");
                string name = Console.ReadLine();

                Console.Write("Roll Number: ");
                int rollNumber = int.Parse(Console.ReadLine());

                Console.Write("Grade (A-F): ");
                char grade = char.Parse(Console.ReadLine());

                function.CreateNewStudent(id, name, rollNumber, grade);
                Console.WriteLine("სტუდენტი წარმატებით დაემატა!");
                break;

            case "2":
                function.ShowAllStudent();
                break;

            case "3":
                Console.Write("შეიყვანეთ ID: ");
                int findId = int.Parse(Console.ReadLine());
                function.FindStudentById(findId);
                break;

            case "4":
                Console.Write("შეიყვანეთ ID: ");
                int updId = int.Parse(Console.ReadLine());

                Console.Write("ახალი Grade (A-F): ");
                char newGrade = char.Parse(Console.ReadLine());

                function.UpdateStudentGrade(updId, newGrade);
                Console.WriteLine("შეფასება განახლდა!");
                break;

            case "5":
                Console.WriteLine("პროგრამა დასრულდა.");
                return;

            default:
                Console.WriteLine("არასწორი არჩევანია, სცადეთ თავიდან.");
                break;
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine("შეცდომა: " + ex.Message);
    }
}

