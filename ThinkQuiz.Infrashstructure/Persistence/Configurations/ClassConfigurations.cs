using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ThinkQuiz.Domain.ClassAggregate;
using ThinkQuiz.Domain.TeacherAggregate;

namespace ThinkQuiz.Infrashstructure.Persistence.Configurations
{
    public class ClassConfigurations : IEntityTypeConfiguration<Class>
    {
        public void Configure(EntityTypeBuilder<Class> builder)
        {
            builder.ToTable("Classes");

            builder.HasKey(c => c.Id);

            builder.HasIndex(c => new { c.TeacherId, c.Name });

            builder.HasOne(c => c.Teacher)
                .WithMany(teacher => teacher.Classes)
                .HasForeignKey(c => c.TeacherId)
                .IsRequired();

            builder.Property(c => c.Name)
                .HasMaxLength(100);

            builder.Property(c => c.SchoolYear);

            builder.Property(c => c.StudentQuantity)
                .HasDefaultValue(0);

            builder.Property(c => c.IsDeleted)
                .HasDefaultValue(false);

            builder.Property(c => c.CreatedAt);

            builder.Property(c => c.UpdatedAt);
        }
    }
}

