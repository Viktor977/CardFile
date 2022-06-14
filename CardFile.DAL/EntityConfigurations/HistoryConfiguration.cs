using CardFile.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CardFile.DAL.EntityConfigurations
{
    public class HistoryConfiguration : IEntityTypeConfiguration<History>
    {
        public void Configure(EntityTypeBuilder<History> builder)
        {
            builder.HasKey(t => t.Id);
            builder.HasOne(t => t.User).WithMany(t => t.Materials).HasForeignKey(t => t.ReaderId).IsRequired();
          
        }
    }
}
