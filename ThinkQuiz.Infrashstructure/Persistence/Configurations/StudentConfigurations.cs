using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ThinkQuiz.Domain.StudentAggregate;
using ThinkQuiz.Domain.StudentAggregate.ValueObjects;
using ThinkQuiz.Domain.UserAggregate.ValueObjects;

namespace ThinkQuiz.Infrashstructure.Persistence.Configurations
{
    public class StudentConfigurations : IEntityTypeConfiguration<Student>
	{
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            ConfigStudentTable(builder);
            ConfigStudentClassIds(builder);
            ConfigStudentSubmittionAssignmentIdsTable(builder);
            ConfigStudentSubmittionExamIdsTable(builder);
        }

        private void ConfigStudentTable(EntityTypeBuilder<Student> builder)
        {
            builder.ToTable("Students");

            builder.HasKey(sb => sb.Id);

            builder.Property(sb => sb.Id)
                .ValueGeneratedNever()
                .HasConversion(id => id.Value, value => StudentId.Create(value));

            builder.Property(sb => sb.UserId)
                .HasConversion(id => id.Value, value => UserId.Create(value));
        }

        private void ConfigStudentClassIds(EntityTypeBuilder<Student> builder)
        {
            builder.OwnsMany(sb => sb.ClassIds, cb =>
            {
                cb.ToTable("StudentClasseIds");

                cb.WithOwner().HasForeignKey("StudentId");

                cb.HasKey("Id");

                cb.Property(cb => cb.Value)
                    .ValueGeneratedNever()
                    .HasColumnName("ClassId");
            });
            builder.Metadata
               .FindNavigation(nameof(Student.ClassIds))!
               .SetPropertyAccessMode(PropertyAccessMode.Field);
        }

        private void ConfigStudentSubmittionAssignmentIdsTable(EntityTypeBuilder<Student> builder)
        {
            builder.OwnsMany(sb => sb.SubmittionAssignmentIds, sab =>
            {
                sab.ToTable("StudentSubmittionAssignmentIds");

                sab.WithOwner().HasForeignKey("StudentId");

                sab.HasKey("Id");

                sab.Property(sab => sab.Value)
                    .ValueGeneratedNever()
                    .HasColumnName("SubmittionAssignmentId");
            });
            builder.Metadata
               .FindNavigation(nameof(Student.SubmittionAssignmentIds))!
               .SetPropertyAccessMode(PropertyAccessMode.Field);
        }

        private void ConfigStudentSubmittionExamIdsTable(EntityTypeBuilder<Student> builder)
        {
            builder.OwnsMany(sab => sab.SubmittionExamIds, ssb =>
            {
                ssb.ToTable("StudentSubmittionExamIds");

                ssb.WithOwner().HasForeignKey("StudentId");

                ssb.HasKey("Id");

                ssb.Property(ssb => ssb.Value)
                    .ValueGeneratedNever()
                    .HasColumnName("SubmittionExamId");
            });
            builder.Metadata
               .FindNavigation(nameof(Student.SubmittionExamIds))!
               .SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}

