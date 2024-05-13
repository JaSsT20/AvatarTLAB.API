using AvatarTLAB.Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace AvatarTLAB.Backend.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Alias> Aliases { get; set; }
        public DbSet<Character> Characters { get; set; }
        public DbSet<Episode> Episodes { get; set; }
        public DbSet<Element> Elements { get; set; }
        public DbSet<FightingStyle> FightingStyles { get; set; }
        public DbSet<Nation> Nations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Many-to-Many relationship between Character and Episodes
            modelBuilder.Entity<Character>()
                .HasOne(c => c.FirstEpisode)
                .WithMany()
                .HasForeignKey(c => c.FirstEpisodeId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Character>()
                .HasOne(c => c.LastEpisode)
                .WithMany()
                .HasForeignKey(c => c.LastEpisodeId)
                .OnDelete(DeleteBehavior.NoAction);

            // Many-to-Many relationship between Character and FightingStyle
            modelBuilder.Entity<CharacterFightingStyle>()
                .HasKey(cfs => new { cfs.CharacterId, cfs.FightingStyleId });

            modelBuilder.Entity<CharacterFightingStyle>()
                .HasOne(cfs => cfs.FightingStyle)
                .WithMany(fs => fs.CharacterFightingStyles)
                .HasForeignKey(cfs => cfs.FightingStyleId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Character>()
                .HasOne(c => c.FirstEpisode)
                .WithMany()
                .HasForeignKey(c => c.FirstEpisodeId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Character>()
                .HasOne(c => c.LastEpisode)
                .WithMany()
                .HasForeignKey(c => c.LastEpisodeId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
