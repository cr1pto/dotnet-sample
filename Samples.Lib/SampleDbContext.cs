using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Samples.Lib.Entities;

namespace Samples.Lib;

public class SampleDbContext : DbContext
{


    public SampleDbContext(DbContextOptions<SampleDbContext> options) : base(options)
    {
    }
    private readonly string _connectionString;

    public SampleDbContext(string connectionString)
    {
        _connectionString = connectionString;
    }
    //public SampleDbContext(IConfiguration configuration)
    //{
    //    _connectionString = configuration.GetConnectionString("SampleDb");
    //}

    // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UsePostgres(_connectionString);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Case>(
            eb =>
            {
                //eb.Property(b => b.Id).UseIdentityAlwaysColumn();
                eb.Property(b => b.Name).HasMaxLength(500);
                eb.Property(b => b.CaseNumber).HasMaxLength(200);
            }
            );

        //modelBuilder.Entity<Case>().HasKey();

        modelBuilder.Entity<Attorney>(
          eb =>
          {
              //eb.Property(b => b.Id).UseIdentityAlwaysColumn();
              eb.Property(b => b.Name).HasMaxLength(200);
              eb.Property(b => b.BarNumber).HasMaxLength(200);
              eb.Property(b => b.FirmName).HasMaxLength(200);
              eb.Property(b => b.PhoneNumber).HasMaxLength(50);
              eb.Property(b => b.Email).HasMaxLength(200);
              eb.Property(b => b.AttorneyType).HasMaxLength(20);
          }
          );

        modelBuilder.Entity<Defendant>(
        eb =>
        {
            //eb.Property(b => b.Id).UseIdentityAlwaysColumn();
            eb.Property(b => b.Name).HasMaxLength(200);
        }
        );

        modelBuilder.Entity<Judge>(
        eb =>
        {
            //eb.Property(b => b.Id).UseIdentityAlwaysColumn();
            eb.Property(b => b.Name).HasMaxLength(200);
        }
        );

        modelBuilder.Entity<Juror>(
        eb =>
        {
            //eb.Property(b => b.Id).UseIdentityAlwaysColumn();
            eb.Property(b => b.Name).HasMaxLength(200);
        }
        );

        modelBuilder.Entity<Inmate>(
        eb =>
        {
            //eb.Property(b => b.Id).UseIdentityAlwaysColumn();
            eb.Property(b => b.Name).HasMaxLength(200);
            eb.Property(b => b.ArraignmentDate);
            eb.Property(b => b.ArrestDate);
            eb.Property(b => b.SentencingDate);
        }
        );

    }

    public DbSet<Case> Cases { get; set; }
    public DbSet<Attorney> Attorneys { get; set; }
    public DbSet<Defendant> Defendants { get; set; }
    public DbSet<Inmate> Inmates { get; set; }
    public DbSet<Judge> Judges { get; set; }
    public DbSet<Juror> Jurors { get; set; }
}