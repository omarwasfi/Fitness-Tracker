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
	public class AddCouchRoleCommandHandler : IRequestHandler<AddCouchRoleCommand, PersonDataModel>
	{
        private readonly IMediator _mediator;

        private readonly CurrentStateDBContext _currentStateDBContext;



        public AddCouchRoleCommandHandler(IMediator mediator, CurrentStateDBContext currentStateDBContext)
        {
            _mediator = mediator;
            _currentStateDBContext = currentStateDBContext;
        }

        public async Task<PersonDataModel> Handle(AddCouchRoleCommand request, CancellationToken cancellationToken)
        {


            IdentityUserRole<string> identityUserRole = new() { RoleId = "Couch", UserId = request.PersonId };

            await _currentStateDBContext.UserRoles.AddAsync(identityUserRole);
            await _currentStateDBContext.SaveChangesAsync();

            return await _mediator.Send(new GetPersonByIdQuery(request.PersonId));
        }
    }
}

