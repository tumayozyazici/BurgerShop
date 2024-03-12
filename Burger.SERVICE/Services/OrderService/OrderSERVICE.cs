using Burger.DATA.Concrete;
using Burger.DATA.Enums;
using Burger.REPO.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Burger.SERVICE.Services.OrderService
{
    public class OrderSERVICE : IOrderSERVICE
    {
        private readonly IOrderREPO orderREPO;

        public OrderSERVICE(IOrderREPO orderREPO)
        {
            this.orderREPO = orderREPO;
        }

        public int Add(Order entity)
        {
            entity.CreateDate = DateTime.Now;
            entity.Status = Status.Added;
            return orderREPO.Create(entity);
        }

        public int Delete(Order entity)
        {
            entity.CreateDate = DateTime.Now;
            entity.Status = Status.Deleted;
            return orderREPO.Update(entity);
        }

        public async Task<List<Order>> GetAllAsync()
        {
            return await orderREPO.GetAllAsync();
        }

        public async Task<Order> GetByIdAsync(int id)
        {
            return await orderREPO.GetByIdAsync(id);
        }

        public int Update(Order entity)
        {
            entity.CreateDate = DateTime.Now;
            entity.Status = Status.Modified;
            return orderREPO.Update(entity);
        }
    }
}
