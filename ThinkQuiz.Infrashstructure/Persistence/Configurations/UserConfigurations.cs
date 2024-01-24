using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ThinkQuiz.Domain.UserAggregate;

namespace ThinkQuiz.Infrashstructure.Persistence.Configurations
{
    public class UserConfigurations : IEntityTypeConfiguration<User>
	{
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");

            builder.HasKey(user => user.Id);

            builder.HasIndex(user => user.Email).IsUnique();

            builder.HasIndex(user => user.FullName);

            builder.Property(user => user.FullName)
                .HasMaxLength(100);

            builder.Property(user => user.Email)
                .HasMaxLength(100);

            builder.Property(user => user.Password)
                .HasMaxLength(50);

            builder.Property(user => user.Gender)
                .HasDefaultValue(true);

            builder.Property(user => user.DateOfBirth)
                .IsRequired(false);

            builder.Property(user => user.Phone)
                .IsRequired(false);

            builder.Property(user => user.LastLogin);

            builder.Property(user => user.CreatedAt);

            builder.Property(user => user.UpdatedAt);
        }
    }
}

