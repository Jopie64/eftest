using Eftest;
using Microsoft.EntityFrameworkCore;

try
{
    using var db = new TestContext();
    db.Database.Migrate();
    Console.WriteLine("Database migrated successfully.");
}
catch (Exception ex)
{
    Console.WriteLine($"An error occurred while migrating the database: {ex.Message}");
    Console.WriteLine(ex.StackTrace);
}
