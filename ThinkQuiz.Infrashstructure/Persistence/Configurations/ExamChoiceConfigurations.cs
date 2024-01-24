using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ThinkQuiz.Domain.ExamChoiceAggregate;

namespace ThinkQuiz.Infrashstructure.Persistence.Configurations
{
    public class ExamChoiceConfigurations : IEntityTypeConfiguration<ExamChoice>
	{
        public void Configure(EntityTypeBuilder<ExamChoice> builder)
        {
            builder.ToTable("ExamChoices");

            builder.HasKey(ec => ec.Id);

            builder.HasOne(ec => ec.ExamQuestion)
                .WithMany(examQuesion => examQuesion.ExamChoices)
                .HasForeignKey(ec => ec.QuestionId)
                .IsRequired();

            builder.Property(ec => ec.Number);

            builder.Property(ec => ec.Title)
                .HasMaxLength(200);

            builder.Property(ec => ec.IsDeleted)
                .HasDefaultValue(false);
        }
    }
}

