using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using OutdoorPower.Models;
using OutdoorPower.Models.Metrics;
using OutdoorPower.ViewModels;

namespace OutdoorPower.Controllers
{
    [Authorize]
    public class ManageController : Controller
    {
        private readonly IOutdoorPowerRepository _outdoorPowerRepository;
        private readonly IMetricRepository _metricRepository;
        private readonly IUserRepository _userRepository;
        private readonly IHostingEnvironment _environment;
        private readonly ILogger<ManageController> _logger;

        public ManageController(
            IOutdoorPowerRepository outdoorPowerRepository,
            IMetricRepository metricRepository,
            IUserRepository userRepository,
            IHostingEnvironment environment,
            ILogger<ManageController> logger)
        {
            _outdoorPowerRepository = outdoorPowerRepository;
            _metricRepository = metricRepository;
            _userRepository = userRepository;
            _environment = environment;
            _logger = logger;
        }

        public IActionResult Index()
        {
            int dealerId = int.Parse(User.Claims.FirstOrDefault(x => x.Type == "DealerId").Value);

            ManageIndexViewModel manageIndexViewModel = new ManageIndexViewModel()
            {
                DealerId = dealerId,
                DealerEmployees = _outdoorPowerRepository.GetDealerEmployees(dealerId),
                MonthToDateMetrics = _metricRepository.GetMonthToDateMetrics(dealerId),
                YearToDateMetrics = _metricRepository.GetYearToDateMetrics(dealerId),
                UnitsSoldMetrics = _metricRepository.GetUnitsSoldMetrics(dealerId),
                MonthlyRevenue = _metricRepository.GetMonthlyRevenue(dealerId),
                YearlyRevenue = _metricRepository.GetYearlyRevenue(dealerId)
            };

            manageIndexViewModel.SearchResults = _outdoorPowerRepository.SearchInventory(manageIndexViewModel);

            if (manageIndexViewModel.SearchResults != null)
            {
                IEnumerable<int> ids = manageIndexViewModel.SearchResults.Select(c => c.Id).Distinct();
                List<Customer> customers = _metricRepository.GetCustomers(ids);
                List<SalesInfoModalViewModel> salesInfo = _metricRepository.GetSalesInfo(ids);

                foreach (DealerInventory result in manageIndexViewModel.SearchResults)
                {
                    result.Customers = customers.Where(c => c.OPInventoryId == result.Id).ToList();
                    result.SalesInfo = salesInfo.Where(c => c.Id == result.Id).ToList();
                }

                
            }

            return View(manageIndexViewModel);
        }

        [HttpPost]
        public IActionResult Index(ManageIndexViewModel manageIndexViewModel)
        {
            return View(manageIndexViewModel);
        }

        // The insertion/update into the metrics table is handled on the db side 
        // via the triggers: [TRG_DealerInventories_Insert] & [TRG_DealerInventories_Update].
        // These triggers are associated with the DealerInventories table.
        [Authorize(Policy = "edit.inventory")]
        public IActionResult Inventory(int? id)
        {
            ManageAddInventoryViewModel manageAddInventoryViewModel;

            if (!id.HasValue)
            {
                manageAddInventoryViewModel = new ManageAddInventoryViewModel()
                {
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
                    }).ToList()
                };

                manageAddInventoryViewModel.MakeList.Add(new SelectListItem
                {
                    Value = "-2",
                    Text = "Other"
                });

