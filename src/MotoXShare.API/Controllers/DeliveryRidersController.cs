﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MotoXShare.Application.Interactor.Interface.DeliveryRider;
using MotoXShare.Domain.Dto.DeliveryRider;

namespace MotoXShare.API.Controllers;

[AllowAnonymous]
[ApiController]
[Route("api/[controller]")]
public class DeliveryRidersController(
    ISaveDeliveryRiderInteractor saveDeliveryRiderInteractor,
    IUpdateDeliveryRiderInteractor updateDeliveryRiderInteractor
) : ControllerBase
{
    private readonly ISaveDeliveryRiderInteractor _saveDeliveryRiderInteractor = saveDeliveryRiderInteractor;
    private readonly IUpdateDeliveryRiderInteractor _updateDeliveryRiderInteractor = updateDeliveryRiderInteractor;

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create([FromBody] SaveDeliveryRiderRequestDto param)
    {
        var result = await _saveDeliveryRiderInteractor.Execute(param);

        return Created($"{Request.Path}/{result}", new { });
    }

    [HttpPatch("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateCnhImage(Guid id, IFormFile cnhImage)
    {
        var result = await _updateDeliveryRiderInteractor.Execute(new(id, cnhImage));

        return result ? NoContent() : NotFound();
    }
}