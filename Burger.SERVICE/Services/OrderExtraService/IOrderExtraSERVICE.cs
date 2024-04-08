using Burger.DATA.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Burger.SERVICE.Services.OrderExtraService
{
    public interface IOrderExtraSERVICE
    {
        Task<int> Create(IEnumerable<OrderExtra> entities);
        int Update(IEnumerable<OrderExtra> entities);
        int Delete(IEnumerable<OrderExtra> entities);
        IEnumerable<OrderExtra> GetByOrderId(int id);
        IEnumerable<OrderExtra> GetByExtraId(int id);
    }
}
