using Homework20.Domain;
using Homework20.Filters;
using Homework20.interfaces;

namespace Homework20.Tests;

public class PersonServiceFake : IPerson<Person>
{
    private readonly List<Person> _people;

    public PersonServiceFake()
    {
        _people = new List<Person>()
        {
            new Person
            {
                Id = 1,
                CreateDate = DateTime.Now,
                FirstName = "Saba",
                LastName = "Jikurashvili",
                JobPosition = "Software Developer",
                Salary = 3500.00,
                WorkExperience = 2.5,
                AdressId = 1
            },
            new Person
            {
                Id = 2,
                CreateDate = DateTime.Now,
                FirstName = "Giorgi",
                LastName = "Beridze",
                JobPosition = "System Analyst",
                Salary = 2800.00,
                WorkExperience = 3.0,
                AdressId = 2
            },
            new Person
            {
                Id = 3,
                CreateDate = DateTime.Now,
                FirstName = "Nino",
                LastName = "Tsereteli",
                JobPosition = "HR Manager",
                Salary = 2200.00,
                WorkExperience = 4.0,
                AdressId = 3
            },
            new Person
            {
                Id = 4,
                CreateDate = DateTime.Now,
                FirstName = "Luka",
                LastName = "Khutsishvili",
                JobPosition = "Database Administrator",
                Salary = 3000.00,
                WorkExperience = 3.5,
                AdressId = 4
            },
            new Person
            {
                Id = 5,
                CreateDate = DateTime.Now,
                FirstName = "Ana",
                LastName = "Kapanadze",
                JobPosition = "Project Manager",
                Salary = 4000.00,
                WorkExperience = 5.0,
                AdressId = 5
            },
            new Person
            {
                Id = 6,
                CreateDate = DateTime.Now,
                FirstName = "Davit",
                LastName = "Mchedlidze",
                JobPosition = "UI/UX Designer",
                Salary = 2700.00,
                WorkExperience = 2.0,
                AdressId = 6
            },
            new Person
            {
                Id = 7,
                CreateDate = DateTime.Now,
                FirstName = "Mari",
                LastName = "Khvedelidze",
                JobPosition = "Network Engineer",
                Salary = 3200.00,
                WorkExperience = 4.5,
                AdressId = 7
            }
        };
    }
    public Person Add(Person person)
    {
        person.Id = _people.Count + 1;
        _people.Add(person);
        return person;
    }

    public IEnumerable<Person> GetAll()
    {
        return _people;
    }

    public Person GetById(int id)
    {
        return _people.FirstOrDefault(p => p.Id == id);
    }

    public IEnumerable<Person> Filter(PersonFilter filter)
    {
        var matched = _people.Where(p => p.Salary >= filter.Salary);
        return matched;
    }

    public Person Update(int id, Person newPerson)
    {
        var person = _people.FirstOrDefault(p => p.Id == id);
        if (person == null) return null;

        person.FirstName = newPerson.FirstName;
        person.LastName = newPerson.LastName;
        person.Salary = newPerson.Salary;
        person.JobPosition = newPerson.JobPosition;
        person.AdressId = newPerson.AdressId;
        person.CreateDate = newPerson.CreateDate;
        
        return person;
    }

    public bool Delete(int id)
    {
        var person = _people.FirstOrDefault(p => p.Id == id);
        if (person == null) return false;
        _people.Remove(person);
        return true;
    }
}