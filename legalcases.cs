using Microsoft.EntityFrameworkCore;
using Microsoft.Data.Sqlite;

namespace legalcases.EntityModels;

//Creating a connection string to a database
public class LegalCasesContext : DbContext
{
    private readonly string connectionString;
    public LegalCasesContext()
    {
        string databaseFile = "legalcases.db";
        string path = Path.Combine(Environment.CurrentDirectory, databaseFile);
        connectionString = $"Data Source={path}";
    }
    public DbSet<Case> Cases { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite(connectionString);
        WriteLine($"Connection: {connectionString}");
    }
}
//Creating a model class to work with each Case

public class Case
{
    public int Id { get; set; }
    public string CaseName { get; set; }
    public string ClientName { get; set; }
    public string CaseType { get; set; }
    public string CaseStatus { get; set; }
    public string AssignedAttorney { get; set; }
    public DateTime CourtDate { get; set; }
    public string CaseDescription { get; set; }
    public string Documents { get; set; }
    public string Notes { get; set; }
}
