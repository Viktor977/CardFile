using CardFile.DAL.Entities;
using CardFile.DAL.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace CardFile.DAL.EntityConfigurations
{
    class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(t => t.FirstName).HasMaxLength(100);
            builder.Property(t => t.LastName).HasMaxLength(100);

            builder.Property(t => t.Role).HasConversion(x => x.ToString(),
                x => (Roles)Enum.Parse(typeof(Roles), x));

            builder.HasOne(t => t.Profile).WithOne(t => t.User)
                .HasForeignKey<UserProfile>(t => t.UserId)
                .IsRequired();

            //builder.HasMany(t => t.Materials)
            //    .WithOne(t => t.User)
            //    .HasForeignKey(t => t.ReaderId)
            //    .IsRequired();
        }
    }
}
