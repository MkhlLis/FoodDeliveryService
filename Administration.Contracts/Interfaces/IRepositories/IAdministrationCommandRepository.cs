using FoodDeliveryService.Administration.Contracts.Entities;

namespace FoodDeliveryService.Administration.Contracts.Interfaces.IRepositories;

public interface IAdministrationCommandRepository
{
    Task<MenuOptionEntity> CreateNewMenuOption(MenuOptionEntity option);
    Task<MenuOptionEntity> UpdateMenuOption(MenuOptionEntity option);
    Task DeleteMenuOption(int menuOptionId);
    Task SwitchMenuOption(int menuOptionId, bool isActive);
}