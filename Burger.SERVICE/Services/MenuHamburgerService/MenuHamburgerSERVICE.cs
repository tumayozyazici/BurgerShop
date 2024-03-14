using Burger.DATA.Concrete;
using Burger.REPO.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Burger.SERVICE.Services.MenuHamburgerService
{
    public class MenuHamburgerSERVICE : IMenuHamburgerSERVICE
    {
        private readonly IMenuHamburgerREPO _menuHamburgerREPO;

        public MenuHamburgerSERVICE(IMenuHamburgerREPO menuHamburgerREPO)
        {
            _menuHamburgerREPO = menuHamburgerREPO;
        }

        public int Create(IEnumerable<MenuHamburger> entities)
        {
            return _menuHamburgerREPO.Create(entities);
        }

        public int Delete(IEnumerable<MenuHamburger> entities)
        {
            return _menuHamburgerREPO.Delete(entities);
        }

        public IEnumerable<MenuHamburger> GetByBurgerId(int burgerId)
        {
            return _menuHamburgerREPO.GetByBurgerId(burgerId);
        }

        public IEnumerable<MenuHamburger> GetByMenuId(int menuId)
        {
            return _menuHamburgerREPO.GetByMenuId(menuId);
        }

        public int Update(IEnumerable<MenuHamburger> entities)
        {
            return _menuHamburgerREPO.Update(entities);
        }
    }
}
