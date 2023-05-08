using Microsoft.EntityFrameworkCore;

namespace Domain.Model
{
    public class PersonContext:DbContext
    {
        public DbSet<Person> people { get; set; }
        public DbSet<Product> products { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            #warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=Personn2;Trusted_Connection=True;; TrustServerCertificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Person>(p => {
                p.ToTable("Person");
                p.HasKey(a => a.ID);
                p.Property(a => a.FirstName);
                p.Property(a => a.LastName);
               
                p.Property(a => a.Age);
            });

            modelBuilder.Entity<Product>(pr =>
            {
                pr.ToTable("Product");
                pr.HasKey(a => a.ID);
                pr.Property(a => a.ProductCode);
                pr.Property(a => a.ProductName);
                pr.Property(a => a.Mark);


            });

            base.OnModelCreating(modelBuilder);
        }


    }
}
