using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ThinkQuiz.Domain.TeacherAggregate;
using ThinkQuiz.Domain.UserAggregate;

namespace ThinkQuiz.Infrashstructure.Persistence.Configurations
{
	public class TeacherConfigurations : IEntityTypeConfiguration<Teacher>
	{
        public void Configure(EntityTypeBuilder<Teacher> builder)
        {
            builder.ToTable("Teachers");

            builder.HasKey(teacher => teacher.Id);

            builder.HasOne<User>()
                .WithOne(user => user.Teacher)
                .HasForeignKey<Teacher>(teacher => teacher.UserId);

            builder.Property(teacher => teacher.Position)
                .HasMaxLength(100);

            builder.Property(teacher => teacher.SchoolInformation)
                .HasMaxLength(200);

            builder.Property(teacher => teacher.CreatedAt);

            builder.Property(teacher => teacher.UpdatedAt);
        }
    }
}

