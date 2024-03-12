using Burger.DATA.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Burger.SERVICE.Services.OrderService
{
    public interface IOrderSERVICE
    {
        int Add(Order entity);
        int Update(Order entity);
        int Delete(Order entity);

        Task<List<Order>> GetAllAsync();
        Task<Order> GetByIdAsync(int id);
    }
}
