using FoodDeliveryService.Administration.Contracts.Interfaces.IHandlers;
using FoodDeliveryService.AdministrationContracts.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace FoodDeliveryService.Administration.Controllers;

[ApiController]
[Route("administration")]
public class AdministrationCommandController : ControllerBase
{
    private readonly IAdministrationCommandHandler _commandHandler;
    
    public AdministrationCommandController(IAdministrationCommandHandler commandHandler)
    {
        _commandHandler = commandHandler ?? throw new ArgumentNullException(nameof(commandHandler));
    }

    [HttpPost("create")]
    public async Task<int> CreateNewMenuOption([FromBody] MenuOptionDto option)
    {
        return await _commandHandler.CreateNewMenuOption(option);
    }

    [HttpPut("update/{menuOptionId}")]
    public async Task<int> UpdateMenuOption([FromBody] MenuOptionDto option, [FromRoute] int menuOptionId)
    {
        return await _commandHandler.UpdateMenuOption(option, menuOptionId);
    }

    [HttpDelete("delete/{menuOptionId}")]
    public async Task DeleteMenuOption([FromRoute] int menuOptionId)
    {
         await _commandHandler.DeleteMenuOption(menuOptionId);
         Ok();
    }

    [HttpPut("switch/{menuOptionId}")]
    public async Task SwitchMenuOption([FromRoute] int menuOptionId, bool isActive)
    {
        await _commandHandler.SwitchMenuOption(menuOptionId, isActive);
        Ok();
    }
}