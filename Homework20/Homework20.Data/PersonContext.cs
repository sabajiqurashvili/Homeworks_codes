using Homework20.Domain;
using Microsoft.EntityFrameworkCore;

namespace Homework20.Data;

public class PersonContext : DbContext
{
    public PersonContext(DbContextOptions<PersonContext> options) : base(options)
    {
        
    }
   public DbSet<Person> Persons { get; set; }
   public DbSet<Adress> Adresses { get; set; }
    
}