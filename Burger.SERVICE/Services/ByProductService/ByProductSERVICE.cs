using Burger.DATA.Concrete;
using Burger.DATA.Enums;
using Burger.REPO.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Burger.SERVICE.Services.ByProductService
{
    public class ByProductSERVICE : IByProductSERVICE
    {
        private readonly IByProductREPO byProductREPO;

        public ByProductSERVICE(IByProductREPO byProductREPO)
        {
            this.byProductREPO = byProductREPO;
        }

        public int Add(ByProduct entity)
        {
            entity.CreateDate = DateTime.Now;
            entity.Status = Status.Added;
            return byProductREPO.Create(entity);
        }

        public int Delete(ByProduct entity)
        {
            entity.CreateDate = DateTime.Now;
            entity.Status = Status.Deleted;
            return byProductREPO.Update(entity);
        }

        public async Task<List<ByProduct>> GetAllAsync()
        {
            return await byProductREPO.GetAllAsync();
        }

        public async Task<ByProduct> GetByIdAsync(int id)
        {
            return await byProductREPO.GetByIdAsync(id);
        }

        public int Update(ByProduct entity)
        {
            entity.CreateDate = DateTime.Now;
            entity.Status = Status.Modified;
            return byProductREPO.Update(entity);
        }
    }
}
