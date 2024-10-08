using FoodDeliveryService.Administration.Contracts.Entities;

namespace FoodDeliveryService.Administration.Contracts.Interfaces.IStores;

public interface IAdministrationStore
{
    int Save(MenuOptionEntity menuOption);
    int Update(MenuOptionEntity menuOption);
    void Delete(int id);
    void Switch(int id, bool isActive);
    Task<MenuOptionEntity> Get(int id);
    Task<IEnumerable<MenuOptionEntity>> GetAll();
}