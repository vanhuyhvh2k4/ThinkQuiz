using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ThinkQuiz.Domain.AssignmentAggregate;
using ThinkQuiz.Domain.StudentAggregate;
using ThinkQuiz.Domain.SubmittionAssignmentAggregate;

namespace ThinkQuiz.Infrashstructure.Persistence.Configurations
{
	public class SubmittionAssignmentConfigurations : IEntityTypeConfiguration<SubmittionAssignment>
	{
        public void Configure(EntityTypeBuilder<SubmittionAssignment> builder)
        {
            builder.ToTable("SubmittionAssignments");

            builder.HasKey(sa => new { sa.AssignmentId, sa.StudentId, sa.Id });

            builder.HasOne<Student>()
                .WithMany(student => student.SubmittionAssignments)
                .HasForeignKey(sa => sa.StudentId)
                .IsRequired();

            builder.HasOne<Assignment>()
                .WithMany(assign => assign.SubmittionAssignments)
                .HasForeignKey(sa => sa.AssignmentId)
                .IsRequired();

            builder.Property(sa => sa.AnswerUrl)
                .HasMaxLength(500);

            builder.Property(sa => sa.Point)
                .IsRequired(false);

            builder.Property(sa => sa.Comment)
                .HasMaxLength(200)
                .IsRequired(false);

            builder.Property(sa => sa.IsShowPoint)
                .HasDefaultValue(false);

            builder.Property(sa => sa.IsSubmitAgain)
                .HasDefaultValue(false);

            builder.Property(sa => sa.CreatedAt);

            builder.Property(sa => sa.UpdatedAt);
        }
    }
}

