﻿using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public abstract class RootConstroler : ControllerBase
    {
        protected readonly IMediator _mediator;

        public RootConstroler(IMediator mediator)
        {
            _mediator = mediator;
        }
    }
}
