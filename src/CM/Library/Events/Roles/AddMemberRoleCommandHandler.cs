using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CM.Library.DataModels;
using CM.Library.DBContexts;
using CM.Library.Queries.Roles;
using MediatR;
using Microsoft.AspNetCore.Identity;
using CM.Library.Queries.Person;

namespace CM.Library.Events.Roles
{
	public class AddMemberRoleCommandHandler : IRequestHandler<AddMemberRoleCommand, PersonDataModel>
	{
        private readonly IMediator _mediator;

        private readonly CurrentStateDBContext _currentStateDBContext;



        public AddMemberRoleCommandHandler(IMediator mediator, CurrentStateDBContext currentStateDBContext)
        {
            _mediator = mediator;
            _currentStateDBContext = currentStateDBContext;
        }

        public async Task<PersonDataModel> Handle(AddMemberRoleCommand request, CancellationToken cancellationToken)
        {


            IdentityUserRole<string> identityUserRole = new() { RoleId = "Member", UserId = request.PersonId };

            await _currentStateDBContext.UserRoles.AddAsync(identityUserRole);
            await _currentStateDBContext.SaveChangesAsync();

            return await _mediator.Send(new GetPersonByIdQuery(request.PersonId));
        }
    }
}

