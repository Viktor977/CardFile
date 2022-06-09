using CardFile.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CardFile.DAL.EntityConfigurations
{
    class UserProfileConfiguration : IEntityTypeConfiguration<UserProfile>
    {
        public void Configure(EntityTypeBuilder<UserProfile> builder)
        {
            builder.Property(t => t.Password).HasMaxLength(100);
            builder.Property(t => t.Login).HasMaxLength(100);
            builder.Property(t => t.Email).HasMaxLength(100);
        }
    }
}
