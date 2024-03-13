using Burger.DATA.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Burger.REPO.Contexts
{
    public class BurgerDbContext : IdentityDbContext<AppUser, AppRole, string>
    {
        public DbSet<AppRole> AppRoles { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Hamburger> Hamburger { get; set; }
        public DbSet<HamburgerExtra> HamburgerExtras { get; set; }
        public DbSet<ByProduct> ByProducts { get; set; }
        public DbSet<Extra> Extras { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<MenuHamburger> MenuHamburgers { get; set; }
        public DbSet<MenuByProduct> MenuByProducts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderHamburger> OrderHamburgers { get; set; }
        public DbSet<OrderByProduct> OrderByProducts { get; set; }
        public DbSet<OrderMenu> OrderMenus { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=GHOST2023\\SQLEXPRESS;Database=BurgerShop;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}
