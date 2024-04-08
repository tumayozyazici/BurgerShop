using Burger.DATA.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Burger.REPO.Interface
{
    public interface IOrderHamburgerREPO : IBaseREPO<OrderHamburger>
    {
        Task<int> Create(IEnumerable<OrderHamburger> entities);
        int Update(IEnumerable<OrderHamburger> entities);
        int Delete(IEnumerable<OrderHamburger> entities);
        IEnumerable<OrderHamburger> GetByOrderId(int id);
        IEnumerable<OrderHamburger> GetByBurgerId(int id);
    }
}
