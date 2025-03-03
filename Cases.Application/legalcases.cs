using Microsoft.EntityFrameworkCore;
using Microsoft.Data.Sqlite;
using System.ComponentModel.DataAnnotations.Schema;

namespace legalcases.EntityModels;

//Creating a connection string to a database
public class LegalCasesContext : DbContext
{
    private readonly string connectionString;
    public LegalCasesContext()
    {
        string databaseFile = "LegalCases.db";
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
    public int id { get; set; }
    public string? case_name { get; set; }
    public string? client_name { get; set; }
    public string? case_type { get; set; }
    public string? case_state { get; set; }
    public string? assigned_attorney { get; set; }
    public DateTime court_date { get; set; }
    public string? case_description { get; set; }
    public string? documents { get; set; }
    public string? notes { get; set; }
}
