using Homework20.Data;
using Homework20.Domain;
using Microsoft.EntityFrameworkCore;
using Homework20.Filters;
using Homework20.interfaces;

namespace Homework20.Services
{
    public class PersonService : IPerson<Person>
    {
        private readonly PersonContext _context;

        public PersonService(PersonContext context)
        {
            _context = context; 
        }

        public IEnumerable<Person> GetAll() => _context.Persons.ToList();

        public Person GetById(int id) => _context.Persons.FirstOrDefault(p => p.Id == id);

        public Person Add(Person person)
        {
            _context.Persons.Add(person);
            _context.SaveChanges();
            return person;
        }

        public bool Delete(int id)
        {
            var person = _context.Persons.FirstOrDefault(p => p.Id == id);
            if (person == null) return false;
            _context.Persons.Remove(person);
            _context.SaveChanges();
            return true;
        }

        public Person Update(int id, Person newPerson)
        {
            var person = _context.Persons.FirstOrDefault(p => p.Id == id);
            if (person == null) return null;

            person.FirstName = newPerson.FirstName;
            person.LastName = newPerson.LastName;
            person.Salary = newPerson.Salary;
            person.JobPosition = newPerson.JobPosition;
            person.AdressId = newPerson.AdressId;
            person.CreateDate = newPerson.CreateDate;

            _context.SaveChanges();
            return person;
        }

        public IEnumerable<Person> Filter(PersonFilter filter)
        {
            return _context.Persons.Where(p => p.Salary >= filter.Salary).ToList();
        }
    }
}