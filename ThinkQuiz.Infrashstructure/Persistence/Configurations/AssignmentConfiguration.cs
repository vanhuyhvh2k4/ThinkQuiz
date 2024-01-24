using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ThinkQuiz.Domain.AssignmentAggregate;
using ThinkQuiz.Domain.TeacherAggregate;

namespace ThinkQuiz.Infrashstructure.Persistence.Configurations
{
	public class AssignmentConfiguration : IEntityTypeConfiguration<Assignment>
	{
        public void Configure(EntityTypeBuilder<Assignment> builder)
        {
            builder.ToTable("Assignments");

            builder.HasKey(assign => assign.Id);

            builder.HasOne<Teacher>()
                .WithMany(teacher => teacher.Assignments)
                .HasForeignKey(assign => assign.TeacherId)
                .IsRequired();

            builder.Property(assign => assign.Name)
                .HasMaxLength(100);

            builder.Property(assign => assign.StartTime);

            builder.Property(assign => assign.EndTime);

            builder.Property(assign => assign.Content)
                .HasMaxLength(500)
                .IsRequired(false);

            builder.Property(assign => assign.FileUrl)
                .HasMaxLength(500);

            builder.Property(assign => assign.IsDeleted)
                .HasDefaultValue(false);

            builder.Property(assign => assign.CreatedAt);

            builder.Property(assign => assign.UpdatedAt);
        }
    }
}

