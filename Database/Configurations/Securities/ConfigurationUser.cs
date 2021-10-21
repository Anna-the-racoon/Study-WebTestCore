using Database.Models.Securities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Database.Configurations.Securities
{
    class ConfigurationUser : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Security", "dbo.Securities.Users");

            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id)
                .ValueGeneratedOnAdd();

            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(300);

            builder.Property(p => p.Age)
                .IsRequired();
        }
    }
}
