using FoodDeliveryService.Administration.Contracts.Entities;
using FoodDeliveryService.Administration.Contracts.Interfaces.IRepositories;


namespace FoodDeliveryService.Administration.Repositories;

internal class AdministrationCommandRepository : IAdministrationCommandRepository
{
    public AdministrationCommandRepository()
    {
    }
    public async Task<MenuOptionEntity> CreateNewMenuOption(MenuOptionEntity option)
    {
        // Заглушка.
        await Task.Delay(TimeSpan.FromSeconds(5));
        return option;
    }

    public async Task<MenuOptionEntity> UpdateMenuOption(MenuOptionEntity option)
    {
        // Заглушка.
        await Task.Delay(TimeSpan.FromSeconds(5));
        return option;
    }

    public async Task DeleteMenuOption(int menuOptionId)
    {
        await Task.Delay(TimeSpan.FromSeconds(5));
    }

    public async Task SwitchMenuOption(int menuOptionId, bool isActive)
    {
        await Task.Delay(TimeSpan.FromSeconds(5));
    }
}