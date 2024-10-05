using FoodDeliveryService.AdministrationContracts.Dtos;

namespace FoodDeliveryService.Administration.Contracts.Interfaces.IHandlers;

public interface IAdministrationCommandHandler
{
    Task<int> CreateNewMenuOption(MenuOptionDto option);

    Task<int> UpdateMenuOption(MenuOptionDto option, int menuOptionId);

    Task DeleteMenuOption(int menuOptionId);
    
    Task SwitchMenuOption(int menuOptionId, bool isActive);
}