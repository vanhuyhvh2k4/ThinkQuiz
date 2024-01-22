using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ThinkQuiz.Domain.AssignmentAggregate.ValueObjects;
using ThinkQuiz.Domain.StudentAggregate.ValueObjects;
using ThinkQuiz.Domain.SubmittionAssignmentAggregate;
using ThinkQuiz.Domain.SubmittionAssignmentAggregate.ValueObjects;

namespace ThinkQuiz.Infrashstructure.Persistence.Configurations
{
	public class SubmittionAssignmentConfigurations : IEntityTypeConfiguration<SubmittionAssignment>
	{
        public void Configure(EntityTypeBuilder<SubmittionAssignment> builder)
        {
            ConfigSubmittionAssignmentTable(builder);
        }

        private void ConfigSubmittionAssignmentTable(EntityTypeBuilder<SubmittionAssignment> builder)
        {
            builder.ToTable("SubmittionAssignments");

            builder.HasKey(sb => sb.Id);

            builder.Property(sb => sb.Id)
                .ValueGeneratedNever()
                .HasConversion(id => id.Value, value => SubmittionAssignmentId.Create(value));

            builder.Property(sb => sb.StudentId)
                .HasConversion(id => id.Value, value => StudentId.Create(value));

            builder.Property(sb => sb.AssignmentId)
                .HasConversion(id => id.Value, value => AssignmentId.Create(value));

            builder.Property(sb => sb.AnswerUrl)
                .HasMaxLength(500);

            builder.Property(sb => sb.Point);

            builder.Property(sb => sb.Comment)
                .HasMaxLength(200);

            builder.Property(sb => sb.IsSubmitAgain)
                .HasDefaultValue(false);
        }
    }
}

