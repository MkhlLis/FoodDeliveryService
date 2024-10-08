using FoodDeliveryService.Administration.Contracts.Entities;
using FoodDeliveryService.Administration.Contracts.Interfaces.IRepositories;
using FoodDeliveryService.Administration.Contracts.Interfaces.IStores;


namespace FoodDeliveryService.Administration.Repositories;

internal class AdministrationCommandRepository : IAdministrationCommandRepository
{
    private readonly IAdministrationStore _administrationStore;
    
    public AdministrationCommandRepository(IAdministrationStore administrationStore)
    {
        _administrationStore = administrationStore;
    }
    public MenuOptionEntity CreateNewMenuOption(MenuOptionEntity option)
    {
        // Заглушка.
        _administrationStore.Save(option);
        return option;
    }

    public MenuOptionEntity UpdateMenuOption(MenuOptionEntity option)
    {
        // Заглушка.
        _administrationStore.Update(option);
        return option;
    }

    public void DeleteMenuOption(int menuOptionId)
    {
        _administrationStore.Delete(menuOptionId);
        Thread.Sleep(TimeSpan.FromSeconds(5));
    }

    public void SwitchMenuOption(int menuOptionId, bool isActive)
    {
        _administrationStore.Switch(menuOptionId, isActive);
        Thread.Sleep(TimeSpan.FromSeconds(5));
    }
}