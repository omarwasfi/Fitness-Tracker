using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using CM.Library.DataModels;
using CM.Library.Queries.Person;
using CM.Library.Queries.Roles;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace CM.Library.Events.Roles
{
	public class AddCouchRoleCommandValidator : AbstractValidator<AddCouchRoleCommand>
	{
		private readonly IMediator _mediator;

        public AddCouchRoleCommandValidator(IMediator mediator)
        {
            _mediator = mediator;

			CascadeMode = CascadeMode.Stop;


			RuleFor(x => x.PersonId).NotEmpty().NotNull().WithMessage("The Person Id is Empty !");

			RuleFor(x => x).MustAsync(async (addCouchRoleCommand, cancellation) => {
				return await IsTheAuthorizedUserIsAdminstratorOrHR(addCouchRoleCommand.ClaimsPrincipal);
			}).WithMessage("You must be an Administrator or HR");

			RuleFor(x => x).MustAsync(async (addCouchRoleCommand, cancellation) => {
				return await IsNotThePersonHasCouchRole(addCouchRoleCommand.PersonId);
			}).WithMessage("The person already Has Couch role");
		}

		private async Task<bool> IsTheAuthorizedUserIsAdminstratorOrHR( ClaimsPrincipal claimsPrincipal)
		{
			PersonDataModel authorizedPerson = await _mediator.Send(new GetTheAuthorizedPersonQuery(claimsPrincipal));

			List<IdentityRole> roles = await _mediator.Send(new GetPersonRolesQuery(authorizedPerson.Id));

			if(roles.Find(x=>x.Id == "Administrator") != null)
            {
				return true;
            }
			else if(roles.Find(x => x.Id == "HR") != null)
            {
				return true;
            }
            else
            {
				return false;
            }

		}

		private async Task<bool> IsNotThePersonHasCouchRole(string personId)
		{
			List<IdentityRole> roles = await _mediator.Send(new GetPersonRolesQuery(personId));


			if (roles.Find(x => x.Id == "Couch") != null)
			{
				return false;
			}
			else
			{
				return true;
			}

		}

	}
}

