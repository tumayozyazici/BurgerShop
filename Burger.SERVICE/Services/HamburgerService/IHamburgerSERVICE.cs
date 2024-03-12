using Burger.DATA.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Burger.SERVICE.Services.HamburgerService
{
    public interface IHamburgerSERVICE
    {
        int Add(Hamburger entity);
        int Update(Hamburger entity);
        int Delete(Hamburger entity);

        Task<List<Hamburger>> GetAllAsync();
        Task<Hamburger> GetByIdAsync(int id);
    }
}
