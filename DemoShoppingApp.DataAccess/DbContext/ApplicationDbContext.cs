using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using DemoShoppingApp.DataAccess.Models;

namespace DemoShoppingApp.DataAccess.DbContext
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        //public DbSet<Cart> Carts { get; set; }
        //public DbSet<OrderHeader> OrderHeaders { get; set; }
        //public DbSet<OrderDetail> OrderDetails { get; set; }
        //public DbSet<ApplicationUser> Categories { get; set; }

    }
}