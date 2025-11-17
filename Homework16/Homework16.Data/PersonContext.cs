using Homework16.Model;
using Microsoft.EntityFrameworkCore;

namespace Homework16.Data;

public class PersonContext : DbContext
{
    public PersonContext(DbContextOptions<PersonContext> options) : base(options)
    {
        
    }

    DbSet<Person> Persons { get; set; }
    DbSet<Adress> Adresses { get; set; }
    
}