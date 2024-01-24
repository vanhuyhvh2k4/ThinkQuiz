using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ThinkQuiz.Domain.ClassAssignmentAggregate;

namespace ThinkQuiz.Infrashstructure.Persistence.Configurations
{
    public class ClassAssignmentConfigurations : IEntityTypeConfiguration<ClassAssignment>
	{
        public void Configure(EntityTypeBuilder<ClassAssignment> builder)
        {
            builder.ToTable("ClassAssignments");

            builder.HasKey(ca => new { ca.AssignmentId, ca.ClassId });

            builder.HasIndex(ca => new { ca.ClassId, ca.AssignmentId });

            builder.HasOne(ca => ca.Assignment)
                .WithMany(assign => assign.ClassAssignments)
                .HasForeignKey(ca => ca.AssignmentId)
                .IsRequired();

            builder.HasOne(ca => ca.Class)
                .WithMany(c => c.ClassAssignments)
                .HasForeignKey(ca => ca.ClassId)
                .IsRequired();
        }
    }
}