                manageAddInventoryViewModel.TypeList[0].Selected = true;
            }
            else
            {
                DealerInventory dealerInventory = _outdoorPowerRepository.GetDealerInventory((int)id);

                // Verify the inventory belongs to same dealer.
                string dealerId = User.Claims.FirstOrDefault(x => x.Type == "DealerId").Value;
                if (dealerInventory.DealerId != Int32.Parse(dealerId))
                {
                    return RedirectPermanent("/Identity/Account/AccessDenied");
                }

                manageAddInventoryViewModel = Mapper.Map<ManageAddInventoryViewModel>(dealerInventory);

                manageAddInventoryViewModel.TypeList = _outdoorPowerRepository.GetInventoryTypes().Select(
                pt => new SelectListItem
                {
                    Value = pt.Id.ToString(),
                    Text = pt.Name
                }).ToList();

                manageAddInventoryViewModel.MakeList = _outdoorPowerRepository.GetInventoryMakes().Select(
                pt => new SelectListItem
                {
                    Value = pt.Id.ToString(),
                    Text = pt.Name
                }).ToList();

                manageAddInventoryViewModel.MakeList.Add(new SelectListItem
                {
                    Value = "-2",
                    Text = "Other"
                });

                if (manageAddInventoryViewModel.QInventoryMakeId > 0 && manageAddInventoryViewModel.QInventoryTypeId > 0)
                {
                    manageAddInventoryViewModel.ModelList = _outdoorPowerRepository.GetInventoryModels(
                        (int)manageAddInventoryViewModel.QInventoryMakeId,
                        manageAddInventoryViewModel.QInventoryTypeId
                    ).Select(
                        pt => new SelectListItem
                        {
                            Value = pt.Id.ToString(),
                            Text = pt.Name
                        }
                    ).ToList();

                    manageAddInventoryViewModel.ModelList.Add(new SelectListItem
                    {
                        Value = "-2",
                        Text = "Other"
                    });

                    if (manageAddInventoryViewModel.QInventoryModelId > 0)
                    {
                        manageAddInventoryViewModel.ModelOptionList = _outdoorPowerRepository.GetInventoryModelOptions(
                            (int)manageAddInventoryViewModel.QInventoryModelId
                        ).Select(
                            pt => new SelectListItem
                            {
                                Value = pt.Id.ToString(),
                                Text = pt.Name
                            }
                        ).ToList();

                        manageAddInventoryViewModel.ModelOptionList.Add(new SelectListItem
                        {
                            Value = "-2",
                            Text = "Other"
                        });
                    }

                    if (!String.IsNullOrEmpty(manageAddInventoryViewModel.EngineBrand))
                    {
                        manageAddInventoryViewModel.EngineHorsePowerList = _outdoorPowerRepository.GetEngineHorsePower(
                            manageAddInventoryViewModel.EngineBrand
                        ).Select(
                            pt => new SelectListItem
                            {
                                Value = pt,
                                Text = pt
                            }
                        ).ToList();
                    }
                }

                manageAddInventoryViewModel.ImageList = _outdoorPowerRepository.GetDealerInventoryImages((int)id);
            }

            manageAddInventoryViewModel.YearList = new List<SelectListItem>();

            int year = DateTime.UtcNow.Year;

            do
            {
                manageAddInventoryViewModel.YearList.Add(
                    new SelectListItem(){
                        Text = year.ToString(),
                        Value = year.ToString()
                    }
                );
                year -= 1;
            } while (year > 1995);

            manageAddInventoryViewModel.EngineBrandList = _outdoorPowerRepository.GetEngineBrands().Select(
                pt => new SelectListItem
                {
                    Value = pt,
                    Text = pt
                }
            ).ToList();

