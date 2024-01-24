using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ThinkQuiz.Domain.TeacherAggregate;

namespace ThinkQuiz.Infrashstructure.Persistence.Configurations
{
    public class TeacherConfigurations : IEntityTypeConfiguration<Teacher>
	{
        public void Configure(EntityTypeBuilder<Teacher> builder)
        {
            builder.ToTable("Teachers");

            builder.HasKey(teacher => teacher.Id);

            builder.HasIndex(teacher => teacher.UserId).IsUnique();

            builder.HasOne(t => t.User)
                .WithOne(user => user.Teacher)
                .HasForeignKey<Teacher>(teacher => teacher.UserId)
                .IsRequired();

            builder.Property(teacher => teacher.Position)
                .HasMaxLength(100);

            builder.Property(teacher => teacher.SchoolInformation)
                .HasMaxLength(200);

            builder.Property(teacher => teacher.CreatedAt);

            builder.Property(teacher => teacher.UpdatedAt);
        }
    }
}

