using Burger.DATA.Concrete;
using Burger.DATA.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Burger.REPO.Interface
{
    public interface IByProductREPO : IBaseREPO<ByProduct>
    {
        List<ByProduct> JoinedGetWhereByMenuIdProductType(int id, ByProductType type);
    }
}
