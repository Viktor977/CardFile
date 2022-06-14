using CardFile.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CardFile.DAL.EntityConfigurations
{
    public class HistoryConfiguration : IEntityTypeConfiguration<History>
    {
        public void Configure(EntityTypeBuilder<History> builder)
        {
            builder.HasKey(t => t.Id);
            builder.HasOne(t => t.User).WithMany(t => t.Materials).HasForeignKey(t => t.ReaderId).IsRequired();
            //builder.HasMany(t => t.Materials)
            //  .WithOne(t => t.User)
            //  .HasForeignKey(t => t.ReaderId)
            //  .IsRequired();
        }
    }
}
