using System;
using System.Collections.Generic;

namespace DesktopInfoSystem
{
    // Base class Person
    public class Person
    {
        // Encapsulated fields
        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        // Constructor
        public Person(int id, string name, string surname)
        {
            ID = id;
            Name = name;
            Surname = surname;
        }

        // Virtual method for displaying details, can be overridden
        public virtual void DisplayInfo()
        {
            Console.WriteLine($"ID: {ID}, Name: {Name} {Surname}");
        }
    }

    // Derived class Teacher
    public class Teacher : Person
    {
        public string Subject { get; set; }

        public Teacher(int id, string name, string surname, string subject)
            : base(id, name, surname)
        {
            Subject = subject;
        }

        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"Subject: {Subject}");
        }
    }

    // Derived class Admin
    public class Admin : Person
    {
        public string Department { get; set; }

        public Admin(int id, string name, string surname, string department)
            : base(id, name, surname)
        {
            Department = department;
        }

        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"Department: {Department}");
        }
    }

    // Derived class Student
    public class Student : Person
    {
        public string Course { get; set; }

        public Student(int id, string name, string surname, string course)
            : base(id, name, surname)
        {
            Course = course;
        }

        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"Course: {Course}");
        }
    }
}
