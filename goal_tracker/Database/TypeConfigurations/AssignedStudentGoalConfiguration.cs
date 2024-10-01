using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class AssignedStudentGoalTypeConfiguration : IEntityTypeConfiguration<AssignedStudentGoal>
{
    public void Configure(EntityTypeBuilder<AssignedStudentGoal> builder)
    {
        builder.Property(b => b.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Property(b => b.CreatedOn).HasDefaultValueSql("CURRENT_TIMESTAMP");
    }
}
