using Microsoft.EntityFrameworkCore;
using Samples.Lib.Entities;

namespace Samples.Lib;

public class ApplicationDbContext : DbContext
{
    private readonly string _connectionString;

    public ApplicationDbContext(string connectionString)
    {
        _connectionString = connectionString;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UsePostgres(_connectionString);

    public DbSet<Attorney> Attorneys { get; set; }
    public DbSet<Defendant> Defendants { get; set; }
    public DbSet<Inmate> Inmates { get; set; }
    public DbSet<Judge> Judges { get; set; }
    public DbSet<Juror> Jurors { get; set; }
    public DbSet<Case> Cases { get; set; }
    public DbSet<PeaceOfficer> Officers { get; set; }
    public DbSet<CourtReporter> CourtReporters { get; set; }
    public DbSet<Charge> Charges { get; set; }
}