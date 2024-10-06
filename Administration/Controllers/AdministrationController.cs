using FoodDeliveryService.Administration.Contracts;
using FoodDeliveryService.Administration.Contracts.Interfaces.IHandlers;
using FoodDeliveryService.AdministrationContracts.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace FoodDeliveryService.Administration.Controllers;

[ApiController]
[Route("administration")]
public class AdministrationController : ControllerBase
{
    private readonly IAdministrationCommandHandler _commandHandler;
    private readonly IAdministrationQueryHandler _queryHandler;
    
    public AdministrationController(
        IAdministrationCommandHandler commandHandler,
        IAdministrationQueryHandler queryHandler)
    {
        _commandHandler = commandHandler ?? throw new ArgumentNullException(nameof(commandHandler));
        _queryHandler = queryHandler ?? throw new ArgumentNullException(nameof(queryHandler));
    }

    [HttpPost("create")]
    public ActionResult<int> CreateNewMenuOption([FromBody] MenuOptionDto option)
    {
        return _commandHandler.CreateNewMenuOption(option);
    }

    [HttpPut("update/{menuOptionId}")]
    public ActionResult<int> UpdateMenuOption([FromBody] MenuOptionDto option, [FromRoute] int menuOptionId)
    {
        return _commandHandler.UpdateMenuOption(option, menuOptionId);
    }

    [HttpDelete("delete/{menuOptionId}")]
    public IActionResult DeleteMenuOption([FromRoute] int menuOptionId)
    {
        try
        {
            _commandHandler.DeleteMenuOption(menuOptionId);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
         
        return Ok();
    }

    [HttpPut("switch/{menuOptionId}")]
    public IActionResult SwitchMenuOption([FromRoute] int menuOptionId, bool isActive)
    {
        try
        {
            _commandHandler.SwitchMenuOption(menuOptionId, isActive);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
         
        return Ok();
    }

    [HttpGet("get/{menuOptionId}")]
    public async Task<MenuOptionDto> GetByOptionIdAsync([FromRoute] int menuOptionId, CancellationToken cancellationToken)
    {
        return await _queryHandler.GetByOptionIdAsync(menuOptionId, cancellationToken);
    }

    [HttpPost("list")]
    public async Task<IEnumerable<MenuOptionDto>> GetAllAsync([FromBody] PageFilter pageFilter, CancellationToken cancellationToken)
    {
        return await _queryHandler.GetAllAsync(pageFilter, cancellationToken);
    }
}