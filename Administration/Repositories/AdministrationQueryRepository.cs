using FoodDeliveryService.Administration.Contracts;
using FoodDeliveryService.Administration.Contracts.Entities;
using FoodDeliveryService.Administration.Contracts.Interfaces.IRepositories;

namespace FoodDeliveryService.Administration.Repositories;

public class AdministrationQueryRepository : IAdministrationQueryRepository
{
    public async Task<MenuOptionEntity> GetByOptionIdAsync(int id, CancellationToken cancellationToken)
    {
        await Task.Delay(TimeSpan.FromSeconds(5), cancellationToken);
        return default;
    }

    public async Task<IEnumerable<MenuOptionEntity>> GetAllAsync(PageFilter pageFilter, CancellationToken cancellationToken)
    {
        var result = new List<MenuOptionEntity>();
        await Task.Delay(TimeSpan.FromSeconds(5), cancellationToken);
        return result
            .Where(x => x.Name.ToLower().IndexOf(pageFilter.PartText.ToLower()) != -1)
            .Where(x => x.Price >= pageFilter.PriceMin && x.Price <= pageFilter.PriceMax)
            .Skip(pageFilter.PageSize * (pageFilter.PageNumber - 1))
            .Take(pageFilter.PageSize)
            .ToList();
    }
}