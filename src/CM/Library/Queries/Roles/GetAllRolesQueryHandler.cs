using System;
using Microsoft.AspNetCore.Identity;

using MediatR;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using CM.Library.DBContexts;
using System.Data.Entity;
using System.Linq;

namespace CM.Library.Queries.Roles
{
	public class GetAllRolesQueryHandler : IRequestHandler<GetAllRolesQuery,List<IdentityRole>>
	{
        private readonly CurrentStateDBContext _currentStateDBContext;

        public GetAllRolesQueryHandler(CurrentStateDBContext currentStateDBContext)
        {
            _currentStateDBContext = currentStateDBContext;
        }

    

        public async Task<List<IdentityRole>> Handle(GetAllRolesQuery request, CancellationToken cancellationToken)
        {
            return _currentStateDBContext.Roles.ToList();
        }
    }
}

