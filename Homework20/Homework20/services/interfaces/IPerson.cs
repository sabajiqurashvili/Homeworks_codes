using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Design;
using Homework20.Domain;
using Homework20.Filters;

namespace Homework20.interfaces;

public interface IPerson<Person>
{
    Person Add(Person person);                      // Returns the added person
    IEnumerable<Person> GetAll();                  // Returns all persons
    Person GetById(int id);                        // Returns single person
    IEnumerable<Person> Filter(PersonFilter filter); // Returns filtered persons
    Person Update(int id, Person newPerson);       // Returns updated person
    bool Delete(int id);      

}