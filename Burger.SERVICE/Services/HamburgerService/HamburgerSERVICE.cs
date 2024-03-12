using Burger.DATA.Concrete;
using Burger.DATA.Enums;
using Burger.REPO.Concrete;
using Burger.REPO.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Burger.SERVICE.Services.HamburgerService
{
    public class HamburgerSERVICE : IHamburgerSERVICE
    {
        private readonly IHamburgerREPO hamburgerREPO;

        public HamburgerSERVICE(IHamburgerREPO hamburgerREPO)
        {
            this.hamburgerREPO = hamburgerREPO;
        }

        public int Add(Hamburger entity)
        {
            entity.CreateDate = DateTime.Now;
            entity.Status = Status.Added;
            return hamburgerREPO.Create(entity);
        }

        public int Delete(Hamburger entity)
        {
            entity.CreateDate = DateTime.Now;
            entity.Status = Status.Deleted;
            return hamburgerREPO.Update(entity);
        }

        public async Task<List<Hamburger>> GetAllAsync()
        {
            return await hamburgerREPO.GetAllAsync();
        }

        public async Task<Hamburger> GetByIdAsync(int id)
        {
            return await hamburgerREPO.GetByIdAsync(id);
        }

        public int Update(Hamburger entity)
        {
            entity.CreateDate = DateTime.Now;
            entity.Status = Status.Modified;
            return hamburgerREPO.Update(entity);
        }
    }
}
