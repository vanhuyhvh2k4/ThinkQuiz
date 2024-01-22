using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ThinkQuiz.Domain.AssignmentAggregate;
using ThinkQuiz.Domain.AssignmentAggregate.ValueObjects;
using ThinkQuiz.Domain.TeacherAggregate.ValueObjects;

namespace ThinkQuiz.Infrashstructure.Persistence.Configurations
{
    public class AssignmentConfigurations : IEntityTypeConfiguration<Assignment>
	{
        public void Configure(EntityTypeBuilder<Assignment> builder)
        {
            ConfigAssignmentTable(builder);
            ConfigAssignmentSubmittionIdsTable(builder);
            ConfigAssignmentClassIdsTable(builder);
        }

        private void ConfigAssignmentTable(EntityTypeBuilder<Assignment> builder)
        {
            builder.ToTable("Assignments");

            builder.HasKey(ab => ab.Id);

            builder.Property(ab => ab.Id)
                .ValueGeneratedNever()
                .HasConversion(id => id.Value, value => AssignmentId.Create(value));

            builder.Property(ab => ab.AuthorId)
                .HasConversion(id => id.Value, value => TeacherId.Create(value));

            builder.Property(ab => ab.Name)
                .HasMaxLength(100);

            builder.Property(ab => ab.StartTime);

            builder.Property(ab => ab.EndTime);

            builder.Property(ab => ab.Content)
                .HasMaxLength(500);

            builder.Property(ab => ab.FileUrl)
                .HasMaxLength(500);

            builder.Property(ab => ab.IsDeleted)
                .HasDefaultValue(false);
        }

        private void ConfigAssignmentSubmittionIdsTable(EntityTypeBuilder<Assignment> builder)
        {
            builder.OwnsMany(ab => ab.SubmittionAssignmentIds, sab =>
            {
                sab.ToTable("AssignmentSubmittionIds");

                sab.WithOwner().HasForeignKey("AssignmentId");

                sab.HasKey("Id");

                sab.Property(sa => sa.Value)
                    .HasColumnName("SubmittionId")
                    .ValueGeneratedNever();
            });
            builder.Metadata
          .FindNavigation(nameof(Assignment.SubmittionAssignmentIds))!
          .SetPropertyAccessMode(PropertyAccessMode.Field);
        }

        private void ConfigAssignmentClassIdsTable(EntityTypeBuilder<Assignment> builder)
        {
            builder.OwnsMany(ab => ab.ClassIds, cb =>
            {
                cb.ToTable("AssignmentClassIds");

                cb.WithOwner().HasForeignKey("AssignmentId");

                cb.HasKey("Id");

                cb.Property(cb => cb.Value)
                    .HasColumnName("ClassId")
                    .ValueGeneratedNever();
            });
            builder.Metadata
          .FindNavigation(nameof(Assignment.ClassIds))!
          .SetPropertyAccessMode(PropertyAccessMode.Field);
        }

    }
}

