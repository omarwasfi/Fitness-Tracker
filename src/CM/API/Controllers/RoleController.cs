using System;
using System.Net;
using AutoMapper;
using CM.SharedWithClient;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using CM.Library.Queries.Roles;

namespace CM.API.Controllers
{
	[ApiController]
	[Route("[controller]")]
	[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme,Roles = "Administrator")]
	public class RoleController : ControllerBase
	{
		private IMediator _mediator { get; set; }
		private readonly IMapper _mapper;

        public RoleController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("GetRoles")]
        public async Task<ActionResult<List<RoleDataViewModel>>> GetRoles()
        {
            List<IdentityRole> identityRoles = await _mediator.Send(new GetAllRolesQuery());

            List<RoleDataViewModel> roleDataViewModels= _mapper.Map< List<RoleDataViewModel>>(identityRoles);


            return roleDataViewModels;
        }

    }
}

