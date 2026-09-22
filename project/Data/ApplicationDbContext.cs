using Tekpro.Models;
using Microsoft.EntityFrameworkCore;

namespace Tekpro.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
            
        }

        public DbSet<Diary> Diaries { get; set; }

        public DbSet<Sport> Sports { get; set; }

        public DbSet<Club> Clubs {get;set;}

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Publisher> Publishers { get; set; }

        public DbSet<Player> Players { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Diary>().HasData(
                new Diary {
                    Id = 1,
                    Title = "First Diary Entry",
                    Content = "This is the content of my first diary entry.",
                    Created = new DateTime(2025, 10, 13, 17, 45, 42) 
                },
                new Diary
                {
                    Id = 2,
                    Title = "Second Diary Entry",
                    Content = "This is the content of my second diary entry.",
                    Created = new DateTime(2025, 10, 13, 17, 45, 42)
                },
                new Diary
                {
                    Id = 3,
                    Title = "Third Diary Entry",
                    Content = "This is the content of my third diary entry.",
                    Created = new DateTime(2025, 10, 13, 17, 45, 42)
                }
                );

            modelBuilder.Entity<Sport>()
                .HasMany(s => s.Clubs)
                .WithOne(c => c.Sport)
                .HasForeignKey(c => c.SportId);

            //modelBuilder.Entity<Author>()
            //    .HasOne(a => a.Book)
            //    .WithOne(a => a.Author)
            //    .HasForeignKey<Book>(a => a.AuthorId);

            //modelBuilder.Entity<Author>()
            //    .HasMany(a => a.Books)
            //    .WithOne(a => a.Author)
            //    .HasForeignKey(a => a.AuthorId)
            //    .IsRequired();
            // or
            modelBuilder.Entity<Book>()
                .HasOne(b => b.Author)
                .WithMany(b => b.Books)
                .HasForeignKey(b => b.AuthorId)
                .IsRequired();

            //var Sport = modelBuilder.Entity<Sport>().Property(p => p.Name) // Przykład konfiguracji właściwości
            //.HasMaxLength(250).IsRequired(true);

            modelBuilder.Entity<Club>()
                .HasMany(c => c.Players)
                .WithOne(c=> c.Club)
                .HasForeignKey(c => c.ClubId)
                .IsRequired();

        }
    }
}
