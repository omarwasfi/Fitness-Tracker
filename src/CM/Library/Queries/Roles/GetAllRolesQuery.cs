using System;
using System.Collections.Generic;
using MediatR;
using Microsoft.AspNetCore.Identity;


namespace CM.Library.Queries.Roles
{
	public class GetAllRolesQuery : IRequest<List<IdentityRole>>
	{
		public GetAllRolesQuery()
		{
		}
	}
}

