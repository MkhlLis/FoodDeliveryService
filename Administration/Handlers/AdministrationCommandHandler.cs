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
    
    public async Task<int> CreateNewMenuOption(MenuOptionDto option)
    {
        var result = await _repository.CreateNewMenuOption(_menuOptionMapper.Map(option));
        return result.Id ?? default;
    }

    public async Task<int> UpdateMenuOption(MenuOptionDto option, int menuOptionId)
    {
        option.Id = menuOptionId;
        var result = await _repository.UpdateMenuOption(_menuOptionMapper.Map(option));
        return result.Id ?? default;
    }

    public async Task DeleteMenuOption(int menuOptionId)
    {
        await _repository.DeleteMenuOption(menuOptionId);
    }

    public async Task SwitchMenuOption(int menuOptionId, bool isActive)
    {
        await _repository.SwitchMenuOption(menuOptionId, isActive);
    }
}