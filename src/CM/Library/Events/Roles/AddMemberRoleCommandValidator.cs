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
	public class AddMemberRoleCommandValidator : AbstractValidator<AddMemberRoleCommand>
	{
		private readonly IMediator _mediator;

        public AddMemberRoleCommandValidator(IMediator mediator)
        {
            _mediator = mediator;

			CascadeMode = CascadeMode.Stop;

			RuleFor(x => x.PersonId).NotEmpty().NotNull().WithMessage("The Person Id is Empty !");

			RuleFor(x => x).MustAsync(async (addCouchRoleCommand, cancellation) => {
				return await IsTheAuthorizedUserIsAdminstratorOrHR(addCouchRoleCommand.ClaimsPrincipal);
			}).WithMessage("You must be an Administrator or HR OR Couch");

			RuleFor(x => x).MustAsync(async (addCouchRoleCommand, cancellation) => {
				return await IsNotThePersonHasMemberRole(addCouchRoleCommand.PersonId);
			}).WithMessage("The person already Has member role");
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
			else if (roles.Find(x => x.Id == "Couch") != null)
			{
				return true;
			}
			else
            {
				return false;
            }

		}

		private async Task<bool> IsNotThePersonHasMemberRole(string personId)
		{
			List<IdentityRole> roles = await _mediator.Send(new GetPersonRolesQuery(personId));


			if (roles.Find(x => x.Id == "Member") != null)
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

