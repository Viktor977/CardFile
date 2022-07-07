using CardFile.DAL.Entities;
using CardFile.DAL.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace CardFile.DAL.Data
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Microsoft.EntityFrameworkCore.DbContext" />
    public class CardFileDBContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<History> Histories { get; set; }
        public DbSet<TextMaterial> Materials { get; set; }
        public DbSet<Reaction> Reactions { get; set; }
        public CardFileDBContext(DbContextOptions<CardFileDBContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new HistoryConfiguration());
            modelBuilder.ApplyConfiguration(new TextMaterialConfiguration());
            modelBuilder.ApplyConfiguration(new ReactionConfiguration());
        }
    }
}
