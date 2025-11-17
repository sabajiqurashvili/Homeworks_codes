using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Design;
using Homework20.Domain;
using Homework20.Filters;

namespace Homework20.interfaces;

public interface IPerson<Person>
{
   IActionResult  Add(Person person); // add person
   IActionResult GetAll(); // get all 
   IActionResult GetById(int id); // get person by id
   IActionResult Filter(PersonFilter filter);
   IActionResult Update(int id, Person newPerson);
   IActionResult Delete(int id);


}