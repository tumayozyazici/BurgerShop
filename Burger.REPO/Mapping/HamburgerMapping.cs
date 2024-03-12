using Burger.DATA.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Burger.REPO.Mapping
{
    public class HamburgerMapping : IEntityTypeConfiguration<Hamburger>
    {
        public void Configure(EntityTypeBuilder<Hamburger> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasMany(x=>x.MenuHamburgers).WithOne(x=>x.Hamburger).HasForeignKey(x=>x.HamburgerId);
            builder.HasMany(x => x.OrderHamburgers).WithOne(x => x.Hamburger).HasForeignKey(x => x.HamburgerId);

        }
    }
}
