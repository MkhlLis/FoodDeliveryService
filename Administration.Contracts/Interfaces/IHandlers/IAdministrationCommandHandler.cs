using FoodDeliveryService.AdministrationContracts.Dtos;

namespace FoodDeliveryService.Administration.Contracts.Interfaces.IHandlers;

public interface IAdministrationCommandHandler
{
    int CreateNewMenuOption(MenuOptionDto option);

    int UpdateMenuOption(MenuOptionDto option, int menuOptionId);

    void DeleteMenuOption(int menuOptionId);
    
    void SwitchMenuOption(int menuOptionId, bool isActive);
}