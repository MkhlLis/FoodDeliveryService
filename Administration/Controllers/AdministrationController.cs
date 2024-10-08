using FoodDeliveryService.Administration.Contracts;
using FoodDeliveryService.Administration.Contracts.Interfaces.IHandlers;
using FoodDeliveryService.AdministrationContracts.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace FoodDeliveryService.Administration.Controllers;

/// <summary>
/// Администрирование меню (ресторанной карты)
/// </summary>
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

    /// <summary>
    /// Добавление нового блюдо в меню.
    /// </summary>
    /// <param name="option">Блюдо меню.</param>
    /// <returns>Идентификатор добавленого блюда меню.</returns>
    [HttpPost("create")]
    public ActionResult<int> CreateNewMenuOption([FromBody] MenuOptionDto option)
    {
        return _commandHandler.CreateNewMenuOption(option);
    }

    /// <summary>
    /// Редактирование блюда в меню.
    /// </summary>
    /// <param name="option">Блюдо меню.</param>
    /// <param name="menuOptionId">Идентификатор блюда меню.</param>
    /// <returns>Идентификатор добавленого блюда меню.</returns>
    [HttpPut("update/{menuOptionId}")]
    public ActionResult<int> UpdateMenuOption([FromBody] MenuOptionDto option, [FromRoute] int menuOptionId)
    {
        return _commandHandler.UpdateMenuOption(option, menuOptionId);
    }

    /// <summary>
    /// Удаление блюда из меню.
    /// </summary>
    /// <param name="menuOptionId">Идентификатор блюда меню.</param>
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

    /// <summary>
    /// Переключение доступности блюда из меню.
    /// </summary>
    /// <param name="menuOptionId">Идентификатор блюда меню.</param>
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

    /// <summary>
    /// Запрос блюда меню по идентификатору.
    /// </summary>
    /// <param name="menuOptionId">Блюдо меню.</param>
    [HttpGet("get/{menuOptionId}")]
    public async Task<MenuOptionDto> GetByOptionIdAsync([FromRoute] int menuOptionId, CancellationToken cancellationToken)
    {
        return await _queryHandler.GetByOptionIdAsync(menuOptionId, cancellationToken);
    }

    /// <summary>
    /// Запрос всех доступных блюд в меню с фильтрацией.
    /// </summary>
    /// <param name="menuOptionId">Меню.</param>
    [HttpPost("list")]
    public async Task<IEnumerable<MenuOptionDto>> GetAllAsync([FromBody] PageFilter pageFilter, CancellationToken cancellationToken)
    {
        return await _queryHandler.GetAllAsync(pageFilter, cancellationToken);
    }
}