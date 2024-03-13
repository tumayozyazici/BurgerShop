using Burger.DATA.Concrete;
using Burger.REPO.Concrete;
using Burger.REPO.Contexts;
using Burger.REPO.Interface;
using Burger.SERVICE.Services.ByProductService;
using Burger.SERVICE.Services.ExtraService;
using Burger.SERVICE.Services.HamburgerExtraService;
using Burger.SERVICE.Services.HamburgerService;
using Burger.SERVICE.Services.MenuByProductService;
using Burger.SERVICE.Services.MenuHamburgerService;
using Burger.SERVICE.Services.MenuService;
using Burger.SERVICE.Services.OrderByProductService;
using Burger.SERVICE.Services.OrderHamburgerService;
using Burger.SERVICE.Services.OrderMenuService;
using Burger.SERVICE.Services.OrderService;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Burger.WEBUI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            // DbContext
            builder.Services.AddDbContext<BurgerDbContext>();

            // Repo
            builder.Services.AddScoped<IByProductREPO, ByProductREPO>();
            builder.Services.AddScoped<IExtraREPO, ExtraREPO>();
            builder.Services.AddScoped<IHamburgerExtraREPO, HamburgerExtraREPO>();
            builder.Services.AddScoped<IHamburgerREPO, HamburgerREPO>();
            builder.Services.AddScoped<IMenuByProductREPO, MenuByProductREPO>();
            builder.Services.AddScoped<IMenuHamburgerREPO, MenuHamburgerREPO>();
            builder.Services.AddScoped<IMenuREPO, MenuREPO>();
            builder.Services.AddScoped<IOrderByProductREPO, OrderByProductREPO>();
            builder.Services.AddScoped<IOrderHamburgerREPO, OrderHamburgerREPO>();
            builder.Services.AddScoped<IOrderMenuREPO, OrderMenuREPO>();
            builder.Services.AddScoped<IOrderREPO, OrderREPO>();

            // Service
            builder.Services.AddScoped<IByProductSERVICE, ByProductSERVICE>();
            builder.Services.AddScoped<IExtraSERVICE, ExtraSERVICE>();
            builder.Services.AddScoped<IHamburgerExtraSERVICE, HamburgerExtraSERVICE>();
            builder.Services.AddScoped<IHamburgerSERVICE, HamburgerSERVICE>();
            builder.Services.AddScoped<IMenuByProductSERVICE, MenuByProductSERVICE>();
            builder.Services.AddScoped<IMenuHamburgerSERVICE, MenuHamburgerSERVICE>();
            builder.Services.AddScoped<IMenuSERVICE, MenuSERVICE>();
            builder.Services.AddScoped<IOrderByProductSERVICE, OrderByProductSERVICE>();
            builder.Services.AddScoped<IOrderHamburgerSERVICE, OrderHamburgerSERVICE>();
            builder.Services.AddScoped<IOrderMenuSERVICE, OrderMenuSERVICE>();
            builder.Services.AddScoped<IOrderSERVICE, OrderSERVICE>();

            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy("AdminPolicy", policy =>
                    policy.RequireRole("admin"));
            });

            //IDENTITY  
            builder.Services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<BurgerDbContext>().AddDefaultTokenProviders();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                //endpoints.MapControllerRoute(
                //    name: "areas",
                //    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
                app.MapAreaControllerRoute(
                name: "admin",
                areaName: "Admin",
                pattern: "Admin/{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            app.Run();
        }
    }
}