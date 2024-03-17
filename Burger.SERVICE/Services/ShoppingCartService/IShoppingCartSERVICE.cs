using Burger.DATA.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Burger.SERVICE.Services.ShoppingCartService
{
    public interface IShoppingCartSERVICE
    {

        Task<ShoppingCart> AddMenu(int menuId, int quantity);

        Task<ShoppingCart> AddHamburger(int hamburgerId, int quantity);

        Task<ShoppingCart> AddExtra(int extraId, int quantity);

        Task<ShoppingCart> AddByProduct(int byProductId, int quantity);

        Task<ShoppingCart> GetCurrentUserShoppingcart();
    }
}
