using Burger.DATA.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Burger.REPO.Interface
{
    public interface IMenuHamburgerREPO : IBaseREPO<MenuHamburger>
    {
        int Create(IEnumerable<MenuHamburger> entities);
        int Update(IEnumerable<MenuHamburger> entities);
        int Delete(IEnumerable<MenuHamburger> entities);
        IEnumerable<MenuHamburger> GetByMenuId(int menuId);
        IEnumerable<MenuHamburger> GetByBurgerId(int burgerId);
    }
}
