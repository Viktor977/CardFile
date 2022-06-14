using CardFile.DAL.Entities;
using CardFile.DAL.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace CardFile.DAL.EntityConfigurations
{
    public class ReactionConfiguration : IEntityTypeConfiguration<Reaction>
    {
        public void Configure(EntityTypeBuilder<Reaction> builder)
        {
            builder.Property(t => t.Comment).HasMaxLength(300);
            builder.Property(t => t.Assessment)
                .HasConversion(x => x.ToString(), x => (Assessments)Enum.Parse(typeof(Assessments), x));
        }
    }
}
