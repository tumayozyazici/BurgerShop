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
    public class ByProductMapping : IEntityTypeConfiguration<ByProduct>
    {
        public void Configure(EntityTypeBuilder<ByProduct> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasMany(x=>x.MenuByProducts).WithOne(x=>x.ByProduct).HasForeignKey(x=>x.ByProductId);
            builder.HasMany(x => x.OrderByProducts).WithOne(x => x.ByProduct).HasForeignKey(x => x.ByProductId);
        }
    }
}
