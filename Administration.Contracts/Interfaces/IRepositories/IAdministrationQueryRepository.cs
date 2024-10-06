using FoodDeliveryService.Administration.Contracts.Entities;

namespace FoodDeliveryService.Administration.Contracts.Interfaces.IRepositories;

public interface IAdministrationQueryRepository
{
    Task<MenuOptionEntity> GetByOptionIdAsync(int id, CancellationToken cancellationToken);
    
    Task<IEnumerable<MenuOptionEntity>> GetAllAsync(PageFilter pageFilter, CancellationToken cancellationToken);
}