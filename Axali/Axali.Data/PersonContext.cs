using Homework16.Model;
using Microsoft.EntityFrameworkCore;

namespace Axali.Data;

public class PersonContext : DbContext
{
    public PersonContext(DbContextOptions<PersonContext> options) : base(options)
    {
        
    }
    public DbSet<Person> Persons { get; set; }
    public DbSet<Adress> Adresses { get; set; }
    
    
}