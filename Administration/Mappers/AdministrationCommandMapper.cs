using FoodDeliveryService.Administration.Contracts.Entities;
using FoodDeliveryService.Administration.Contracts.Interfaces.IMappers;
using FoodDeliveryService.AdministrationContracts.Dtos;

namespace FoodDeliveryService.Administration.Mappers;

internal class AdministrationCommandMapper : IAdministrationMapper<MenuOptionDto,MenuOptionEntity>
{
    public MenuOptionEntity Map(MenuOptionDto source)
    {
        return source != null
            ? new MenuOptionEntity
            {
                Id = source.Id,
                Description = source.Description,
                Name = source.Name,
                Price = source.Price,
                IsActive = true,
                IsDeleted = false,
                CreatedAt = DateTime.Now
            }
            : throw new ArgumentNullException(nameof(source));
    }

    public MenuOptionDto Map(MenuOptionEntity destination)
    {
        return destination != null
            ? new MenuOptionDto
            {
                Id = destination.Id,
                Description = destination.Description,
                Name = destination.Name,
                Price = destination.Price,
            }
            : throw new ArgumentNullException(nameof(destination));
    }
}