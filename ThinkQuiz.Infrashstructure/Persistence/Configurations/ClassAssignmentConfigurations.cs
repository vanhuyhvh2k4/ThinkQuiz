using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ThinkQuiz.Domain.AssignmentAggregate;
using ThinkQuiz.Domain.ClassAggregate;
using ThinkQuiz.Domain.ClassAssignmentAggregate;

namespace ThinkQuiz.Infrashstructure.Persistence.Configurations
{
    public class ClassAssignmentConfigurations : IEntityTypeConfiguration<ClassAssignment>
	{
        public void Configure(EntityTypeBuilder<ClassAssignment> builder)
        {
            builder.ToTable("ClassAssignments");

            builder.HasKey(ca => new { ca.AssignmentId, ca.ClassId });

            builder.HasOne<Assignment>()
                .WithMany(assign => assign.ClassAssignments)
                .HasForeignKey(ca => ca.AssignmentId)
                .IsRequired();

            builder.HasOne<Class>()
                .WithMany(c => c.ClassAssignments)
                .HasForeignKey(ca => ca.ClassId)
                .IsRequired();
        }
    }
}

