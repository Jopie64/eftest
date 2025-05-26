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
        => options.UseSqlite("Data Source=./MyTestDb.sqlite");
}
