﻿using Burger.DATA.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Burger.REPO.Interface
{
    public interface IOrderExtraREPO:IBaseREPO<OrderExtra>
    {
        int Create(IEnumerable<OrderExtra> entities);
        int Update(IEnumerable<OrderExtra> entities);
        int Delete(IEnumerable<OrderExtra> entities);
        IEnumerable<OrderExtra> GetByOrderId(int id);
        IEnumerable<OrderExtra> GetByExtraId(int id);
    }
}
