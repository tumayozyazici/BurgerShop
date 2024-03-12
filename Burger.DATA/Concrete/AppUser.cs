using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Burger.DATA.Concrete
{
    public class AppUser: IdentityUser
    {
        public AppUser()
        {
            Orders = new HashSet<Order>();
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }


        //Nav
        public virtual ICollection<Order> Orders { get; set; }
    }
}
