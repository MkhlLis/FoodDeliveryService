using FoodDeliveryService.Administration.Contracts.Entities;
using FoodDeliveryService.Administration.Contracts.Interfaces.IRepositories;


namespace FoodDeliveryService.Administration.Repositories;

internal class AdministrationCommandRepository : IAdministrationCommandRepository
{
    public AdministrationCommandRepository()
    {
    }
    public MenuOptionEntity CreateNewMenuOption(MenuOptionEntity option)
    {
        // Заглушка.
        Thread.Sleep(TimeSpan.FromSeconds(5));
        return option;
    }

    public MenuOptionEntity UpdateMenuOption(MenuOptionEntity option)
    {
        // Заглушка.
        Thread.Sleep(TimeSpan.FromSeconds(5));
        return option;
    }

    public void DeleteMenuOption(int menuOptionId)
    {
        Thread.Sleep(TimeSpan.FromSeconds(5));
    }

    public void SwitchMenuOption(int menuOptionId, bool isActive)
    {
        Thread.Sleep(TimeSpan.FromSeconds(5));
    }
}