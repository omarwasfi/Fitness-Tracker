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
	public class AddHRRoleCommandHandler : IRequestHandler<AddHRRoleCommand, PersonDataModel>
	{
        private readonly IMediator _mediator;

        private readonly CurrentStateDBContext _currentStateDBContext;



        public AddHRRoleCommandHandler(IMediator mediator, CurrentStateDBContext currentStateDBContext)
        {
            _mediator = mediator;
            _currentStateDBContext = currentStateDBContext;
        }

        public async Task<PersonDataModel> Handle(AddHRRoleCommand request, CancellationToken cancellationToken)
        {


            IdentityUserRole<string> identityUserRole = new() { RoleId = "HR", UserId = request.PersonId };

            await _currentStateDBContext.UserRoles.AddAsync(identityUserRole);
            await _currentStateDBContext.SaveChangesAsync();

            return await _mediator.Send(new GetPersonByIdQuery(request.PersonId));
        }
    }
}

