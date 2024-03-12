using Burger.DATA.Concrete;
using Burger.DATA.Enums;
using Burger.REPO.Concrete;
using Burger.REPO.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Burger.SERVICE.Services.MenuService
{
    public class MenuSERVICE : IMenuSERVICE
    {
        private readonly IMenuREPO menuREPO;

        public MenuSERVICE(IMenuREPO menuREPO)
        {
            this.menuREPO = menuREPO;
        }

        public int Add(Menu entity)
        {
            entity.CreateDate = DateTime.Now;
            entity.Status = Status.Added;
            return menuREPO.Create(entity);
        }

        public int Delete(Menu entity)
        {
            entity.CreateDate = DateTime.Now;
            entity.Status = Status.Deleted;
            return menuREPO.Update(entity);
        }

        public async Task<List<Menu>> GetAllAsync()
        {
            return await menuREPO.GetAllAsync();
        }

        public async Task<Menu> GetByIdAsync(int id)
        {
            return await menuREPO.GetByIdAsync(id);
        }

        public int Update(Menu entity)
        {
            entity.CreateDate = DateTime.Now;
            entity.Status = Status.Modified;
            return menuREPO.Update(entity);
        }
    }
}
