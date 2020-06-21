using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using myPOS.Data.Extentions;
using myPOS.Entities;

namespace myPOS.Data.Context
{
   public class myDbContext : IdentityDbContext<User>
    {
        public myDbContext() { }

        public myDbContext(DbContextOptions<myDbContext> options)
        : base(options) { }

        public virtual DbSet<UsersTransactions> UsersTransactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Many-To-Many Relationship UserTasks

            modelBuilder.Entity<User>()
                .HasMany(ut => ut.TransactionTo); 
            modelBuilder.Entity<User>()
                .HasMany(ut => ut.TransactionFrom);
            modelBuilder.Entity<UsersTransactions>()
                .HasOne(uf => uf.UserFrom)
                .WithMany(tr=> tr.TransactionFrom);
            modelBuilder.Entity<UsersTransactions>()
                .HasOne(ut => ut.UserTo)
                .WithMany(tr => tr.TransactionTo);
            #endregion


            modelBuilder.Roles();
            base.OnModelCreating(modelBuilder);
        }
    }
}
