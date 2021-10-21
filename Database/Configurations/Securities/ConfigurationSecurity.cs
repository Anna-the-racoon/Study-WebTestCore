using Database.Models.Securities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Database.Configurations.Securities
{
    public class ConfigurationSecurity : IEntityTypeConfiguration<Security>
    {
        public void Configure(EntityTypeBuilder<Security> builder)
        {
            builder.ToTable("Security", "dbo.Securities.Security");

            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id)
                .ValueGeneratedOnAdd();

            builder.Property(p => p.Login)
                .IsRequired();
            
            builder.Property(p => p.Password)
                .IsRequired()
                .HasMaxLength(1000);
        }
    }
}
