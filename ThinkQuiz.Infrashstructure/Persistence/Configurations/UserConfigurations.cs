using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ThinkQuiz.Domain.UserAggregate;
using ThinkQuiz.Domain.UserAggregate.ValueObjects;

namespace ThinkQuiz.Infrashstructure.Persistence.Configurations
{
    public class UserConfigurations : IEntityTypeConfiguration<User>
	{
        public void Configure(EntityTypeBuilder<User> builder)
        {
            ConfigUserTable(builder);
        }

        private void ConfigUserTable(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(ub => ub.Id);

            builder.Property(ub => ub.Id)
                .ValueGeneratedNever()
                .HasConversion(id => id.Value, value => UserId.Create(value));

            builder.Property(ub => ub.FullName)
                .HasMaxLength(200);

            builder.Property(ub => ub.Email)
                .HasMaxLength(200);

            builder.Property(ub => ub.Password)
                .HasMaxLength(50);

            builder.Property(ub => ub.DateOfBirth);

            builder.Property(ub => ub.Phone);

            builder.Property(ub => ub.LastLogin);

            builder.Property(ub => ub.Gender);
        }
    }
}

