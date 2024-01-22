using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ThinkQuiz.Domain.ExamAggregate;
using ThinkQuiz.Domain.ExamAggregate.Entities;
using ThinkQuiz.Domain.ExamAggregate.ValueObjects;
using ThinkQuiz.Domain.TeacherAggregate.ValueObjects;

namespace ThinkQuiz.Infrashstructure.Persistence.Configurations
{
    public class ExamConfigurations : IEntityTypeConfiguration<Exam>
    {
        public void Configure(EntityTypeBuilder<Exam> builder)
        {
            ConfigExamTable(builder);
            ConfigExamQuestionsTable(builder);
            ConfigExamClassIds(builder);
            ConfigExamSubmittionIds(builder);
        }

        private void ConfigExamTable(EntityTypeBuilder<Exam> builder)
        {
            builder.ToTable("Exams");

            builder.HasKey(eb => eb.Id);

            builder.Property(eb => eb.Id)
                .ValueGeneratedNever()
                .HasConversion(id => id.Value, value => ExamId.Create(value));

            builder.Property(sb => sb.AuthorId)
                .HasConversion(id => id.Value, value => TeacherId.Create(value));

            builder.Property(eb => eb.Name)
                .HasMaxLength(200);

            builder.Property(eb => eb.Password)
                .HasMaxLength(50)
                .IsRequired(false);

            builder.Property(eb => eb.IsPublish)
                .HasDefaultValue(false);

            builder.Property(eb => eb.IsWrap)
                .HasDefaultValue(false);

            builder.Property(eb => eb.IsShowResult)
                .HasDefaultValue(false);

            builder.Property(eb => eb.IsShowPoint)
                .HasDefaultValue(false);

            builder.Property(eb => eb.IsDeleted)
                .HasDefaultValue(false);

            builder.Property(eb => eb.LimitAttemptNumber)
                .HasDefaultValue(1);

            builder.Property(eb => eb.StartTime);

            builder.Property(eb => eb.EndTime);

            builder.Property(eb => eb.Duration);
        }

        private void ConfigExamQuestionsTable(EntityTypeBuilder<Exam> builder)
        {
            builder.OwnsMany(eb => eb.Questions, qb =>
            {
                qb.ToTable("ExamQuestions");

                qb.WithOwner().HasForeignKey("ExamId");

                qb.HasKey("Id");

                qb.Property(qb => qb.Id)
                    .ValueGeneratedNever()
                    .HasConversion(id => id.Value, value => QuestionId.Create(value));

                qb.Property(qb => qb.Number);

                qb.Property(qb => qb.Title)
                    .HasMaxLength(200);

                qb.Property(qb => qb.Point);

                qb.Property(qb => qb.IsDeleted)
                    .HasDefaultValue(false);

                qb.Property(qb => qb.CorrectAnswer);

                qb.OwnsMany(qb => qb.Choices, choiceBuilder => ConfigExamChoices(choiceBuilder));

                qb
                .Navigation(s => s.Choices).Metadata
                .SetField("_choices");

                qb
                .Navigation(s => s.Choices)
                .UsePropertyAccessMode(PropertyAccessMode.Field);
            });
            builder.Metadata
           .FindNavigation(nameof(Exam.Questions))!
           .SetPropertyAccessMode(PropertyAccessMode.Field);
        }

        private void ConfigExamChoices(OwnedNavigationBuilder<Question, Choice> choiceBuilder)
        {
            choiceBuilder.ToTable("ExamChoices");

            choiceBuilder.WithOwner().HasForeignKey("QuestionId");

            choiceBuilder.HasKey("Id");

            choiceBuilder.Property(cb => cb.Id)
                .ValueGeneratedNever()
                .HasConversion(id => id.Value, value => ChoiceId.Create(value));

            choiceBuilder.Property(cb => cb.Number);

            choiceBuilder.Property(cb => cb.IsDeleted)
                .HasDefaultValue(false);

            choiceBuilder.Property(cb => cb.Title)
                .HasMaxLength(200);
        }

        private void ConfigExamClassIds(EntityTypeBuilder<Exam> builder)
        {
            builder.OwnsMany(eb => eb.ClassIds, cb =>
            {
                cb.ToTable("ExamClassIds");

                cb.WithOwner().HasForeignKey("ExamId");

                cb.HasKey("Id");

                cb.Property(cb => cb.Value)
                    .HasColumnName("ClassId")
                    .ValueGeneratedNever();

            });
            builder.Metadata
           .FindNavigation(nameof(Exam.ClassIds))!
           .SetPropertyAccessMode(PropertyAccessMode.Field);
        }

        private void ConfigExamSubmittionIds(EntityTypeBuilder<Exam> builder)
        {
            builder.OwnsMany(eb => eb.SubmittionExamIds, sb =>
            {
                sb.ToTable("ExamSubmittionIds");

                sb.WithOwner().HasForeignKey("ExamId");

                sb.HasKey("Id");

                sb.Property(sb => sb.Value)
                    .HasColumnName("SubmittionId")
                    .ValueGeneratedNever();
            });
            builder.Metadata
           .FindNavigation(nameof(Exam.SubmittionExamIds))!
           .SetPropertyAccessMode(PropertyAccessMode.Field);
        }

    }
}

