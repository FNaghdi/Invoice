using Microsoft.EntityFrameworkCore;

namespace Domain.Model
{
    public class PersonContext:DbContext
    {
        public DbSet<Person> people { get; set; }
        public DbSet<Product> products { get; set; }

        public DbSet <PurchaseInvoice> purchases { get; set; }  
        public DbSet<Purchaseinvoiceitems> Purchaseinvoiceitems { get; set; }
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

            modelBuilder.Entity<PurchaseInvoice>(pr =>
            {
                pr.ToTable("PurchaseInvoice");
                pr.HasKey(a => a.ID);
                pr.Property(a => a.IDPerson);
                pr.Property(a => a.Date);
                pr.Property(e => e.Invoicenumber);

                pr.HasOne(a => a.Person).WithMany(b => b.purchaseInvoice).HasForeignKey(purcha => purcha.IDPerson).OnDelete(DeleteBehavior.Cascade);

            });

            modelBuilder.Entity<Purchaseinvoiceitems>(purch =>
            {


                purch.ToTable("Purchaseinvoiceitems");
                purch.HasKey(e => e.Id);    //pk
                purch.Property(e => e.Id).ValueGeneratedOnAdd();

                purch.Property(e => e.Number).HasColumnName("Number").IsRequired();



                purch.HasOne(a => a.Purchaseinvoice).WithMany(b => b.purchaseinvoiceitems).HasForeignKey(a => a.Idpruchaseinvoice);
                purch.HasOne(a => a.Product).WithMany(b => b.Aghlamfaktors).HasForeignKey(c => c.Idcommodity);
            }); 
                base.OnModelCreating(modelBuilder);
        }


    }
}
