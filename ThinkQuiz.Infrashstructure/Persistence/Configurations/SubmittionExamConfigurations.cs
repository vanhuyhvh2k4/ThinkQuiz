using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ThinkQuiz.Domain.ExamAggregate.ValueObjects;
using ThinkQuiz.Domain.StudentAggregate.ValueObjects;
using ThinkQuiz.Domain.SubmittionExamAggregate;
using ThinkQuiz.Domain.SubmittionExamAggregate.ValueObjects;

namespace ThinkQuiz.Infrashstructure.Persistence.Configurations
{
    public class SubmittionExamConfigurations : IEntityTypeConfiguration<SubmittionExam>
	{
        public void Configure(EntityTypeBuilder<SubmittionExam> builder)
        {
            ConfigSubmittionExamTable(builder);
            ConfigSubmittionExamAnswerTable(builder);
        }

        private void ConfigSubmittionExamTable(EntityTypeBuilder<SubmittionExam> builder)
        {
            builder.ToTable("SubmittionExams");

            builder.HasKey(sb => sb.Id);

            builder.Property(sb => sb.Id)
                .ValueGeneratedNever()
                .HasConversion(id => id.Value, value => SubmittionExamId.Create(value));

            builder.Property(sb => sb.StudentId)
                .HasConversion(id => id.Value, value => StudentId.Create(value));

            builder.Property(sb => sb.ExamId)
                .HasConversion(id => id.Value, value => ExamId.Create(value));

            builder.Property(sb => sb.Point);
        }

        private void ConfigSubmittionExamAnswerTable(EntityTypeBuilder<SubmittionExam> builder)
        {
            builder.OwnsMany(sb => sb.SubmittionAnswers, sab =>
            {
                sab.ToTable("SubmittionExamAnswers");

                sab.WithOwner().HasForeignKey("SubmittionExamId");

                sab.HasKey(sa => sa.Id);

                sab.Property(sa => sa.Id)
                    .ValueGeneratedNever()
                    .HasConversion(id => id.Value, value => SubmittionAnswerId.Create(value));

                sab.Property(sa => sa.QuestionId)
                    .HasColumnName("QuestionId")
                    .HasConversion(id => id.Value, value => QuestionId.Create(value));

                sab.Property(sa => sa.ChoiceId)
                    .HasColumnName("ChoiceId")
                    .HasConversion(id => id.Value, value => ChoiceId.Create(value));
            });
            builder.Metadata
              .FindNavigation(nameof(SubmittionExam.SubmittionAnswers))!
              .SetPropertyAccessMode(PropertyAccessMode.Field);
        }

    }
}

