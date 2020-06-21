using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using myPOS.Entities;

namespace myPOS.Data.Extentions
{
   public static class SeedRole
    {
        public static void Roles(this ModelBuilder modelBuilder)
        {
            #region Create roles
            modelBuilder
                .Entity<UserRole>()
                .HasData(new IdentityRole
                {
                    Id = "a5e38752-84ae-4352-a0b6-bf47b3fd460a",
                    Name = "Administrator",
                    NormalizedName = "ADMINISTRATOR"
                });

            modelBuilder
              .Entity<UserRole>()
              .HasData(new IdentityRole
              {
                  Id = "d90e75c6-7da9-490e-aeb0-3d8c4827e193",
                  Name = "User",
                  NormalizedName = "USER"
              });
            #endregion

            #region Create Users
            var hasher = new PasswordHasher<User>();

            var adminDimo = new User
            {
                Id = "69e7930c-3df5-4261-99cf-0352eb018a91",
                UserName = "dimo@administrator.com",
                NormalizedUserName = "DIMO@ADMINISTRATOR.COM",
                Email = "dimo@administrator.com",
                NormalizedEmail = "DIMO@ADMINISTRATOR.COM",
                SecurityStamp = "7I5VNHIJTSZNOT3KDWKNFUV5PVYBHGXN",
                LockoutEnabled = true
            };

            #endregion

            #region Set passwords of users
            adminDimo.PasswordHash = hasher
                .HashPassword(adminDimo, "12345");

            #endregion

            #region Set user to role
            modelBuilder.Entity<User>()
                .HasData(adminDimo);

            modelBuilder
                .Entity<IdentityUserRole<string>>()
                .HasData(new IdentityUserRole<string>
                { UserId = adminDimo.Id, RoleId = "a5e38752-84ae-4352-a0b6-bf47b3fd460a" });
            #endregion
        }
    }
}
