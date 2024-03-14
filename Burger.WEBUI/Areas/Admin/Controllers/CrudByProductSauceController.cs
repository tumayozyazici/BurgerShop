﻿using Burger.DATA.Concrete;
using Burger.DATA.Enums;
using Burger.SERVICE.Services.ByProductService;
using Burger.WEBUI.Areas.Admin.Models.VMs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Burger.WEBUI.Areas.Admin.Controllers
{
    [Authorize(Policy = "AdminPolicy")]
    [Area("Admin")]
    public class CrudByProductSauceController : Controller
    {

        private readonly IByProductSERVICE byProductSERVICE;

        public CrudByProductSauceController(IByProductSERVICE byProductSERVICE)
        {
            this.byProductSERVICE = byProductSERVICE;
        }

        public async Task<IActionResult> Index()
        {
            var result = await byProductSERVICE.GetAllAsync();
            ViewBag.controller = "CrudByProductSauce";
            ViewBag.baslik = "Sos";
            ViewBag.type = ByProductType.Sauces;
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
        public IActionResult Create(CreateUpdateByProductVM vm)
        {
            ByProduct byProduct = new ByProduct() { Name = vm.Name, Price = vm.Price, Description = vm.Description };
            byProduct.ByProductType = ByProductType.Sauces;
            byProductSERVICE.Add(byProduct);
            return RedirectToAction("Index", "CrudByProductSauce");
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var result = await byProductSERVICE.GetByIdAsync(id);
            CreateUpdateByProductVM vm = new CreateUpdateByProductVM() { Id = id, Name = result.Name, Description = result.Description, Price = result.Price };
            ViewBag.Title = "Update";
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Update(CreateUpdateByProductVM vm)
        {
            ByProduct byProduct = await byProductSERVICE.GetByIdAsync(vm.Id);
            byProduct.Name = vm.Name;
            byProduct.Price = vm.Price;
            byProduct.Description = vm.Description;
            byProductSERVICE.Update(byProduct);
            return RedirectToAction("Index", "CrudByProductSauce");

        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            ByProduct byProduct = await byProductSERVICE.GetByIdAsync(id);
            byProductSERVICE.Delete(byProduct);
            return RedirectToAction("Index", "CrudByProductSauce");
        }

    }
}