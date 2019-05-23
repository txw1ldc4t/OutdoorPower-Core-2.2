using OutdoorPower.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OutdoorPower.Models
{
    public interface IOutdoorPowerRepository
    {
        void AddDealer(Dealer dealer);
        void AddDealerEmployee(DealerEmployee dealerEmployee);
        void AddDealerInventory(DealerInventory dealerInventory);
        void AddDealerInventoryImages(DealerInventoryImage dealerInventoryImage);
        void DeleteDealerInventory(int dealerInventoryId);
        string DeleteDealerInventoryImage(int dealerInventoryImageId);
        void DeleteDealerInventoryImages(int dealerInventoryId);
        IEnumerable<DealerInventory> GetAllDealerInventory();
        Dealer GetDealer(int dealerId);
        Dealer GetDealer(Dealer dealer);
        IList<DealerEmployee> GetDealerEmployees(int dealerId);
        DealerInventory GetDealerInventory(int dealerInventoryId);
        List<DealerInventoryImage> GetDealerInventoryImages(int dealerInventoryId);
        IEnumerable<string> GetEngineBrands();
        IEnumerable<string> GetEngineHorsePower(string brand);
        QInventoryType GetInventoryType(int Id);
        IEnumerable<QInventoryType> GetInventoryTypes();
        QInventoryMake GetInventoryMake(int Id);
        IEnumerable<QInventoryMake> GetInventoryMakes();
        IEnumerable<QInventoryMake> GetInventoryMakes(int inventoryTypeId);
        QInventoryModel GetInventoryModel(int Id);
        IEnumerable<QInventoryModel> GetInventoryModels(int inventoryMakeId, int typeId);
        QInventoryModelOption GetInventoryModelOption(int Id);
        IEnumerable<QInventoryModelOption> GetInventoryModelOptions(int inventoryModelId);
        Task<bool> SaveChangesAsync();
        IList<DealerInventory> SearchInventory(SearchViewModel searchViewModel);
    }
}
