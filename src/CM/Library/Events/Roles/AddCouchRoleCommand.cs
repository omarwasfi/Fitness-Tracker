using System;
using System.Security.Claims;
using CM.Library.DataModels;
using MediatR;

namespace CM.Library.Events.Roles
{
	public class AddCouchRoleCommand : IRequest<PersonDataModel>
	{
        public string PersonId { get; set; }

		public ClaimsPrincipal ClaimsPrincipal { get; set; }


        public AddCouchRoleCommand(string personId, ClaimsPrincipal claimsPrincipal)
        {
            PersonId = personId;
            ClaimsPrincipal = claimsPrincipal;
        }
    }
}

