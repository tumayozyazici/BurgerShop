using Burger.DATA.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Burger.SERVICE.Services.ExtraService
{
    public interface IExtraSERVICE
    {
        int Add(Extra entity);
        int Update(Extra entity);
        int Delete(Extra entity);

        Task<List<Extra>> GetAllAsync();
        Task<Extra> GetByIdAsync(int id);
    }
}
