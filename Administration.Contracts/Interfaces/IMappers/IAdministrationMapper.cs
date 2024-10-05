namespace FoodDeliveryService.Administration.Contracts.Interfaces.IMappers;

public interface IAdministrationMapper<TSource, TDestination>
{
    TDestination Map(TSource source);
    TSource Map(TDestination destination);
}