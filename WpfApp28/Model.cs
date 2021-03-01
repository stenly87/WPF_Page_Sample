using System;
using System.Collections.Generic;
using System.Text;

namespace WpfApp28
{
    public class Model
    {
        List<Person> people;

        public List<Person> GetPeople() => people;

        public Model()
        {
            people = new List<Person>(new[] { new Person { FirstName = "Евгений", LastName = "Петрович", Age = 53 }, new Person { FirstName = "Антон", LastName = "Пирожков", Age = 35 } });
        }

        public event EventHandler PeopleChanged;

        internal void SavePerson(Person selectedPerson)
        {
            if (!people.Contains(selectedPerson))
                people.Add(selectedPerson);
            PeopleChanged?.Invoke(this, null);
        }
    }
}
