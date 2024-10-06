using FoodDeliveryService.Administration.Contracts;
using FoodDeliveryService.Administration.Contracts.Entities;
using FoodDeliveryService.Administration.Contracts.Interfaces.IHandlers;
using FoodDeliveryService.Administration.Contracts.Interfaces.IMappers;
using FoodDeliveryService.Administration.Contracts.Interfaces.IRepositories;
using FoodDeliveryService.AdministrationContracts.Dtos;

namespace FoodDeliveryService.Administration.Handlers;

public class AdministrationQueryHandler : IAdministrationQueryHandler
{
    private readonly IAdministrationQueryRepository _queryRepository;
    private readonly IAdministrationMapper<MenuOptionDto, MenuOptionEntity> _menuOptionMapper;
    
    public AdministrationQueryHandler(
        IAdministrationQueryRepository queryRepository,
        IAdministrationMapper<MenuOptionDto, MenuOptionEntity> menuOptionMapper)
    {
        _queryRepository = queryRepository ?? throw new ArgumentNullException(nameof(queryRepository));
        _menuOptionMapper = menuOptionMapper ?? throw new ArgumentNullException(nameof(menuOptionMapper));
    }
    
    public async Task<MenuOptionDto> GetByOptionIdAsync(int id, CancellationToken cancellationToken)
    {
        var result = await _queryRepository.GetByOptionIdAsync(id, cancellationToken);
        return _menuOptionMapper.Map(result);
    }

    public async Task<IEnumerable<MenuOptionDto>> GetAllAsync(PageFilter pageFilter, CancellationToken cancellationToken)
    {
        var result = await _queryRepository.GetAllAsync(pageFilter, cancellationToken);
        return result.Select(x => _menuOptionMapper.Map(x)).ToList();
    }
}