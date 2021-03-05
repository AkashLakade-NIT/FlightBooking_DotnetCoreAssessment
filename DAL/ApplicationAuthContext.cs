using DAL.Security;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class ApplicationAuthContext : IdentityDbContext<User,Role,int>
    {
        public ApplicationAuthContext(DbContextOptions<ApplicationAuthContext> opt) : base(opt)
        {

        }
        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    builder.Entity<IdentityUserRole<int>>(a =>
        //    {
        //        a.HasKey(x => new { x.UserId, x.RoleId });
        //    });

        //    builder.Entity<IdentityUserLogin<int>>(i =>
        //    {
        //        i.HasKey(x => new { x.ProviderKey, x.LoginProvider });
        //    });
        //    builder.Entity<IdentityRoleClaim<int>>(i =>
        //    {
        //        i.HasKey(x => x.Id);
        //    });
        //    builder.Entity<IdentityUserClaim<int>>(i =>
        //    {
        //        i.HasKey(x => x.Id);
        //    });
        //    builder.Entity<IdentityUserToken<int>>(i =>
        //    {
        //        i.HasKey(x => x.UserId);
        //    });


        //    base.OnModelCreating(builder);
        //}
        public DbSet<User> AspNetUsers { get; set; }
        public DbSet<Role> AspNetRoles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data source=NIT-LPT-R240;Integrated Security=true;Initial Catalog=UserIdentityDB;");
            }
        }

    }
}
