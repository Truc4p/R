using System;
using System.Collections.Generic;

namespace DesktopInfoSystem
{
    public class PersonDAL
    {
        // List to store person objects
        private List<Person> persons = new List<Person>();

        // Add a person to the list
        public void AddPerson(Person person)
        {
            persons.Add(person);
        }

        // Retrieve all persons
        public List<Person> GetAllPersons()
        {
            return persons;
        }

        // Retrieve persons by type
        public List<Person> GetPersonsByType(Type type)
        {
            return persons.FindAll(p => p.GetType() == type);
        }

        // Update a person's information
        public void UpdatePerson(int id, Person updatedPerson)
        {
            for (int i = 0; i < persons.Count; i++)
            {
                if (persons[i].ID == id)
                {
                    persons[i] = updatedPerson;
                    break;
                }
            }
        }

        // Delete a person by ID
        public void DeletePerson(int id)
        {
            persons.RemoveAll(p => p.ID == id);
        }
    }
}
