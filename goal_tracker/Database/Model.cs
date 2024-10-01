using dotenv.net;
using dotenv.net.Utilities;
using Microsoft.EntityFrameworkCore;

public class GoalTrackingContext : DbContext
{
    public GoalTrackingContext() { }

    public DbSet<Student> Students { get; set; } = null!;
    public DbSet<Goal> Goals { get; set; } = null!;
    public DbSet<AssignedStudentGoal> AssignedStudentGoals { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        DotEnv.Load();
        var dbPath = EnvReader.GetStringValue("DbPath");
        options.UseSqlite($"Data Source={dbPath}");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        new StudentTypeConfiguration().Configure(modelBuilder.Entity<Student>());
        new GoalTypeConfiguration().Configure(modelBuilder.Entity<Goal>());
        new AssignedStudentGoalTypeConfiguration().Configure(
            modelBuilder.Entity<AssignedStudentGoal>()
        );
    }
}

public class Student
{
    public int Id { get; set; }
    public required string StudentName { get; set; }

    public ICollection<Goal> Goals { get; set; } = [];
    public ICollection<AssignedStudentGoal> AssignedGoals { get; set; } = [];
}

public class Goal
{
    public int Id { get; set; }
    public DateTime CreatedOn { get; set; }
    public required string GoalName { get; set; }

    public ICollection<Student> Students { get; } = [];
}

public class AssignedStudentGoal
{
    public int Id { get; set; }
    public DateTime CreatedOn { get; set; }

    public required int StudentId { get; set; }
    public required int GoalId { get; set; }
    public required bool IsActive { get; set; }

    public Student Student { get; } = null!;
    public Goal Goal { get; set; } = null!;
}
