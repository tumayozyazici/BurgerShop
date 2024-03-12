using Burger.DATA.Concrete;
using Burger.DATA.Enums;
using Burger.REPO.Concrete;
using Burger.REPO.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Burger.SERVICE.Services.ExtraService
{
    public class ExtraSERVICE : IExtraSERVICE
    {
        private readonly IExtraREPO extraREPO;
        public int Add(Extra entity)
        {
            entity.CreateDate = DateTime.Now;
            entity.Status = Status.Added;
            return extraREPO.Create(entity);
        }

        public int Delete(Extra entity)
        {
            entity.CreateDate = DateTime.Now;
            entity.Status = Status.Deleted;
            return extraREPO.Update(entity);
        }

        public async Task<List<Extra>> GetAllAsync()
        {
            return await extraREPO.GetAllAsync();
        }

        public async Task<Extra> GetByIdAsync(int id)
        {
            return await extraREPO.GetByIdAsync(id);
        }

        public int Update(Extra entity)
        {
            entity.CreateDate = DateTime.Now;
            entity.Status = Status.Modified;
            return extraREPO.Update(entity);
        }
    }
}
