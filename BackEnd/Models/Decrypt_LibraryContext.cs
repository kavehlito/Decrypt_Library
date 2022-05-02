using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Decrypt_Library.Models
{
    public partial class Decrypt_LibraryContext : DbContext
    {
        public Decrypt_LibraryContext()
        {
        }

        public Decrypt_LibraryContext(DbContextOptions<Decrypt_LibraryContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Audience> Audiences { get; set; }
        public virtual DbSet<BookHistory> BookHistories { get; set; }
        public virtual DbSet<Cart> Carts { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Event> Events { get; set; }
        public virtual DbSet<Language> Languages { get; set; }
        public virtual DbSet<MediaType> MediaTypes { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductCategory> ProductCategories { get; set; }
        public virtual DbSet<Review> Reviews { get; set; }
        public virtual DbSet<Shelf> Shelves { get; set; }
        public virtual DbSet<TypeOfBookEvent> TypeOfBookEvents { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserEvent> UserEvents { get; set; }
        public virtual DbSet<UserType> UserTypes { get; set; }
        public virtual DbSet<UsersCart> UsersCarts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=tcp:decrypt.database.windows.net,1433;Initial Catalog=Decrypt_Library;Persist Security Info=False;User ID=Decrypt;Password=Newton123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Audience>(entity =>
            {
                entity.ToTable("Audience");

                entity.HasIndex(e => e.AgeGroup, "UQ__Audience__CE82BAE13B40DA36")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AgeGroup)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<BookHistory>(entity =>
            {
                entity.ToTable("Book History");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.HasOne(d => d.Event)
                    .WithMany(p => p.BookHistories)
                    .HasForeignKey(d => d.EventId)
                    .HasConstraintName("FK_Book History.EventId");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.BookHistories)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_Book History.ProductId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.BookHistories)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Book History.UserId");
            });

            modelBuilder.Entity<Cart>(entity =>
            {
                entity.ToTable("Cart");

                entity.Property(e => e.Id).HasColumnName("ID");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasIndex(e => e.CategoriesName, "UQ__Categori__C41451B63FB24460")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CategoriesName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Event>(entity =>
            {
                entity.ToTable("Event");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Description)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.EventName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Time).HasColumnType("smalldatetime");
            });

            modelBuilder.Entity<Language>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Country)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MediaType>(entity =>
            {
                entity.ToTable("MediaType");

                entity.HasIndex(e => e.FormatName, "UQ__MediaTyp__CE1A17246E134D1C")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.FormatName).HasMaxLength(50);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AudienceId).HasColumnName("AudienceID");

                entity.Property(e => e.AuthorName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.Description).HasColumnType("text");

                entity.Property(e => e.Isbn).HasColumnName("ISBN");

                entity.Property(e => e.LanguageId).HasColumnName("LanguageID");

                entity.Property(e => e.MediaId).HasColumnName("MediaID");

                entity.Property(e => e.Narrator)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.PublishDate).HasColumnType("date");

                entity.Property(e => e.Publisher)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.ShelfId).HasColumnName("ShelfID");

                entity.Property(e => e.Title)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ProductCategory>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Product_Categories");

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.HasOne(d => d.Category)
                    .WithMany()
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Product_Categories.CategoryID");

                entity.HasOne(d => d.Product)
                    .WithMany()
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Product_Categories.ProductID");
            });

            modelBuilder.Entity<Review>(entity =>
            {
                entity.ToTable("Review");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ReviewText).HasColumnType("text");

                entity.HasOne(d => d.Produkt)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.ProduktId)
                    .HasConstraintName("FK_Review.ProduktId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Review.UserId");
            });

            modelBuilder.Entity<Shelf>(entity =>
            {
                entity.ToTable("Shelf");

                entity.HasIndex(e => e.Shelfname, "UQ__Shelf__E263264B2CD65827")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Shelfname).HasMaxLength(50);
            });

            modelBuilder.Entity<TypeOfBookEvent>(entity =>
            {
                entity.ToTable("Type of Book event");

                entity.Property(e => e.TypeofEventName)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.Phonenumber, "UQ__Users__9FDCA5A79D6A8A64")
                    .IsUnique();

                entity.HasIndex(e => e.Email, "UQ__Users__A9D1053460FD7517")
                    .IsUnique();

                entity.HasIndex(e => e.UserName, "UQ__Users__C9F28456EB771F43")
                    .IsUnique();

                entity.HasIndex(e => e.Ssn, "UQ__Users__CA1E8E3C8191DCA1")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.Password).HasMaxLength(50);

                entity.Property(e => e.Ssn).HasColumnName("SSN");

                entity.Property(e => e.UserName).HasMaxLength(50);

                entity.HasOne(d => d.UserType)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.UserTypeId)
                    .HasConstraintName("FK_Users.UserTypeId");
            });

            modelBuilder.Entity<UserEvent>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("User_Event");

                entity.HasIndex(e => e.EventId, "Fk");

                entity.HasOne(d => d.Event)
                    .WithMany()
                    .HasForeignKey(d => d.EventId)
                    .HasConstraintName("FK_User_Event.EventId");

                entity.HasOne(d => d.User)
                    .WithMany()
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_User_Event.UserId");
            });

            modelBuilder.Entity<UserType>(entity =>
            {
                entity.ToTable("UserType");

                entity.HasIndex(e => e.UserTypeName, "UQ__UserType__9262CB71C835DBBC")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.UserTypeName)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UsersCart>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Users_cart");

                entity.Property(e => e.CartId).HasColumnName("CartID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Cart)
                    .WithMany()
                    .HasForeignKey(d => d.CartId)
                    .HasConstraintName("FK_Users_cart.CartID");

                entity.HasOne(d => d.User)
                    .WithMany()
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Users_cart.UserID");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
