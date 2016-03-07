using Microsoft.Data.Entity;

namespace DH.Lending.Borrower.Data.EntityModel
{
    public partial class DatabaseContext
        : DbContext
    {
        public DatabaseContext(string connectionString)
        {
            ConnectionString = connectionString;
        }

        private string ConnectionString { get; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!string.IsNullOrWhiteSpace(ConnectionString))
            {
                optionsBuilder.UseSqlServer(ConnectionString);
            }

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Borrower>()
                .HasKey(b => b.Id);

            modelBuilder.Entity<Profile>()
                .HasKey(p => p.BorrowerId);
        }

        public DbSet<Borrower> Borrower { get; set; }
        public DbSet<Profile> Profile { get; set; }
    }
}
