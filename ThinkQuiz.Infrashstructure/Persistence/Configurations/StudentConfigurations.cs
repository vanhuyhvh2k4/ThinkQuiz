using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ThinkQuiz.Domain.StudentAggregate;
using ThinkQuiz.Domain.UserAggregate;

namespace ThinkQuiz.Infrashstructure.Persistence.Configurations
{
	public class StudentConfigurations : IEntityTypeConfiguration<Student>
	{
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.ToTable("Students");

            builder.HasKey(student => student.Id);

            builder.HasOne<User>()
                .WithOne(user => user.Student)
                .HasForeignKey<Student>(student => student.UserId);

            builder.Property(student => student.CreatedAt);

            builder.Property(student => student.UpdatedAt);
        }
    }
}

