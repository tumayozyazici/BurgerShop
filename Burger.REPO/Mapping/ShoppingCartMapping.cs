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
    public class ShoppingCartMapping : IEntityTypeConfiguration<ShoppingCart>
    {
        public void Configure(EntityTypeBuilder<ShoppingCart> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasMany(x => x.Menus).WithOne(x => x.ShoppingCart).HasForeignKey(x => x.ShoppingCartId);
            builder.HasMany(x => x.Extras).WithOne(x => x.ShoppingCart).HasForeignKey(x => x.ShoppingCartId);
            builder.HasMany(x => x.ByProducts).WithOne(x => x.ShoppingCart).HasForeignKey(x => x.ShoppingCartId);
            builder.HasMany(x => x.Hamburgers).WithOne(x => x.ShoppingCart).HasForeignKey(x => x.ShoppingCartId);
        }
    }
}
