using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ThinkQuiz.Domain.ClassStudentAggregate;

namespace ThinkQuiz.Infrashstructure.Persistence.Configurations
{
    public class ClassStudentConfigurations : IEntityTypeConfiguration<ClassStudent>
	{
        public void Configure(EntityTypeBuilder<ClassStudent> builder)
        {
            builder.ToTable("ClassStudents");

            builder.HasKey(cs => new { cs.StudentId, cs.ClassId });

            builder.HasIndex(cs => new { cs.StudentId, cs.ClassId });

            builder.HasOne(cs => cs.Student)
                .WithMany(student => student.ClassStudents)
                .HasForeignKey(cs => cs.StudentId)
                .IsRequired();

            builder.HasOne(cs => cs.Class)
                .WithMany(c => c.ClassStudents)
                .HasForeignKey(cs => cs.ClassId)
                .IsRequired();

            builder.Property(cs => cs.Status)
                .HasDefaultValue(false);

            builder.Property(cs => cs.CreatedAt);

            builder.Property(cs => cs.UpdatedAt);
        }
    }
}

