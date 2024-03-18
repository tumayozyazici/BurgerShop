using Burger.DATA.Enums;
using Burger.DATA.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Burger.DATA.Concrete
{
    public class ByProduct : BaseEntity
    {
        public string Name { get; set; }

        public double Price { get; set; }

        public string? Photo {  get; set; }

        public string? Description { get; set; }

        public Size Size { get; set; } = Size.Medium;

        public ByProductType ByProductType { get; set; }

        public OrderItems OrderType { get; set; } = OrderItems.ByProduct;


        //Nav
        public virtual ICollection<MenuByProduct> MenuByProducts { get; set; }
        public virtual ICollection<OrderByProduct>? OrderByProducts { get; set; }
    }
}
