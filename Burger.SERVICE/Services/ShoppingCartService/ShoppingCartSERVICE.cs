using Burger.DATA.Concrete;
using Burger.REPO.Interface;
using Burger.SERVICE.Services.ShoppingCartService;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Burger.SERVICE.Services.ShoppingCartService
{
    public class ShoppingCartSERVICE : IShoppingCartSERVICE
    {
        private readonly IShoppingCartREPO _shoppingCartREPO;
        private readonly IHamburgerREPO _hamburgerREPO;
        private readonly IMenuREPO _menuREPO;
        private readonly IExtraREPO _extraREPO;
        private readonly IByProductREPO _byProductREPO;
        private readonly Guid _currentUserId;

        public ShoppingCartSERVICE(IShoppingCartREPO shoppingCartRepo, IHamburgerREPO hamburgerRepo, IMenuREPO menuRepo, IExtraREPO extraRepo, IByProductREPO byProductRepo, IHttpContextAccessor httpContextAccessor)
        {
            _shoppingCartREPO = shoppingCartRepo;
            _hamburgerREPO = hamburgerRepo;
            _menuREPO = menuRepo;
            _extraREPO = extraRepo;
            _byProductREPO = byProductRepo;
            // her userin bir tane shopping cartı bulunur. eğer yoksa oluşturulur. eğer login den userId gelmiyorsa bir security erroru fırlatılmalı !!
            _currentUserId = Guid.Parse(httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
        }
        public async Task<ShoppingCart> AddByProduct(int byProductId, int quantity)
        {
            var shoppingCart = await GetCurrentUserShoppingcart();

            var byProduct = await _byProductREPO.GetByIdAsync(byProductId);
            if (byProduct == null)
            {
                throw new Exception("Eklemek istediğiniz extra bulunamadı...");
            }

            var currentProduct = shoppingCart.ByProducts.FirstOrDefault(product => product.ByProductId == byProductId);
            if (currentProduct != null)
            {
                currentProduct.Quantity += quantity;
            }
            else
            {
                shoppingCart.ByProducts.Add(new ShoppingCartByProduct()
                {
                    ByProductId = byProductId,
                    Quantity = quantity,
                    ByProduct = byProduct
                });
            }




            CalculateTotal(shoppingCart);
            _shoppingCartREPO.Update(shoppingCart);

            return shoppingCart;
        }

        public async Task<ShoppingCart> AddExtra(int extraId, int quantity)
        {
            var shoppingCart = await GetCurrentUserShoppingcart();

            var extra = await _extraREPO.GetByIdAsync(extraId);
            if (extra == null)
            {
                throw new Exception("Eklemek istediğiniz extra bulunamadı...");
            }

            var currentExtra = shoppingCart.Extras.FirstOrDefault(extra => extra.ExtraId == extraId);
            if (currentExtra != null)
            {
                currentExtra.Quantity += quantity;
            }
            else
            {
                shoppingCart.Extras.Add(new ShoppingCartExtra()
                {
                    ExtraId = extraId,
                    Quantity = quantity,
                    Extra = extra
                });
            }


            CalculateTotal(shoppingCart);
            _shoppingCartREPO.Update(shoppingCart);
            return shoppingCart;
        }

        public async Task<ShoppingCart> AddHamburger(int hamburgerId, int quantity)
        {
            var shoppingCart = await GetCurrentUserShoppingcart();

            var hamburger = await _hamburgerREPO.GetByIdAsync(hamburgerId);
            if (hamburger == null)
            {
                throw new Exception("Eklemek istediğiniz hamburger bulunamadı...");
            }

            var currentHamburger = shoppingCart.Hamburgers.FirstOrDefault(currentHamburger => currentHamburger.HamburgerId == hamburgerId);
            if (currentHamburger != null)
            {
                currentHamburger.Quantity += quantity;
            }
            else
            {
                shoppingCart.Hamburgers.Add(new ShoppingCartHamburger()
                {
                    HamburgerId = hamburgerId,
                    Quantity = quantity,
                    Hamburger = hamburger
                });
            }

            CalculateTotal(shoppingCart);
            _shoppingCartREPO.Update(shoppingCart);
            return shoppingCart;
        }

        public async Task<ShoppingCart> AddMenu(int menuId, int quantity)
        {
            var shoppingCart = await GetCurrentUserShoppingcart();

            var menu = await _menuREPO.GetByIdAsync(menuId);
            if (menu == null)
            {
                throw new Exception("Eklemek istediğiniz menu bulunamadı...");
            }

            var currentCartMenu = shoppingCart.Menus.FirstOrDefault(menu => menu.MenuId == menuId);
            if (currentCartMenu != null)
            {
                currentCartMenu.Quantity += quantity;
            }
            else
            {
                shoppingCart.Menus.Add(new ShoppingCartMenu()
                {
                    MenuId = menuId,
                    Quantity = quantity,
                    Menu = menu
                });
            }

            CalculateTotal(shoppingCart);
            _shoppingCartREPO.Update(shoppingCart);
            return shoppingCart;
        }

        public async Task<ShoppingCart> GetCurrentUserShoppingcart()
        {
            var shoppingCart = await _shoppingCartREPO.GetUserShoppingCart(_currentUserId);

            /*await _shoppingCartREPO.GetFilteredFirstOrDefaultAsync(sc => sc, sc => sc.UserId == _currentUserId);*/
            if (shoppingCart == null)
            {
                shoppingCart = new ShoppingCart()
                {
                    UserId = _currentUserId
                };

                _shoppingCartREPO.Create(shoppingCart);
            }

            return shoppingCart;
        }

        private void CalculateTotal(ShoppingCart shoppingCart)
        {
            double totalPrice = 0;
            foreach (var menu in shoppingCart.Menus)
            {
                totalPrice += menu.Quantity * menu.Menu.Price;
            }

            foreach (var hamburger in shoppingCart.Hamburgers)
            {
                totalPrice += hamburger.Quantity * hamburger.Hamburger.Price;
            }

            foreach (var extra in shoppingCart.Extras)
            {
                totalPrice += extra.Quantity * extra.Extra.Price;
            }

            foreach (var byProduct in shoppingCart.ByProducts)
            {
                totalPrice += byProduct.Quantity * byProduct.ByProduct.Price;
            }

            shoppingCart.TotalPrice = totalPrice;
        }
    }
}
