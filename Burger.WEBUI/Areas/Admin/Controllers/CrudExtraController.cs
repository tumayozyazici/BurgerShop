using Burger.DATA.Concrete;
using Burger.DATA.Enums;
using Burger.SERVICE.Services.ByProductService;
using Burger.SERVICE.Services.ExtraService;
using Burger.WEBUI.Areas.Admin.Models.VMs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Burger.WEBUI.Areas.Admin.Controllers
{
    [Authorize(Policy = "AdminPolicy")]
    [Area("Admin")]
    public class CrudExtraController : Controller
    {
        private readonly IExtraSERVICE extraSERVICE;

        public CrudExtraController(IExtraSERVICE extraSERVICE)
        {
            this.extraSERVICE = extraSERVICE;
        }

        public async Task<IActionResult> Index()
        {
            var result = await extraSERVICE.GetAllAsync();
            ViewBag.controller = "CrudExtra";
            ViewBag.baslik = "Sos";
            if (result.Count > 0)
            {
                return View(result);
            }
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Title = "Create";
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateUpdateExtraVM vm)
        {
            Extra extra = new Extra() { Name = vm.Name, Price = vm.Price, Description = vm.Description };
            extraSERVICE.Add(extra);
            return RedirectToAction("Index", "CrudExtra");
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var result = await extraSERVICE.GetByIdAsync(id);
            CreateUpdateExtraVM vm = new CreateUpdateExtraVM() { Id = id, Name = result.Name, Description = result.Description, Price = result.Price };
            ViewBag.Title = "Update";
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Update(CreateUpdateExtraVM vm)
        {
            Extra extra = await extraSERVICE.GetByIdAsync(vm.Id);
            extra.Name = vm.Name;
            extra.Price = vm.Price;
            extra.Description = vm.Description;
            extraSERVICE.Update(extra);
            return RedirectToAction("Index", "CrudExtra");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            Extra extra = await extraSERVICE.GetByIdAsync(id);
            extraSERVICE.Delete(extra);
            return RedirectToAction("Index", "CrudExtra");
        }
    }
}
