using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OutdoorPower.Models;
using OutdoorPower.ViewModels;

namespace OutdoorPower.Controllers
{
    public class ProductController : Controller
    {
        private readonly IOutdoorPowerRepository _outdoorPowerRepository;

        public ProductController(IOutdoorPowerRepository outdoorPowerRepository)
        {
            _outdoorPowerRepository = outdoorPowerRepository;
        }
        public IActionResult Details(int inventoryId)
        {
            ProductDetailsViewModel productDetailsViewModel = new ProductDetailsViewModel();
            productDetailsViewModel.Inventory = _outdoorPowerRepository.GetDealerInventory(inventoryId);
            productDetailsViewModel.Inventory.DealerInfo = _outdoorPowerRepository.GetDealer(productDetailsViewModel.Inventory.DealerId);

            return View(productDetailsViewModel);
        }
    }
}