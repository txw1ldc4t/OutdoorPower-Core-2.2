using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using OutdoorPower.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace OutdoorPower.Models
{
    public class OutdoorPowerRepository : IOutdoorPowerRepository
    {
        private readonly OutdoorPowerContext _appDbContext;
        private readonly ILogger<OutdoorPowerRepository> _logger;

        public OutdoorPowerRepository(
            OutdoorPowerContext appDbContext,
            ILogger<OutdoorPowerRepository> logger
        )
        {
            _appDbContext = appDbContext;
            _logger = logger;
        }

        public void AddDealer(Dealer dealer)
        {
            _appDbContext.Add(dealer);
        }

        public void AddDealerEmployee(DealerEmployee dealerEmployee)
        {
            _appDbContext.Add(dealerEmployee);
        }

        public void AddDealerInventory(DealerInventory dealerInventory)
        {
            if (dealerInventory.QInventoryMakeId <= 0)
                dealerInventory.QInventoryMakeId = null;

            if (dealerInventory.QInventoryModelId <= 0)
                dealerInventory.QInventoryModelId = null;

            if (dealerInventory.QInventoryModelOptionId <= 0)
                dealerInventory.QInventoryModelOptionId = null;

            if (dealerInventory.Id > 0)
            {
                _appDbContext.DealerInventories.Attach(dealerInventory);
                var entry = _appDbContext.Entry(dealerInventory);
                entry.State = EntityState.Modified;
            }
            else
            {
                _appDbContext.Add(dealerInventory);
            }
        }

        public void AddDealerInventoryImages(DealerInventoryImage dealerInventoryImage)
        {
            if (dealerInventoryImage.Id > 0)
            {
                _appDbContext.DealerInventoryImages.Attach(dealerInventoryImage);
                var entry = _appDbContext.Entry(dealerInventoryImage);
                entry.State = EntityState.Modified;
            }
            else
            {
                _appDbContext.Add(dealerInventoryImage);
            }
        }

        public void DeleteDealerInventory(int dealerInventoryId)
        {
            DeleteDealerInventoryImages(dealerInventoryId);

            DealerInventory inventory = GetDealerInventory(dealerInventoryId);
            _appDbContext
                .DealerInventories.Remove(inventory);
            _appDbContext.Entry(inventory).State = EntityState.Deleted;
        }

        public string DeleteDealerInventoryImage(int dealerInventoryImageId)
        {
            string path = _appDbContext.DealerInventoryImages
                .Where(c => c.Id == dealerInventoryImageId)
                .Select(c => c.Path)
                .FirstOrDefault();

            // This is needed in case there are multiple references to the same 
            // file in the db.  
            IEnumerable<DealerInventoryImage> imageList = _appDbContext
                .DealerInventoryImages
                .Where(c => c.Path == path);

            foreach(DealerInventoryImage image in imageList)
            {
                _appDbContext
                .DealerInventoryImages.Remove(image);
                _appDbContext.Entry(image).State = EntityState.Deleted;
            }

            return path;
        }

        public void DeleteDealerInventoryImages(int dealerInventoryId)
        {
            List<DealerInventoryImage> dealerInventoryImages = GetDealerInventoryImages(dealerInventoryId);

            foreach(DealerInventoryImage image in dealerInventoryImages)
            {
                _appDbContext.
                    DealerInventoryImages.Remove(image);
                _appDbContext.Entry(image).State = EntityState.Deleted;
            }
        }

        public Dealer GetDealer(Dealer dealer)
        {
            return _appDbContext.Dealers.Where(d => dealer.Name.ToUpper() == d.Name.ToUpper()
                && d.City.ToUpper() == dealer.City.ToUpper()
                && d.State.ToUpper() == dealer.State.ToUpper()).FirstOrDefault();
        }

        public Dealer GetDealer(int dealerId)
        {
            return _appDbContext.Dealers.Where(d => d.Id == dealerId).FirstOrDefault();
        }

        public IList<DealerEmployee> GetDealerEmployees(int dealerId)
        {
            return _appDbContext.DealerEmployees.Where(d => d.DealerId == dealerId).OrderBy(c => c.LastName).ThenBy(c => c.FirstName).ToList();
        }

        public IEnumerable<DealerInventory> GetAllDealerInventory()
        {
            return _appDbContext.DealerInventories;
        }

        public DealerInventory GetDealerInventory(int dealerInventoryId)
        {
            DealerInventory inventory = _appDbContext.DealerInventories.FirstOrDefault(p => p.Id == dealerInventoryId);

            inventory.Images = GetDealerInventoryImages(inventory.Id);

            if (!String.IsNullOrEmpty(inventory.QInventoryMakeOther))
            {
                inventory.QInventoryMakeId = -2;
                inventory.QInventoryModelId = -2;
                inventory.QInventoryModelOptionId = -2;
            }
            else if (inventory.QInventoryMakeId.HasValue)
            {
                inventory.Make = GetInventoryMake((int)inventory.QInventoryMakeId);

                if (!String.IsNullOrEmpty(inventory.QInventoryModelOther))
                {
                    inventory.QInventoryModelId = -2;
                    inventory.QInventoryModelOptionId = -2;
                }
                else if (inventory.QInventoryModelId.HasValue)
                {
                    inventory.Model = GetInventoryModel((int)inventory.QInventoryModelId);

                    if (!String.IsNullOrEmpty(inventory.QInventoryModelOptionOther))
                    {
                        inventory.QInventoryModelOptionId = -2;
                    }
                    else if (inventory.QInventoryModelOptionId.HasValue)
                    {
                        inventory.ModelOption = GetInventoryModelOption((int)inventory.QInventoryModelOptionId);
                    }
                }
            }

            return inventory;
        }

        public List<DealerInventoryImage> GetDealerInventoryImages(int dealerInventoryId)
        {
            return _appDbContext.DealerInventoryImages.Where(i => i.DealerInventoryId == dealerInventoryId).ToList();
        }

        public IEnumerable<string> GetEngineBrands()
        {
            return _appDbContext.Engines.Select(m => m.Brand).Distinct().ToList();
        }

        public IEnumerable<string> GetEngineHorsePower(string brand)
        {
            return _appDbContext.Engines.Where(c => c.Brand == brand).Select(m => m.Power).Distinct().ToList();
        }


        public QInventoryMake GetInventoryMake(int Id)
        {
            return _appDbContext.QInventoryMakes.FirstOrDefault(p => p.Id == Id);
        }

        public IEnumerable<QInventoryMake> GetInventoryMakes()
        {
            return _appDbContext.QInventoryMakes.OrderBy(p => p.Name);
        }

        public IEnumerable<QInventoryMake> GetInventoryMakes(int inventoryTypeId)
        {
            throw new NotImplementedException();
        }

        public QInventoryModelOption GetInventoryModelOption(int Id)
        {
            return _appDbContext.QInventoryModelOptions.FirstOrDefault(p => p.Id == Id);
        }

        public IEnumerable<QInventoryModelOption> GetInventoryModelOptions(int inventoryModelId)
        {
            return _appDbContext.QInventoryModelOptions.Where(p => p.QInventoryModelId == inventoryModelId).OrderBy(x => x.Name).OrderBy(p => p.Name);
        }

        public QInventoryModel GetInventoryModel(int Id)
        {
            return _appDbContext.QInventoryModels.FirstOrDefault(p => p.Id == Id);
        }

        public IEnumerable<QInventoryModel> GetInventoryModels(int inventoryMakeId, int typeId)
        {
            return _appDbContext.QInventoryModels.Where(p => p.QInventoryMakeId == inventoryMakeId && p.TypeId == typeId).OrderBy(p => p.Name);
        }

        public QInventoryType GetInventoryType(int Id)
        {
            return _appDbContext.QInventoryTypes.FirstOrDefault(p => p.Id == Id);
        }

        public IEnumerable<QInventoryType> GetInventoryTypes()
        {
            return _appDbContext.QInventoryTypes.OrderBy(p => p.Name);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _appDbContext.SaveChangesAsync()) > 0;
        }

        private SqlParameter[] createParameters(SearchViewModel searchViewModel)
        {
            SqlParameter zipCodeParameter = new SqlParameter
            {
                ParameterName = "@ZIP_CODE",
                SqlDbType = SqlDbType.VarChar,
                Direction = System.Data.ParameterDirection.Input,
                Value = (searchViewModel.ZipCode == null) ? (object)DBNull.Value : searchViewModel.ZipCode
            };
            SqlParameter radiusParameter = new SqlParameter
            {
                ParameterName = "@RADIUS",
                SqlDbType = SqlDbType.Int,
                Direction = System.Data.ParameterDirection.Input,
                Value = (searchViewModel.QZipCodeRadius == null) ? (object)DBNull.Value : searchViewModel.QZipCodeRadius
            };
            SqlParameter typeParameter = new SqlParameter
            {
                ParameterName = "@TYPE",
                SqlDbType = SqlDbType.Int,
                Direction = System.Data.ParameterDirection.Input,
                Value = searchViewModel.QType
            };
            SqlParameter makeParameter = new SqlParameter
            {
                ParameterName = "@MAKE",
                SqlDbType = SqlDbType.Int,
                Direction = System.Data.ParameterDirection.Input,
                Value = searchViewModel.QMake
            };
            SqlParameter makeOtherParameter = new SqlParameter
            {
                ParameterName = "@MAKE_OTHER",
                SqlDbType = SqlDbType.VarChar,
                Direction = System.Data.ParameterDirection.Input,
                Value = (searchViewModel.QMakeOther == null) ? (object)DBNull.Value : searchViewModel.QMakeOther
            };
            SqlParameter modelParameter = new SqlParameter
            {
                ParameterName = "@MODEL",
                SqlDbType = SqlDbType.Int,
                Direction = System.Data.ParameterDirection.Input,
                Value = (searchViewModel.QModel == null) ? (object)DBNull.Value : searchViewModel.QModel
            };
            SqlParameter modelOtherParameter = new SqlParameter
            {
                ParameterName = "@MODEL_OTHER",
                SqlDbType = SqlDbType.VarChar,
                Direction = System.Data.ParameterDirection.Input,
                Value = (searchViewModel.QModelOther == null) ? (object)DBNull.Value : searchViewModel.QModelOther
            };
            SqlParameter trimParameter = new SqlParameter
            {
                ParameterName = "@TRIM",
                SqlDbType = SqlDbType.Int,
                Direction = System.Data.ParameterDirection.Input,
                Value = (searchViewModel.QModelOption == null) ? (object)DBNull.Value : searchViewModel.QModelOption
            };
            SqlParameter trimOtherParameter = new SqlParameter
            {
                ParameterName = "@TRIM_OTHER",
                SqlDbType = SqlDbType.VarChar,
                Direction = System.Data.ParameterDirection.Input,
                Value = (searchViewModel.QModelOptionOther == null) ? (object)DBNull.Value : searchViewModel.QModelOptionOther
            };
            SqlParameter dealerIdParameter = new SqlParameter
            {
                ParameterName = "@DEALERID",
                SqlDbType = SqlDbType.Int,
                Direction = System.Data.ParameterDirection.Input,
                Value = (searchViewModel.DealerId == null) ? (object)DBNull.Value : searchViewModel.DealerId
            };
            SqlParameter engineBrandParameter = new SqlParameter
            {
                ParameterName = "@ENGINE_BRAND",
                SqlDbType = SqlDbType.VarChar,
                Direction = System.Data.ParameterDirection.Input,
                Value = (searchViewModel.EngineBrand == null) ? (object)DBNull.Value : searchViewModel.EngineBrand
            };
            SqlParameter horsePowerMaxParameter = new SqlParameter
            {
                ParameterName = "@HORSE_POWER_MAX",
                SqlDbType = SqlDbType.SmallInt,
                Direction = System.Data.ParameterDirection.Input,
                Value = (searchViewModel.HorsePowerMax == null) ? (object)DBNull.Value : searchViewModel.HorsePowerMax
            };
            SqlParameter horsePowerMinParameter = new SqlParameter
            {
                ParameterName = "@HORSE_POWER_MIN",
                SqlDbType = SqlDbType.SmallInt,
                Direction = System.Data.ParameterDirection.Input,
                Value = (searchViewModel.HorsePowerMin == null) ? (object)DBNull.Value : searchViewModel.HorsePowerMin
            };
            SqlParameter minYearParameter = new SqlParameter
            {
                ParameterName = "@MIN_YEAR",
                SqlDbType = SqlDbType.SmallInt,
                Direction = System.Data.ParameterDirection.Input,
                Value = (searchViewModel.MinYear == null) ? (object)DBNull.Value : searchViewModel.MinYear
            };
            SqlParameter maxYearParameter = new SqlParameter
            {
                ParameterName = "@MAX_YEAR",
                SqlDbType = SqlDbType.SmallInt,
                Direction = System.Data.ParameterDirection.Input,
                Value = (searchViewModel.MaxYear == null) ? (object)DBNull.Value : searchViewModel.MaxYear
            };
            SqlParameter minPriceParameter = new SqlParameter
            {
                ParameterName = "@MIN_PRICE",
                SqlDbType = SqlDbType.Decimal,
                Direction = System.Data.ParameterDirection.Input,
                Value = (searchViewModel.MinPrice == null) ? (object)DBNull.Value : searchViewModel.MinPrice
            };
            SqlParameter maxPriceParameter = new SqlParameter
            {
                ParameterName = "@MAX_PRICE",
                SqlDbType = SqlDbType.Decimal,
                Direction = System.Data.ParameterDirection.Input,
                Value = (searchViewModel.MaxPrice == null) ? (object)DBNull.Value : searchViewModel.MaxPrice
            };
            SqlParameter minHoursParameter = new SqlParameter
            {
                ParameterName = "@MIN_HOURS",
                SqlDbType = SqlDbType.Int,
                Direction = System.Data.ParameterDirection.Input,
                Value = (searchViewModel.MinHours == null) ? (object)DBNull.Value : searchViewModel.MinHours
            };
            SqlParameter maxHoursParameter = new SqlParameter
            {
                ParameterName = "@MAX_HOURS",
                SqlDbType = SqlDbType.Int,
                Direction = System.Data.ParameterDirection.Input,
                Value = (searchViewModel.MaxHours == null) ? (object)DBNull.Value : searchViewModel.MaxHours
            };
            SqlParameter isSoldParameter = new SqlParameter
            {
                ParameterName = "@ISSOLD",
                SqlDbType = SqlDbType.Bit,
                Direction = System.Data.ParameterDirection.Input,
                Value = (searchViewModel.IsSold == null) ? (object)DBNull.Value : searchViewModel.IsSold
            };
            SqlParameter keywordsParameter = new SqlParameter
            {
                ParameterName = "@KEYWORDS",
                SqlDbType = SqlDbType.VarChar,
                Direction = System.Data.ParameterDirection.Input,
                Value = (searchViewModel.KeyWords == null) ? (object)DBNull.Value : searchViewModel.KeyWords
            };
            SqlParameter orderByParameter = new SqlParameter
            {
                ParameterName = "@ORDER_BY",
                SqlDbType = SqlDbType.VarChar,
                Direction = System.Data.ParameterDirection.Input,
                Value = (searchViewModel.OrderBy == null) ? (object)DBNull.Value : searchViewModel.OrderBy
            };
            SqlParameter ascendingParameter = new SqlParameter
            {
                ParameterName = "@ASCENDING",
                SqlDbType = SqlDbType.VarChar,
                Direction = System.Data.ParameterDirection.Input,
                Value = (searchViewModel.Ascending == null) ? (object)DBNull.Value : searchViewModel.Ascending
            };
            SqlParameter resultsPerPageParameter = new SqlParameter
            {
                ParameterName = "@RESULTS_PER_PAGE",
                SqlDbType = SqlDbType.SmallInt,
                Direction = System.Data.ParameterDirection.Input,
                Value = searchViewModel.ResultsPerPage
            };
            SqlParameter pageNumParameter = new SqlParameter
            {
                ParameterName = "@PAGE_NUM",
                SqlDbType = SqlDbType.SmallInt,
                Direction = System.Data.ParameterDirection.Input,
                Value = searchViewModel.PageNum
            };
            SqlParameter totalResultsParameter = new SqlParameter
            {
                ParameterName = "@TOTAL_RESULTS",
                SqlDbType = SqlDbType.Int,
                Direction = System.Data.ParameterDirection.Output
            };

            var sqlParams = new[]{
                zipCodeParameter,
                radiusParameter,
                typeParameter,
                makeParameter,
                makeOtherParameter,
                modelParameter,
                modelOtherParameter,
                trimParameter,
                trimOtherParameter,
                dealerIdParameter,
                engineBrandParameter,
                horsePowerMaxParameter,
                horsePowerMinParameter,
                minYearParameter,
                maxYearParameter,
                minPriceParameter,
                maxPriceParameter,
                minHoursParameter,
                maxHoursParameter,
                isSoldParameter,
                keywordsParameter,
                orderByParameter,
                ascendingParameter,
                resultsPerPageParameter,
                pageNumParameter,
                totalResultsParameter
            };

            return sqlParams;
        }

        public IList<DealerInventory> SearchInventory(SearchViewModel searchViewModel)
        {
            string query = "SP_INVENTORY_SEARCH @ZIP_CODE, @RADIUS, @TYPE, @MAKE, @MAKE_OTHER, @MODEL, @MODEL_OTHER, @TRIM, @TRIM_OTHER, @DEALERID, @ENGINE_BRAND, @HORSE_POWER_MAX, @HORSE_POWER_MIN, @MIN_YEAR, @MAX_YEAR, @MIN_PRICE, @MAX_PRICE, @MIN_HOURS, @MAX_HOURS, @ISSOLD, @KEYWORDS, @ORDER_BY, @ASCENDING, @RESULTS_PER_PAGE, @PAGE_NUM, @TOTAL_RESULTS OUT";
            IList<DealerInventory> inventory;

            try
            {
                var sqlParams = createParameters(searchViewModel);
                inventory = _appDbContext.DealerInventories.FromSql(query, sqlParams).ToList();
                searchViewModel.TotalResults = (int)sqlParams[25].Value;
                try
                {
                    foreach (DealerInventory temp in inventory)
                    {
                        if (temp.QInventoryMakeId.HasValue)
                            temp.Make = GetInventoryMake((int)temp.QInventoryMakeId);

                        if (temp.QInventoryModelId.HasValue)
                            temp.Model = GetInventoryModel((int)temp.QInventoryModelId);

                        if (temp.QInventoryModelOptionId.HasValue)
                            temp.ModelOption = GetInventoryModelOption((int)temp.QInventoryModelOptionId);

                        temp.Images = GetDealerInventoryImages(temp.Id);
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError($"Failed in retrieving images for searched inventory: {ex}");
                }

                return inventory;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed while getting page results: {ex}");
            }

            return null;
        }
    }
}
