using Burger.DATA.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Burger.SERVICE.Services.CartService
{
    public interface ICartSERVICE
    {
        int Add(Cart entity);
        int Update(Cart entity);
        int Delete(Cart entity);

        Task<List<Cart>> GetAllAsync();
        Task<Cart> GetByIdAsync(int id);
    }
}
