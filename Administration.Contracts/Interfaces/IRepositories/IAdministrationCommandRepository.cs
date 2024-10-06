using FoodDeliveryService.Administration.Contracts.Entities;

namespace FoodDeliveryService.Administration.Contracts.Interfaces.IRepositories;

public interface IAdministrationCommandRepository
{
    MenuOptionEntity CreateNewMenuOption(MenuOptionEntity option);
    MenuOptionEntity UpdateMenuOption(MenuOptionEntity option);
    void DeleteMenuOption(int menuOptionId);
    void SwitchMenuOption(int menuOptionId, bool isActive);
}