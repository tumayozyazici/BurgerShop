using Burger.DATA.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Burger.SERVICE.Services.MenuService
{
    public interface IMenuSERVICE
    {
        int Add(Menu entity);
        int Update(Menu entity);
        int Delete(Menu entity);

        Task<List<Menu>> GetAllAsync();
        Task<Menu> GetByIdAsync(int id);
    }
}
