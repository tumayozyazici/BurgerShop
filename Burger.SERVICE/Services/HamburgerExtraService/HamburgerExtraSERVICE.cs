using Burger.DATA.Concrete;
using Burger.REPO.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Burger.SERVICE.Services.HamburgerExtraService
{
    public class HamburgerExtraSERVICE : IHamburgerExtraSERVICE
    {
        private readonly IHamburgerExtraREPO _hamburgerExtraREPO;

        public HamburgerExtraSERVICE(IHamburgerExtraREPO hamburgerExtraREPO)
        {
            _hamburgerExtraREPO = hamburgerExtraREPO;
        }

        public int Create(IEnumerable<HamburgerExtra> entities)
        {
            return _hamburgerExtraREPO.Create(entities);
        }

        public int Delete(IEnumerable<HamburgerExtra> entities)
        {
            return _hamburgerExtraREPO.Delete(entities);
        }

        public Task<List<HamburgerExtra>> GetAllAsync()
        {
            return _hamburgerExtraREPO.GetAllAsync();
        }

        public IEnumerable<HamburgerExtra> GetByBurgerId(int id)
        {
            return _hamburgerExtraREPO.GetByBurgerId(id);
        }

        public int Update(IEnumerable<HamburgerExtra> entities)
        {
            return _hamburgerExtraREPO.Update(entities);
        }
    }
}
