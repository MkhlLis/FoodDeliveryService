using FoodDeliveryService.AdministrationContracts.Dtos;
namespace FoodDeliveryService.Administration.Contracts.Interfaces.IHandlers;

public interface IAdministrationQueryHandler
{
    Task<MenuOptionDto> GetByOptionIdAsync(int id, CancellationToken cancellationToken);
    
    Task<IEnumerable<MenuOptionDto>> GetAllAsync(PageFilter pageFilter, CancellationToken cancellationToken);
}