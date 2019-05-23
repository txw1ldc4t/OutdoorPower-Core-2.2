using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OutdoorPower.Models;
using OutdoorPower.ViewModels;

namespace OutdoorPower.Controllers
{
    public class HomeController : Controller
    {
        private readonly IOutdoorPowerRepository _outdoorPowerRepository;

        public HomeController(IOutdoorPowerRepository outdoorPowerRepository)
        {
            _outdoorPowerRepository = outdoorPowerRepository;
        }
        public IActionResult Index()
        {
            ViewBag.Title = "Welcome to Outdoor Power!";

            var homeIndexViewModel = new HomeIndexViewModel()
            {
                Title = "Welcome to Outdoor Power!",
                TypeList = _outdoorPowerRepository.GetInventoryTypes().Select(
                    pt => new SelectListItem
                    {
                        Value = pt.Id.ToString(),
                        Text = pt.Name
                    }).ToList(),
                MakeList = _outdoorPowerRepository.GetInventoryMakes().Select(
                    pt => new SelectListItem
                    {
                        Value = pt.Id.ToString(),
                        Text = pt.Name
                    })
            };

            homeIndexViewModel.TypeList[0].Selected = true;
            return View(homeIndexViewModel);
        }

        public IActionResult Products()
        {
            return View();
        }

        public IActionResult AboutUs()
        {
            return View();
        }

        public IActionResult Testimonials()
        {
            return View();
        }

        public IActionResult Search()
        {
            HomeSearchViewModel homeSearchViewModel = new HomeSearchViewModel()
            {
                EngineBrandList = _outdoorPowerRepository.GetEngineBrands().Select(
                pt => new SelectListItem
                {
                    Value = pt,
                    Text = pt
                }
                ).ToList(),
                MakeList = _outdoorPowerRepository.GetInventoryMakes().Select(
                pt => new SelectListItem
                {
                    Value = pt.Id.ToString(),
                    Text = pt.Name
                }).ToList(),
                TypeList = _outdoorPowerRepository.GetInventoryTypes().Select(
                    pt => new SelectListItem
                    {
                        Value = pt.Id.ToString(),
                        Text = pt.Name
                    }).ToList()
            };

            homeSearchViewModel.SearchResults = _outdoorPowerRepository.SearchInventory(homeSearchViewModel);

            homeSearchViewModel.NavStart = 1;
            homeSearchViewModel.NavEnd = homeSearchViewModel.TotalResults / homeSearchViewModel.ResultsPerPage;

            if (homeSearchViewModel.TotalResults % homeSearchViewModel.ResultsPerPage > 0)
                homeSearchViewModel.NavEnd += 1;

            // Since this is the first search, we can safely use a static "1" for the start nav,
            // and "5" for the end nav
            if (homeSearchViewModel.NavEnd > 7)
                homeSearchViewModel.NavEnd = 7;

            return View(homeSearchViewModel);
        }

        [HttpPost]
        public IActionResult Search(HomeSearchViewModel homeSearchViewModel)
        {
            homeSearchViewModel.TypeList = _outdoorPowerRepository.GetInventoryTypes().Select(
            pt => new SelectListItem
            {
                Value = pt.Id.ToString(),
                Text = pt.Name
            }).ToList();

            homeSearchViewModel.EngineBrandList = _outdoorPowerRepository.GetEngineBrands().Select(
                pt => new SelectListItem
                {
                    Value = pt,
                    Text = pt
                }
            ).ToList();

            homeSearchViewModel.MakeList = _outdoorPowerRepository.GetInventoryMakes().Select(
                pt => new SelectListItem
                {
                    Value = pt.Id.ToString(),
                    Text = pt.Name
                }).ToList();

            if(homeSearchViewModel.QMake > 0)
            {
                homeSearchViewModel.ModelList = _outdoorPowerRepository.GetInventoryModels(
                    typeId: homeSearchViewModel.QType,
                    inventoryMakeId: homeSearchViewModel.QMake
                ).Select(
                pt => new SelectListItem
                {
                    Value = pt.Id.ToString(),
                    Text = pt.Name
                }).ToList();
            }

            if (homeSearchViewModel.QModel > 0)
            {
                homeSearchViewModel.QModelOptionList = _outdoorPowerRepository.GetInventoryModelOptions(
                    inventoryModelId: homeSearchViewModel.QModel
                ).Select(
                pt => new SelectListItem
                {
                    Value = pt.Id.ToString(),
                    Text = pt.Name
                }).ToList();
            }

            homeSearchViewModel.SearchResults = _outdoorPowerRepository.SearchInventory(homeSearchViewModel);

            homeSearchViewModel.NavStart = homeSearchViewModel.PageNum;
            homeSearchViewModel.NavEnd = homeSearchViewModel.TotalResults / homeSearchViewModel.ResultsPerPage;

            if (homeSearchViewModel.TotalResults % homeSearchViewModel.ResultsPerPage > 0)
                homeSearchViewModel.NavEnd += 1;

            if (homeSearchViewModel.NavStart <= 7)
                homeSearchViewModel.NavStart = 1;
            else if (homeSearchViewModel.NavStart > 7)
                homeSearchViewModel.NavEnd -= 2;

            if (homeSearchViewModel.NavEnd > homeSearchViewModel.NavStart + 7)
                homeSearchViewModel.NavEnd = homeSearchViewModel.NavStart + 7;

            return View(homeSearchViewModel);
        }
    }
}