using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

using MediatR;

namespace CM.Library.Queries.Roles
{
	public class GetPersonRolesQuery : IRequest<List<IdentityRole>>
	{
        public string PersonId { get; set; }

        public GetPersonRolesQuery(string personId)
        {
            PersonId = personId;
        }

        
	}
}

