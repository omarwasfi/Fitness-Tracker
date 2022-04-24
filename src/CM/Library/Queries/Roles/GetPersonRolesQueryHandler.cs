using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

using MediatR;
using System.Threading.Tasks;
using System.Threading;
using CM.Library.DBContexts;
using System.Linq;

namespace CM.Library.Queries.Roles
{
	public class GetPersonRolesQueryHandler : IRequestHandler<GetPersonRolesQuery,List<IdentityRole>>
	{
        private readonly CurrentStateDBContext _currentStateDBContext;

        public GetPersonRolesQueryHandler(CurrentStateDBContext currentStateDBContext)
        {
            _currentStateDBContext = currentStateDBContext;
        }

       
        public async Task<List<IdentityRole>> Handle(GetPersonRolesQuery request, CancellationToken cancellationToken)
        {
            var userRoles = _currentStateDBContext.UserRoles.Where(x=>x.UserId == request.PersonId).ToList();

            List<string> rolesId = new List<string>();

            foreach(var userRole in userRoles)
            {
                rolesId.Add(userRole.RoleId);
            }

            List<IdentityRole> identityRoles = new List<IdentityRole>();

            foreach(var id in rolesId)
            {
                identityRoles.Add( await _currentStateDBContext.Roles.FindAsync(id));
            }

            return identityRoles;
        }
    }
}

