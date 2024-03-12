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
    public class MenuMapping : IEntityTypeConfiguration<Menu>
    {
        public void Configure(EntityTypeBuilder<Menu> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasMany(x=>x.OrderMenus).WithOne(x => x.Menu).HasForeignKey(x=>x.MenuId);
        }
    }
}
