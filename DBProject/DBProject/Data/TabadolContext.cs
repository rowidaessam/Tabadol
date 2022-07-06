using DBProject.Models;
using Microsoft.EntityFrameworkCore;

namespace DBProject.Data
{
    public class TabadolContext:DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Admin & Association
            modelBuilder.Entity<AdminAssociation>()
                .HasKey(AdmAss => new { AdmAss.AdminId, AdmAss.ASSId });
            modelBuilder.Entity<Admin>()
              .HasMany(AD => AD.AdminAssociations)
              .WithOne(D => D.Admin);
            modelBuilder.Entity<Association>()
                .HasMany(Ass => Ass.AdminAssociations)
                .WithOne(S => S.Association);

            // Admin & Category
            modelBuilder.Entity<AdminCategory>()
                .HasKey(Admcat => new { Admcat.CategoryID, Admcat.AdminId });
            modelBuilder.Entity<Admin>()
              .HasMany(AD => AD.AdminCategories)
              .WithOne(D => D.Admin);
            modelBuilder.Entity<Category>()
                .HasMany(Catg => Catg.AdminCategories)
                .WithOne(C => C.Category);

            // Product & Accosiation 
            modelBuilder.Entity<ProductAssociation>()
                .HasKey(PrdAss => new { PrdAss.ASSId, PrdAss.ProductID});
            modelBuilder.Entity<Product>()
              .HasMany(Prd => Prd.ProductAssociations)
              .WithOne(P => P.Product);
            modelBuilder.Entity<Association>()
                .HasMany(ass => ass.ProductAssociations)
                .WithOne(As => As.Association);

            // Product & User
            modelBuilder.Entity<ProductUser>()
               .HasKey(PrdUsr => new { PrdUsr.ProductID, PrdUsr.UserId });
            modelBuilder.Entity<Product>()
              .HasMany(Prd => Prd.ProductUsers)
              .WithOne(P => P.Product);
            modelBuilder.Entity<User>()
                .HasMany(Ur => Ur.ProductUsers)
                .WithOne(U => U.User);

            // User & Association 
            modelBuilder.Entity<UserAssociation>()
              .HasKey(UsrAss => new { UsrAss.UserId, UsrAss.ASSId});
            modelBuilder.Entity<Association>()
              .HasMany(ass => ass.UserAssociations)
              .WithOne(P => P.Association);
            modelBuilder.Entity<User>()
                .HasMany(Ur => Ur.UserAssociations)
                .WithOne(U => U.User);

            // composite primary key to feedback
            modelBuilder.Entity<Feedback>()
             .HasKey(Fed => new { Fed.ProductID, Fed.GaveFeedback });

            // composite to order Details
            modelBuilder.Entity<OrderDetail>()
         .HasKey(Ordt => new { Ordt.ProductId, Ordt.Quantity});


            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=Tabadol; Trusted_Connection=true;");
            base.OnConfiguring(optionsBuilder);
        }

        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Association> Associations { get; set; }
        public virtual DbSet<Card> Cards { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Feedback> Feedbacks { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<PersonalInformation> PersonalInformations { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet <User> Users { get; set; }

    }
}
