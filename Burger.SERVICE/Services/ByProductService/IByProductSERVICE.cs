using Burger.DATA.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Burger.SERVICE.Services.ByProductService
{
    public interface IByProductSERVICE
    {
        int Add(ByProduct entity);
        int Update(ByProduct entity);
        int Delete(ByProduct entity);

        Task<List<ByProduct>> GetAllAsync();
        Task<ByProduct> GetByIdAsync(int id);
    }
}
