using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using REPETITEURLINK.Entities.Data;

namespace REPETITEURLINK;

public class RepetitionLinkDataContext:DbContext
{
    private string? _connectionString = "Host=localhost;Database=repetition_link;Username=postgres;Password=test;Include Error Detail=True"; 
    public RepetitionLinkDataContext(string connectionString="")
    {
        if (connectionString!="") { 
            _connectionString=connectionString;
        }
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            _connectionString ??= ConnectionStringProvider.ConnectionString;
            optionsBuilder.UseNpgsql(_connectionString);
        }
        optionsBuilder.ConfigureWarnings(w => w.Ignore(RelationalEventId.PendingModelChangesWarning));
        base.OnConfiguring(optionsBuilder);
        
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        if (Database.IsNpgsql())
        {
            modelBuilder.HasPostgresExtension("uuid-ossp");
        }
        #region PK AUTO GENERATE GUID
        modelBuilder.Entity<User>().Property(b => b.Id).HasDefaultValueSql("uuid_generate_v4()");
        modelBuilder.Entity<Encadreur>().Property(b => b.Id).HasDefaultValueSql("uuid_generate_v4()");
        modelBuilder.Entity<Parent>().Property(b => b.Id).HasDefaultValueSql("uuid_generate_v4()");
        modelBuilder.Entity<Student>().Property(b => b.Id).HasDefaultValueSql("uuid_generate_v4()");
        modelBuilder.Entity<DirectoryItem>().Property(b => b.Id).HasDefaultValueSql("uuid_generate_v4()");
        modelBuilder.Entity<DocumentCertification>().Property(b => b.Id).HasDefaultValueSql("uuid_generate_v4()");
        modelBuilder.Entity<VerificationCertification>().Property(b => b.Id).HasDefaultValueSql("uuid_generate_v4()");
        modelBuilder.Entity<SubjectRepetition>().Property(b => b.Id).HasDefaultValueSql("uuid_generate_v4()");
        modelBuilder.Entity<Subject>().Property(b => b.Id).HasDefaultValueSql("uuid_generate_v4()");
       // modelBuilder.Entity<SubjectEncadreur>().Property(b => b.Id).HasDefaultValueSql("uuid_generate_v4()");
        modelBuilder.Entity<SessionRepetition>().Property(b => b.Id).HasDefaultValueSql("uuid_generate_v4()");
        modelBuilder.Entity<RequestCourse>().Property(b => b.Id).HasDefaultValueSql("uuid_generate_v4()");
        modelBuilder.Entity<Repetition>().Property(b => b.Id).HasDefaultValueSql("uuid_generate_v4()");
        modelBuilder.Entity<MessageSession>().Property(b => b.Id).HasDefaultValueSql("uuid_generate_v4()");
        modelBuilder.Entity<MessagePayload>().Property(b => b.Id).HasDefaultValueSql("uuid_generate_v4()");
        modelBuilder.Entity<LevelSubjectEncadreur>().Property(b => b.Id).HasDefaultValueSql("uuid_generate_v4()");
        #endregion
        #region ENUM VECTOR
        modelBuilder.Entity<User>().Property(b => b.ParentSubjectType).HasConversion<string>().HasMaxLength(32);
        modelBuilder.Entity<User>().Property(b=>b.Sexe).HasConversion<string>().HasMaxLength(16);
        modelBuilder.Entity<User>().Property(b => b.Role).HasConversion<string>().HasMaxLength(32);
        modelBuilder.Entity<Repetition>().Property(b => b.DayOfWeeks).HasConversion<string>().HasMaxLength(32);
        modelBuilder.Entity<VerificationCertification>().Property(b => b.Status).HasConversion<string>().HasMaxLength(32);
        modelBuilder.Entity<VerificationCertification>().Property(b => b.CertificationType).HasConversion<string>().HasMaxLength(32);
        modelBuilder.Entity<SessionRepetition>().Property(b => b.DayOfWeek).HasConversion<string>().HasMaxLength(32);
        modelBuilder.Entity<DirectoryItem>().Property(b => b.Kind).HasConversion<string>().HasMaxLength(32);
        #endregion
        #region SEED DATA
        modelBuilder.Entity<DirectoryItem>().HasData(RepetitionSeedData.DirectoryItems);
        modelBuilder.Entity<Subject>().HasData(RepetitionSeedData.Subjects);
        modelBuilder.Entity<User>().HasData(RepetitionSeedData.users);
        #endregion
        base.OnModelCreating(modelBuilder);
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Repetition> Repetitions { get; set; }
    public DbSet<SessionRepetition> SessionRepetitions { get; set; }
    public DbSet<SubjectRepetition> SubjectRepetitions { get; set; }
    //public DbSet<SubjectEncadreur> SubjectEncadreurs { get; set; }
    public DbSet<Encadreur> Encadreurs { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<Parent> Parents { get; set; }
    public DbSet<RequestCourse> RequestCourses { get; set; }
    public DbSet<DirectoryItem> DirectoryItems { get; set; }
    public DbSet<DocumentCertification> DocumentCertifications { get; set; }
    public DbSet<VerificationCertification> VerificationCertifications { get; set; }
    public DbSet<MessageSession> MessageSessions { get; set; }
    public DbSet<MessageRequestCourse> MessageRequestCourses { get; set; }
    public DbSet<MessagePayload> MessagePayloads { get; set; }
    public DbSet<LevelSubjectEncadreur> LevelSubjectEncadreurs { get; set; }
}