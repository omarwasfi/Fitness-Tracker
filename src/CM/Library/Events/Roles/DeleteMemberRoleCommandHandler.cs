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
using System.Linq;
using System.Data.Entity;

namespace CM.Library.Events.Roles
{
	public class DeleteMemberRoleCommandHandler : IRequestHandler<DeleteMemberRoleCommand, PersonDataModel>
	{
        private readonly IMediator _mediator;

        private readonly CurrentStateDBContext _currentStateDBContext;



        public DeleteMemberRoleCommandHandler(IMediator mediator, CurrentStateDBContext currentStateDBContext)
        {
            _mediator = mediator;
            _currentStateDBContext = currentStateDBContext;
        }

        public async Task<PersonDataModel> Handle(DeleteMemberRoleCommand request, CancellationToken cancellationToken)
        {

            var userRoles = _currentStateDBContext.UserRoles.ToList();
            IdentityUserRole<string> identityUserRole =  userRoles.Find(x=>x.UserId == request.PersonId && x.RoleId == "Member");

             _currentStateDBContext.UserRoles.Remove(identityUserRole);
            await _currentStateDBContext.SaveChangesAsync();

            return await _mediator.Send(new GetPersonByIdQuery(request.PersonId));
        }

        
    }
}

