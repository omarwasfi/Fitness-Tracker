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
using FluentValidation;
using CM.Library.DataModels;
using CM.Library.Events.Roles;
using CM.SharedWithClient.RequestViewModels;

namespace CM.API.Controllers
{
	[ApiController]
	[Route("[controller]")]
	[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme,Roles = "Administrator,HR,Couch")]
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
            try
            {
                List<IdentityRole> identityRoles = await _mediator.Send(new GetAllRolesQuery());

                List<RoleDataViewModel> roleDataViewModels = _mapper.Map<List<RoleDataViewModel>>(identityRoles);


                return Ok(roleDataViewModels);
            }
            catch (ValidationException v)
            {
                return ValidationProblem(v.Message);
            }
            catch
            {
                return BadRequest("Unrecognized error");

            }
        }

        [HttpPost]
        [Route("AddCouchRole")]
        public async Task<ActionResult<PersonDataViewModel>> AddCouchRole(AddRoleToPersonRequestDataViewModel addRoleToPersonRequestDataViewModel)
        {
            try
            {
                PersonDataModel person = await _mediator.Send(new AddCouchRoleCommand(addRoleToPersonRequestDataViewModel.PersonId, this.User));
                PersonDataViewModel personDataViewModel = _mapper.Map<PersonDataViewModel>(person);

                return personDataViewModel;
            }
            catch (ValidationException v)
            {
                return ValidationProblem(v.Message);
            }
            catch
            {
                return BadRequest("Unrecognized error");

            }
        }

        [HttpDelete]
        [Route("DeleteCouchRole")]
        public async Task<ActionResult<PersonDataViewModel>> DeleteCouchRole(string personId)
        {
            try
            {
                PersonDataModel person = await _mediator.Send(new DeleteCouchRoleCommand(personId, this.User));
                PersonDataViewModel personDataViewModel = _mapper.Map<PersonDataViewModel>(person);

                return personDataViewModel;
            }
            catch (ValidationException v)
            {
                return ValidationProblem(v.Message);
            }
            catch
            {
                return BadRequest("Unrecognized error");

            }
        }

        [HttpPost]
        [Route("AddMemberRole")]
        public async Task<ActionResult<PersonDataViewModel>> AddMemberRole(AddRoleToPersonRequestDataViewModel addRoleToPersonRequestDataViewModel)
        {
            try
            {
                PersonDataModel person = await _mediator.Send(new AddMemberRoleCommand(addRoleToPersonRequestDataViewModel.PersonId, this.User));
                PersonDataViewModel personDataViewModel = _mapper.Map<PersonDataViewModel>(person);

                return personDataViewModel;
            }
            catch (ValidationException v)
            {
                return ValidationProblem(v.Message);
            }
            catch
            {
                return BadRequest("Unrecognized error");

            }
        }

        [HttpDelete]
        [Route("DeleteMemberRole")]
        public async Task<ActionResult<PersonDataViewModel>> DeleteMemberRole(string personId)
        {
            try
            {
                PersonDataModel person = await _mediator.Send(new DeleteMemberRoleCommand(personId, this.User));
                PersonDataViewModel personDataViewModel = _mapper.Map<PersonDataViewModel>(person);

                return personDataViewModel;
            }
            catch (ValidationException v)
            {
                return ValidationProblem(v.Message);
            }
            catch
            {
                return BadRequest("Unrecognized error");

            }
        }

        [HttpPost]
        [Route("AddHRRole")]
        public async Task<ActionResult<PersonDataViewModel>> AddHRRole(AddRoleToPersonRequestDataViewModel addRoleToPersonRequestDataViewModel)
        {
            try
            {
                PersonDataModel person = await _mediator.Send(new AddHRRoleCommand(addRoleToPersonRequestDataViewModel.PersonId, this.User));
                PersonDataViewModel personDataViewModel = _mapper.Map<PersonDataViewModel>(person);

                return personDataViewModel;
            }
            catch (ValidationException v)
            {
                return ValidationProblem(v.Message);
            }
            catch
            {
                return BadRequest("Unrecognized error");

            }
        }

        [HttpDelete]
        [Route("DeleteHRRole")]
        public async Task<ActionResult<PersonDataViewModel>> DeleteHRRole(string personId)
        {
            try
            {
                PersonDataModel person = await _mediator.Send(new DeleteHRRoleCommand(personId, this.User));
                PersonDataViewModel personDataViewModel = _mapper.Map<PersonDataViewModel>(person);

                return personDataViewModel;
            }
            catch (ValidationException v)
            {
                return ValidationProblem(v.Message);
            }
            catch
            {
                return BadRequest("Unrecognized error");

            }
        }

    }
}

