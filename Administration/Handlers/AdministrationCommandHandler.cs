using FoodDeliveryService.Administration.Contracts.Entities;
using FoodDeliveryService.Administration.Contracts.Interfaces.IHandlers;
using FoodDeliveryService.Administration.Contracts.Interfaces.IMappers;
using FoodDeliveryService.Administration.Contracts.Interfaces.IRepositories;
using FoodDeliveryService.AdministrationContracts.Dtos;

namespace FoodDeliveryService.Administration.Handlers;

internal class AdministrationCommandHandler : IAdministrationCommandHandler
{
    private readonly IAdministrationCommandRepository _repository;
    private readonly IAdministrationMapper<MenuOptionDto, MenuOptionEntity> _menuOptionMapper;
    
    public AdministrationCommandHandler(
        IAdministrationCommandRepository repository,
        IAdministrationMapper<MenuOptionDto, MenuOptionEntity> menuOptionMapper)
    {
        _menuOptionMapper = menuOptionMapper;
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
    }
    
    public int CreateNewMenuOption(MenuOptionDto option)
    {
        var result = _repository.CreateNewMenuOption(_menuOptionMapper.Map(option));
        return result.Id ?? default;
    }

    public int UpdateMenuOption(MenuOptionDto option, int menuOptionId)
    {
        option.Id = menuOptionId;
        var result = _repository.UpdateMenuOption(_menuOptionMapper.Map(option));
        return result.Id ?? default;
    }

    public void DeleteMenuOption(int menuOptionId)
    {
        _repository.DeleteMenuOption(menuOptionId);
    }

    public void SwitchMenuOption(int menuOptionId, bool isActive)
    {
        _repository.SwitchMenuOption(menuOptionId, isActive);
    }
}