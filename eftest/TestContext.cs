using Microsoft.EntityFrameworkCore;

namespace Eftest;


public class Test
{
    public int Id { get; set; }
    public string NameChanged { get; set; }
}

public class TestContext : DbContext
{
    public DbSet<Test> Tests { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=EfTestDb;Trusted_Connection=True;");
}
