using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ThinkQuiz.Domain.ClassAggregate;
using ThinkQuiz.Domain.ClassAggregate.ValueObjects;
using ThinkQuiz.Domain.TeacherAggregate.ValueObjects;

namespace ThinkQuiz.Infrashstructure.Persistence.Configurations
{
    public class ClassConfigurations : IEntityTypeConfiguration<Class>
	{
        public void Configure(EntityTypeBuilder<Class> builder)
        {
            ConfigClassTable(builder);
            ConfigClassStudentIds(builder);
            ConfigClassAssignmentIds(builder);
            ConfigClassExamIds(builder);
        }

        private void ConfigClassTable(EntityTypeBuilder<Class> builder)
        {
            builder.ToTable("Classes");

            builder.HasKey(cb => cb.Id);

            builder.Property(cb => cb.Id)
                .ValueGeneratedNever()
                .HasConversion(id => id.Value, value => ClassId.Create(value));

            builder.Property(cb => cb.TeacherId)
                .HasConversion(id => id.Value, value => TeacherId.Create(value));

            builder.Property(cb => cb.Name)
                .HasMaxLength(100);

            builder.Property(cb => cb.StudentQuantity);

            builder.Property(cb => cb.SchoolYear);

            builder.Property(cb => cb.IsDeleted)
                .HasDefaultValue(false);
        }

        private void ConfigClassStudentIds(EntityTypeBuilder<Class> builder)
        {
            builder.OwnsMany(cb => cb.StudentIds, sb =>
            {
                sb.ToTable("ClassStudentIds");

                sb.WithOwner().HasForeignKey("ClassId");

                sb.HasKey("Id");

                sb.Property(sb => sb.Value)
                    .HasColumnName("StudentId")
                    .ValueGeneratedNever();
            });
        }

        private void ConfigClassAssignmentIds(EntityTypeBuilder<Class> builder)
        {
            builder.OwnsMany(cb => cb.AssignmentIds, sb =>
            {
                sb.ToTable("ClassAssignmentIds");

                sb.WithOwner().HasForeignKey("ClassId");

                sb.HasKey("Id");

                sb.Property(sb => sb.Value)
                    .HasColumnName("AssignmentId")
                    .ValueGeneratedNever();
            });
        }

        private void ConfigClassExamIds(EntityTypeBuilder<Class> builder)
        {
            builder.OwnsMany(cb => cb.ExamIds, sb =>
            {
                sb.ToTable("ClassExamIds");

                sb.WithOwner().HasForeignKey("ClassId");

                sb.HasKey("Id");

                sb.Property(sb => sb.Value)
                    .HasColumnName("ExamId")
                    .ValueGeneratedNever();
            });
        }
    }
}

