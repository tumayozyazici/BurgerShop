using Burger.DATA.Concrete;
using Burger.DATA.Enums;
using Burger.SERVICE.Services.ByProductService;
using Burger.SERVICE.Services.ExtraService;
using Burger.SERVICE.Services.HamburgerService;
using Burger.SERVICE.Services.MenuService;
using Burger.SERVICE.Services.OrderByProductService;
using Burger.SERVICE.Services.OrderExtraService;
using Burger.SERVICE.Services.OrderHamburgerService;
using Burger.SERVICE.Services.OrderMenuService;
using Burger.SERVICE.Services.OrderService;
using Burger.SERVICE.Services.ShoppingCartService;
using Burger.WEBUI.Models;
using Burger.WEBUI.Models.VMs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Burger.WEBUI.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderSERVICE orderService;
        private readonly IOrderByProductSERVICE orderByProductService;
        private readonly IOrderMenuSERVICE orderMenuService;
        private readonly IOrderExtraSERVICE orderExtraService;
        private readonly IOrderHamburgerSERVICE orderHamburgerService;
        private readonly IMenuSERVICE menuService;
        private readonly IExtraSERVICE extraService;
        private readonly IHamburgerSERVICE hamburgerService;
        private readonly IByProductSERVICE byProductService;
        private readonly IShoppingCartSERVICE shoppingCartService;
        private readonly Guid _currentUserId;


        public OrderController(IOrderSERVICE orderService, IOrderByProductSERVICE orderByProductService, IOrderMenuSERVICE orderMenuService, IOrderExtraSERVICE orderExtraService, IOrderHamburgerSERVICE orderHamburgerService, IMenuSERVICE menuService, IExtraSERVICE extraService, IHamburgerSERVICE hamburgerService, IByProductSERVICE byProductService, IShoppingCartSERVICE shoppingCartService, IHttpContextAccessor httpContextAccessor)
        {
            this.orderService = orderService;
            this.orderByProductService = orderByProductService;
            this.orderMenuService = orderMenuService;
            this.orderExtraService = orderExtraService;
            this.orderHamburgerService = orderHamburgerService;
            this.menuService = menuService;
            this.extraService = extraService;
            this.hamburgerService = hamburgerService;
            this.byProductService = byProductService;
            this.shoppingCartService = shoppingCartService;
            _currentUserId = Guid.Parse(httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
        }
        
        [HttpPost]
        public async Task<IActionResult> Index(ShoppingCartVM vm)
        {
            Order order = new Order();
            order.TotalPrice = vm.TotalPrice;
            order.UserId = _currentUserId.ToString();
            orderService.Add(order);
            

            foreach (CartItem item in vm.CartItems)
            {
                if (item.OrderType == OrderItems.Menu)
                {
                    List<OrderMenu> orderMenu = new List<OrderMenu>();
                    orderMenu.Add(new OrderMenu() { OrderId =order.Id, MenuId = item.Id });
                    orderMenuService.Create(orderMenu);
                    shoppingCartService.DeleteMenu(item.Id,item.Quantity);
                }
                if (item.OrderType == OrderItems.ByProduct)
                {
                    List<OrderByProduct> orderByProduct = new List<OrderByProduct>();
                    orderByProduct.Add(new OrderByProduct() { OrderId = order.Id, ByProductId = item.Id });
                    orderByProductService.Create(orderByProduct);
                    shoppingCartService.DeleteByProduct(item.Id, item.Quantity);
                }
                if (item.OrderType == OrderItems.Extra)
                {
                    List<OrderExtra> orderExtra = new List<OrderExtra>();
                    orderExtra.Add(new OrderExtra() { OrderId = order.Id, ExtraId = item.Id });
                    orderExtraService.Create(orderExtra);
                    shoppingCartService.DeleteExtra(item.Id, item.Quantity);
                }
                if (item.OrderType == OrderItems.Hamburger)
                {
                    List<OrderHamburger> orderHamburger = new List<OrderHamburger>();
                    orderHamburger.Add(new OrderHamburger() { OrderId = order.Id, HamburgerId = item.Id });
                    orderHamburgerService.Create(orderHamburger);
                    shoppingCartService.DeleteHamburger(item.Id, item.Quantity);
                }
            }
            return RedirectToAction();
        }
    }
}
