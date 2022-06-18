using CardFile.DAL.Entities;
using CardFile.DAL.EntityConfigurations;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace CardFile.DAL.Data
{
    public class CardFileDBContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<History> Histories { get; set; }
        public DbSet<TextMaterial> Materials { get; set; }
        public DbSet<Reaction> Reactions { get; set; }
        public CardFileDBContext(DbContextOptions<CardFileDBContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new UserProfileConfiguration());
            modelBuilder.ApplyConfiguration(new HistoryConfiguration());
            modelBuilder.ApplyConfiguration(new TextMaterialConfiguration());
            modelBuilder.ApplyConfiguration(new ReactionConfiguration());
        }
        public CardFileDBContext() { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer("Data Source=127.0.0.1;Initial Catalog=CardFileDB;User ID=user1;Password=AZSXDCFVGBHNJMK<L>:?;");

        }
    }
}
