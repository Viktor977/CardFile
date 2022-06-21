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
            builder.Property(t => t.Email).HasMaxLength(100);
            builder.Property(t => t.Password).HasMaxLength(100);

            builder.Property(t => t.Role).HasConversion(x => x.ToString(),
                x => (Roles)Enum.Parse(typeof(Roles), x));

          

        }
    }
}
