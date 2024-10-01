using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class StudentTypeConfiguration : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        builder.Property(b => b.Id).IsRequired().ValueGeneratedOnAdd();

        builder
            .HasMany(student => student.Goals)
            .WithMany(goal => goal.Students)
            .UsingEntity<AssignedStudentGoal>();
    }
}
