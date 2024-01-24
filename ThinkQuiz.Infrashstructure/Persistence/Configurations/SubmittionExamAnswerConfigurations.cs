using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ThinkQuiz.Domain.SubmittionExamAggregate;
using ThinkQuiz.Domain.SubmittionExamAnswerAggregate;

namespace ThinkQuiz.Infrashstructure.Persistence.Configurations
{
    public class SubmittionExamAnswerConfigurations : IEntityTypeConfiguration<SubmittionExamAnswer>
	{
        public void Configure(EntityTypeBuilder<SubmittionExamAnswer> builder)
        {
            builder.ToTable("SubmittionExamAnswers");

            builder.HasKey(sea => sea.Id);

            builder.HasOne<SubmittionExam>()
                .WithMany(se => se.SubmittionExamAnswers)
                .HasForeignKey(sea => sea.submittionExamId)
                .IsRequired();

            builder.Property(sea => sea.QuestionId);

            builder.Property(sea => sea.ChoiceId);

            builder.Property(sea => sea.CreatedAt);

            builder.Property(sea => sea.UpdatedAt);
        }
    }
}

