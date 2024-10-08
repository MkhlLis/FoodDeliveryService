using FoodDeliveryService.Administration.Contracts.Entities;
using FoodDeliveryService.Administration.Contracts.Interfaces.IStores;
using FoodDeliveryService.AdministrationContracts.Dtos;

namespace FoodDeliveryService.Administration.Store;

public class InMemoryMenuOptionStore : IAdministrationStore
{
    private readonly List<MenuOptionEntity> _menuOption = new();
    
    public int Save(MenuOptionEntity menuOption)
    {
        _menuOption.Add(menuOption);
        return _menuOption.Count - 1 ;
    }

    public int Update(MenuOptionEntity menuOption)
    {
        if (_menuOption.Any(x => x.Id == menuOption.Id - 1))
        {
            throw new ArgumentException($"MenuOption with id {menuOption.Id} not found");
        }

        if (menuOption.Id != null)
        {
            _menuOption[(int)menuOption.Id - 1] = menuOption;
        }

        return (int)menuOption.Id;
    }

    public void Delete(int id)
    {
        _menuOption[id].IsDeleted = true;
    }

    public void Switch(int id, bool isActive)
    {
        _menuOption[id].IsActive = isActive;
    }

    public async Task<MenuOptionEntity> Get(int id)
    {
        await Task.Delay(TimeSpan.FromSeconds(5));
        return _menuOption.Find(x => x.Id == id)!;
    }

    public async Task<IEnumerable<MenuOptionEntity>> GetAll()
    {
        await Task.Delay(TimeSpan.FromSeconds(5));
        return _menuOption;
    }
}