using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class GoalTypeConfiguration : IEntityTypeConfiguration<Goal>
{
    public void Configure(EntityTypeBuilder<Goal> builder)
    {
        builder.Property(b => b.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Property(b => b.CreatedOn).HasDefaultValueSql("CURRENT_TIMESTAMP");

        builder
            .HasMany(goal => goal.Students)
            .WithMany(student => student.Goals)
            .UsingEntity<AssignedStudentGoal>();
    }
}
