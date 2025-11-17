using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;

namespace WebApplication1.Domain;

public class PersonContext : DbContext
{
    public PersonContext(DbContextOptions<PersonContext> options) : base(options)
    {
        
    }
    public DbSet<Person> Persons { get; set; }
    public DbSet<Adress> Adresses { get; set; }
}