using Burger.DATA.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Burger.REPO.Interface
{
    public interface IHamburgerExtraREPO : IBaseREPO<HamburgerExtra>
    {
        int Create(IEnumerable<HamburgerExtra> entities);
        int Update(IEnumerable<HamburgerExtra> entities);
        int Delete(IEnumerable<HamburgerExtra> entities);

        IEnumerable<HamburgerExtra> GetByBurgerId(int id);
    }
}
