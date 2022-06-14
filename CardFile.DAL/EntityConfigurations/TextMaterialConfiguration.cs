using CardFile.DAL.Entities;
using CardFile.DAL.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace CardFile.DAL.EntityConfigurations
{
    public class TextMaterialConfiguration : IEntityTypeConfiguration<TextMaterial>
    {
        public void Configure(EntityTypeBuilder<TextMaterial> builder)
        {
            builder.Property(t => t.Title).HasMaxLength(100);
            builder.Property(t => t.Author).HasMaxLength(100);
            builder.Property(t => t.Article).HasMaxLength(10000);

            builder.Property(t => t.Allows).HasConversion(x => x.ToString(),
              x => (Allows)Enum.Parse(typeof(Allows), x));

            builder.HasMany(t => t.History)
                .WithOne(t => t.Material)
                .HasForeignKey(t => t.TextId)
                .IsRequired();

            builder.HasMany(t => t.Reactions)
                .WithOne(t => t.Text)
                .HasForeignKey(t => t.TextId).HasPrincipalKey(t=>t.Id);
        }
    }
}