            return View(manageAddInventoryViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Inventory(ManageAddInventoryViewModel manageAddInventoryViewModel)
        {
            manageAddInventoryViewModel.DatePosted = DateTime.Now;

            if (ModelState.IsValid)
            {
                DealerInventory dealerInventory = Mapper.Map<DealerInventory>(manageAddInventoryViewModel);
                string dealerId = User.Claims.FirstOrDefault(x => x.Type == "DealerId").Value;
                dealerInventory.DealerId = Int32.Parse(dealerId);

                if (dealerInventory.ZipCode == null)
                {
                    Dealer dealer = _userRepository.GetDealer(dealerInventory.DealerId);
                    dealerInventory.ZipCode = dealer.Zip;
                }

                _outdoorPowerRepository.AddDealerInventory(dealerInventory);

                if (!await _outdoorPowerRepository.SaveChangesAsync())
                {
                    ModelState.AddModelError("Save Failed", "Unable to save to the dealer inventory table.");
                }
                else
                {
                    // Add Entry to Metrics Inventory Table
                    Models.Metrics.Inventory metricInventory = Mapper.Map<Models.Metrics.Inventory>(manageAddInventoryViewModel);
                    if (!await _metricRepository.SaveChangesAsync())
                    {
                        ModelState.AddModelError("Metric Save Failed", "Unable to save information to the metrics database.");
                    }

                    if (manageAddInventoryViewModel.Images != null)
                    {
                        foreach (var Image in manageAddInventoryViewModel.Images)
                        {
                            if (Image != null && Image.Length > 0)
                            {
                                var uploadPath = Path.Combine(
                                    _environment.WebRootPath,
                                    "images\\dealer\\" + dealerId.ToString() + "\\inventory\\" + dealerInventory.Id.ToString()
                                );

                                string webPath = Path.Combine(
                                   "/images/dealer/" + dealerId.ToString() + "/inventory/" + dealerInventory.Id.ToString()
                                );

                                if (!Directory.Exists(uploadPath))
                                    Directory.CreateDirectory(uploadPath);

                                if (Image.Length > 0  && !System.IO.File.Exists(Path.Combine(uploadPath, Image.FileName)))
                                {
                                    var fileName = ContentDispositionHeaderValue.Parse
                                        (Image.ContentDisposition).FileName.Trim('"');

                                    System.Console.WriteLine(fileName);
                                    using (var fileStream = new FileStream(Path.Combine(uploadPath, Image.FileName), FileMode.Create))
                                    {
                                        await Image.CopyToAsync(fileStream);
                                    }

                                    DealerInventoryImage dealerInventoryImage = new DealerInventoryImage();
                                    dealerInventoryImage.Path = uploadPath + "\\" + fileName;
                                    dealerInventoryImage.WebPath = webPath + "/" + fileName;
                                    dealerInventoryImage.DealerInventoryId = dealerInventory.Id;
                                    _outdoorPowerRepository.AddDealerInventoryImages(dealerInventoryImage);
                                }
                            }
                        }
                    }

                    if (!await _outdoorPowerRepository.SaveChangesAsync())
                    {
                        ModelState.AddModelError("Save Failed", "Unable to save to the images.");
                    }

                    return LocalRedirect("/manage/inventory?id=" + dealerInventory.Id);
                }
            } 

            manageAddInventoryViewModel.TypeList = _outdoorPowerRepository.GetInventoryTypes().Select(
            pt => new SelectListItem
            {
                Value = pt.Id.ToString(),
                Text = pt.Name
            }).ToList();

            manageAddInventoryViewModel.MakeList = _outdoorPowerRepository.GetInventoryMakes().Select(
            pt => new SelectListItem
            {
                Value = pt.Id.ToString(),
                Text = pt.Name
            }).ToList();

            manageAddInventoryViewModel.MakeList.Add(new SelectListItem
            {
                Value = "-2",
                Text = "Other"
            });

            if(manageAddInventoryViewModel.QInventoryMakeId > 0 && manageAddInventoryViewModel.QInventoryTypeId > 0)
            {
                manageAddInventoryViewModel.ModelList = _outdoorPowerRepository.GetInventoryModels(
                    (int)manageAddInventoryViewModel.QInventoryMakeId,
                    manageAddInventoryViewModel.QInventoryTypeId
                ).Select(
                    pt => new SelectListItem
                    {
                        Value = pt.Id.ToString(),
                        Text = pt.Name
                    }).ToList();

                manageAddInventoryViewModel.ModelList.Add(new SelectListItem
                {
                    Value = "-2",
                    Text = "Other"
                });

                if (manageAddInventoryViewModel.QInventoryModelId > 0)
                {
                    manageAddInventoryViewModel.ModelOptionList = _outdoorPowerRepository.GetInventoryModelOptions((int)manageAddInventoryViewModel.QInventoryModelId).Select(
                    pt => new SelectListItem
                    {
                        Value = pt.Id.ToString(),
                        Text = pt.Name
                    }).ToList();

                    manageAddInventoryViewModel.ModelOptionList.Add(new SelectListItem
                    {
                        Value = "-2",
                        Text = "Other"
                    });
                }
            } else
            {
                manageAddInventoryViewModel.ModelList = new List<SelectListItem>();
                manageAddInventoryViewModel.ModelOptionList = new List<SelectListItem>();
            }

            manageAddInventoryViewModel.YearList = new List<SelectListItem>();

            int year = DateTime.UtcNow.Year;

            do
            {
                manageAddInventoryViewModel.YearList.Add(
                    new SelectListItem()
                    {
                        Text = year.ToString(),
                        Value = year.ToString()
                    }
                );
                year -= 1;
            } while (year > 1995);

            manageAddInventoryViewModel.EngineBrandList = _outdoorPowerRepository.GetEngineBrands().Select(
                pt => new SelectListItem
                {
                    Value = pt,
                    Text = pt
                }
            ).ToList();

            if (!String.IsNullOrEmpty(manageAddInventoryViewModel.EngineBrand))
            {
                manageAddInventoryViewModel.EngineHorsePowerList = _outdoorPowerRepository.GetEngineHorsePower(
                    manageAddInventoryViewModel.EngineBrand
                ).Select(
                    pt => new SelectListItem
                    {
                        Value = pt,
                        Text = pt
                    }
                ).ToList();
            } else
            {
                manageAddInventoryViewModel.EngineHorsePowerList = new List<SelectListItem>();
            }

            return View(manageAddInventoryViewModel);
        }

        [Authorize(Policy = "edit.users")]
        public IActionResult Users()
        {
            UsersViewModel usersViewModel = new UsersViewModel();
            string dealerId = User.Claims.FirstOrDefault(x => x.Type == "DealerId").Value;

            usersViewModel.Users = _userRepository.GetUsers(Int32.Parse(dealerId));

            return View(usersViewModel);
        }

        [Authorize(Policy = "edit.users")]
        [HttpPost]
        public IActionResult Users(UsersViewModel usersViewModel)
        {
            string dealerId = User.Claims.FirstOrDefault(x => x.Type == "DealerId").Value;

            usersViewModel.Users = _userRepository.GetUsers(Int32.Parse(dealerId));

            return View(usersViewModel);
        }

        [HttpDelete]
        public async Task<IActionResult> InventoryDelete(int id)
        {
            string dealerId = User.Claims.FirstOrDefault(x => x.Type == "DealerId").Value;
            var imagePath = Path.Combine(
                _environment.WebRootPath,
                "images\\dealer\\" + dealerId.ToString() + "\\inventory\\" + dealerId
            );

            try
            {
                _outdoorPowerRepository.DeleteDealerInventory(id);

                if (await _outdoorPowerRepository.SaveChangesAsync()) { 
                    // Remove all images
                    if (Directory.Exists(imagePath))
                    {
                        DirectoryInfo d = new DirectoryInfo(imagePath);

                        foreach (FileInfo file in d.GetFiles())
                        {
                            file.Delete();
                        }
                    }

                    return Ok(id);
                }
                else
                {
                    _logger.LogError($"Unable to save changes to database for inventory: {id}");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred when deleting inventory (id: {id},  Error Message: {ex}");
            }

            return BadRequest("Failed to delete the inventory.");
        }

        [HttpDelete]
        public async Task<IActionResult> ImageDelete(int imageId)
        {
            try
            {
                string fileName = _outdoorPowerRepository.DeleteDealerInventoryImage(imageId);

                if (await _outdoorPowerRepository.SaveChangesAsync())
                {
                    
                    // Remove all images
                    if (System.IO.File.Exists(fileName))
                    {
                        // Delete the image file.
                        System.IO.File.Delete(fileName);
                    }

                    return Ok(imageId);
                }
            } catch (Exception ex)
            {
                _logger.LogError($"An error occurred when deleting image (id: {imageId},  Error Message: {ex}");
            }
            return BadRequest("Failed to delete the image.");
        }

        [HttpPost]
        public async Task<IActionResult> SalesInfo(SalesInfoViewModel salesInfo)
        {
            try
            {
                Customer customer = Mapper.Map<Customer>(salesInfo);
                Models.Metrics.Inventory inventory = Mapper.Map<Models.Metrics.Inventory>(salesInfo);


                Models.Metrics.Inventory original = await _metricRepository.UpdateSalesInfo(inventory);

                customer.InventoryId = original.Id;
                customer.OPInventoryId = original.OPInventoryId;

                _metricRepository.AddCustomer(customer);

                if (!await _metricRepository.SaveChangesAsync())
                {
                    return BadRequest();
                }

                    return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred when saving sales info (Error Message: {ex}");
            }

            return BadRequest();
        }
    }
}