using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Axali.Data;

public class PersonContextFactory : IDesignTimeDbContextFactory<PersonContext>
{
    public PersonContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<PersonContext>();

        optionsBuilder.UseSqlServer(
            "Server=.;Database=Axali;Trusted_Connection=True;MultipleActiveResultSets=True;TrustServerCertificate=True");

        return new PersonContext(optionsBuilder.Options);
    }
}