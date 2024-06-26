﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MotoXShare.Application.Interactor.Interface.User;
using MotoXShare.Domain.Dto.User;

namespace MotoXShare.API.Controllers;

[AllowAnonymous]
[ApiController]
[Route("api/v1/[controller]")]
public class UserController(ISaveUserInteractor saveUserInteractor) : ControllerBase
{
    private readonly ISaveUserInteractor _saveUserInteractor = saveUserInteractor;

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create(SaveUserRequestDto param)
    {
        var result = await _saveUserInteractor.Execute(param);

        return Created($"{Request.Path}/{result}", string.Empty);
    }
}