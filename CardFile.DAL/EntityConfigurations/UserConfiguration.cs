using CardFile.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CardFile.DAL.EntityConfigurations
{
    class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(t => t.FirstName).HasMaxLength(100);
            builder.Property(t => t.LastName).HasMaxLength(100);
            builder.HasOne(t => t.Profile).WithOne(t => t.User)
                .HasForeignKey<UserProfile>(t => t.UserId)
                .IsRequired();
        }
    }
}
