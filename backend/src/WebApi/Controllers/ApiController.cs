﻿using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
public abstract class ApiController : ControllerBase
{
    private IMediator? _mediator;

    protected IMediator Mediator
    {
        get
        {
            if (_mediator == null)
            {
                var result = HttpContext.RequestServices.GetService<IMediator>();

                _mediator = result ?? throw new Exception("Cannot instantiate the Mediator");
                return result;
            }

            return _mediator;
        }
    }
}
