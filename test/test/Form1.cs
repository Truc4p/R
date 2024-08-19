using System;

namespace DesktopInfoSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            PersonDAL personDAL = new PersonDAL();
            bool running = true;

            while (running)
            {
                Console.WriteLine("Menu:");
                Console.WriteLine("1. Add Person");
                Console.WriteLine("2. View All Persons");
                Console.WriteLine("3. View Persons by Role");
                Console.WriteLine("4. Edit Person");
                Console.WriteLine("5. Delete Person");
                Console.WriteLine("6. Exit");
                Console.Write("Choose an option: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        AddPerson(personDAL);
                        break;
                    case "2":
                        ViewAllPersons(personDAL);
                        break;
                    case "3":
                        ViewPersonsByRole(personDAL);
                        break;
                    case "4":
                        EditPerson(personDAL);
                        break;
                    case "5":
                        DeletePerson(personDAL);
                        break;
                    case "6":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid option. Try again.");
                        break;
                }
            }
        }

        static void AddPerson(PersonDAL personDAL)
        {
            Console.WriteLine("Add Person:");
            Console.Write("Enter ID: ");
            int id = int.Parse(Console.ReadLine());
            Console.Write("Enter Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter Surname: ");
            string surname = Console.ReadLine();
            Console.Write("Enter Role (Teacher/Admin/Student): ");
            string role = Console.ReadLine().ToLower();

            if (role == "teacher")
            {
                Console.Write("Enter Subject: ");
                string subject = Console.ReadLine();
                personDAL.AddPerson(new Teacher(id, name, surname, subject));
            }
            else if (role == "admin")
            {
                Console.Write("Enter Department: ");
                string department = Console.ReadLine();
                personDAL.AddPerson(new Admin(id, name, surname, department));
            }
            else if (role == "student")
            {
                Console.Write("Enter Course: ");
                string course = Console.ReadLine();
                personDAL.AddPerson(new Student(id, name, surname, course));
            }
            else
            {
                Console.WriteLine("Invalid role.");
            }
        }

        static void ViewAllPersons(PersonDAL personDAL)
        {
            Console.WriteLine("All Persons:");
            foreach (var person in personDAL.GetAllPersons())
            {
                person.DisplayInfo();
                Console.WriteLine();
            }
        }

        static void ViewPersonsByRole(PersonDAL personDAL)
        {
            Console.Write("Enter Role to View (Teacher/Admin/Student): ");
            string role = Console.ReadLine().ToLower();

            Type type = null;

            if (role == "teacher") type = typeof(Teacher);
            else if (role == "admin") type = typeof(Admin);
            else if (role == "student") type = typeof(Student);

            if (type != null)
            {
                var persons = personDAL.GetPersonsByType(type);
                foreach (var person in persons)
                {
                    person.DisplayInfo();
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("Invalid role.");
            }
        }

        static void EditPerson(PersonDAL personDAL)
        {
            Console.Write("Enter ID of person to edit: ");
            int id = int.Parse(Console.ReadLine());
            var person = personDAL.GetAllPersons().Find(p => p.ID == id);

            if (person != null)
            {
                Console.Write("Enter new Name: ");
                string name = Console.ReadLine();
                Console.Write("Enter new Surname: ");
                string surname = Console.ReadLine();

                if (person is Teacher)
                {
                    Console.Write("Enter new Subject: ");
                    string subject = Console.ReadLine();
                    personDAL.UpdatePerson(id, new Teacher(id, name, surname, subject));
                }
                else if (person is Admin)
                {
                    Console.Write("Enter new Department: ");
                    string department = Console.ReadLine();
                    personDAL.UpdatePerson(id, new Admin(id, name, surname, department));
                }
                else if (person is Student)
                {
                    Console.Write("Enter new Course: ");
                    string course = Console.ReadLine();
                    personDAL.UpdatePerson(id, new Student(id, name, surname, course));
                }
            }
            else
            {
                Console.WriteLine("Person not found.");
            }
        }

        static void DeletePerson(PersonDAL personDAL)
        {
            Console.Write("Enter ID of person to delete: ");
            int id = int.Parse(Console.ReadLine());
            personDAL.DeletePerson(id);
            Console.WriteLine("Person deleted.");
        }
    }
}
