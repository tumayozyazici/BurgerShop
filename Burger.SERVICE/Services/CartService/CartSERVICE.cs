using Burger.DATA.Concrete;
using Burger.REPO.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Burger.SERVICE.Services.CartService
{
    public class CartSERVICE : ICartSERVICE
    {
        private readonly ICartREPO cartREPO;

        public CartSERVICE(ICartREPO cartREPO)
        {
            this.cartREPO = cartREPO;
        }

        public int Add(Cart entity)
        {
            return cartREPO.Create(entity);
        }

        public int Delete(Cart entity)
        {
            return cartREPO.Delete(entity);
        }

        public async Task<List<Cart>> GetAllAsync()
        {
            return await cartREPO.GetAllAsync();
        }

        public async Task<Cart> GetByIdAsync(int id)
        {
            return await cartREPO.GetByIdAsync(id);
        }

        public int Update(Cart entity)
        {
            return cartREPO.Update(entity);
        }
    }
}
