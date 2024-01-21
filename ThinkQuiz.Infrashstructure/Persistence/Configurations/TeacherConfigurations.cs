using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ThinkQuiz.Domain.TeacherAggregate;
using ThinkQuiz.Domain.TeacherAggregate.ValueObjects;
using ThinkQuiz.Domain.UserAggregate.ValueObjects;

namespace ThinkQuiz.Infrashstructure.Persistence.Configurations
{
    public class TeacherConfigurations : IEntityTypeConfiguration<Teacher>
    {
        public void Configure(EntityTypeBuilder<Teacher> builder)
        {
            ConfigTeacherTable(builder);
            ConfigTeacherClassIdsTable(builder);
            ConfigTeacherAssignmentIds(builder);
            ConfigTeacherExamIds(builder);
        }

        private void ConfigTeacherTable(EntityTypeBuilder<Teacher> builder)
        {
            builder.ToTable("Teachers");

            builder.HasKey(tb => tb.Id);

            builder.Property(tb => tb.Id)
                .ValueGeneratedNever()
                .HasConversion(id => id.Value, value => TeacherId.Create(value));

            builder.Property(tb => tb.UserId)
                .HasConversion(id => id.Value, value => UserId.Create(value));

            builder.Property(tb => tb.Position)
                .HasMaxLength(100);

            builder.Property(tb => tb.SchoolInforamtion)
                .HasMaxLength(200);
        }

        private void ConfigTeacherClassIdsTable(EntityTypeBuilder<Teacher> builder)
        {
            builder.OwnsMany(tb => tb.ClassIds, cb =>
            {
                cb.ToTable("TeacherClassIds");

                cb.WithOwner().HasForeignKey("TeacherId");

                cb.HasKey("Id");

                cb.Property(cb => cb.Value)
                    .ValueGeneratedNever()
                    .HasColumnName("ClassId");
            });
            builder.Metadata
               .FindNavigation(nameof(Teacher.ClassIds))!
               .SetPropertyAccessMode(PropertyAccessMode.Field);
        }

        private void ConfigTeacherAssignmentIds(EntityTypeBuilder<Teacher> builder)
        {
            builder.OwnsMany(tb => tb.AssignmentIds, ab =>
            {
                ab.ToTable("TeacherAssignmentIds");

                ab.WithOwner().HasForeignKey("AuthorId");

                ab.HasKey("Id");

                ab.Property(ab => ab.Value)
                    .ValueGeneratedNever()
                    .HasColumnName("AssignmentId");
            });
            builder.Metadata
              .FindNavigation(nameof(Teacher.AssignmentIds))!
              .SetPropertyAccessMode(PropertyAccessMode.Field);
        }

        private void ConfigTeacherExamIds(EntityTypeBuilder<Teacher> builder)
        {
            builder.OwnsMany(tb => tb.ExamIds, eb =>
            {
                eb.ToTable("TeacherExamIds");

                eb.WithOwner().HasForeignKey("AuthorId");

                eb.HasKey("Id");

                eb.Property(eb => eb.Value)
                    .ValueGeneratedNever()
                    .HasColumnName("ExamId");
            });
            builder.Metadata
              .FindNavigation(nameof(Teacher.ExamIds))!
              .SetPropertyAccessMode(PropertyAccessMode.Field);
        }

    }
}

