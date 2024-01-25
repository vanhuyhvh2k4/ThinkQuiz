using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ThinkQuiz.Domain.StudeæntAggregate;

namespace ThinkQuiz.Infrashstructure.Persistence.Configurations
{
    public class StudentConfigurations : IEntityTypeConfiguration<Student>
	{
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.ToTable("Students");

            builder.HasKey(student => student.Id);

            builder.HasIndex(student => student.UserId).IsUnique();

            builder.HasOne(student => student.User)
                .WithOne(user => user.Student)
                .HasForeignKey<Student>(student => student.UserId)
                .IsRequired();

            builder.Property(student => student.CreatedAt);

            builder.Property(student => student.UpdatedAt);
        }
    }
}

