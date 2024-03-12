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
    public class ExtraMapping : IEntityTypeConfiguration<Extra>
    {
        public void Configure(EntityTypeBuilder<Extra> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasMany(x => x.HamburgerExtras).WithOne(x => x.Extra).HasForeignKey(x => x.ExtraId);
        }
    }
}
