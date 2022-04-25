using System;
using System.Security.Claims;
using CM.Library.DataModels;
using MediatR;

namespace CM.Library.Events.Roles
{
	public class DeleteHRRoleCommand : IRequest<PersonDataModel>
	{
        public string PersonId { get; set; }

		public ClaimsPrincipal ClaimsPrincipal { get; set; }


        public DeleteHRRoleCommand(string personId, ClaimsPrincipal claimsPrincipal)
        {
            PersonId = personId;
            ClaimsPrincipal = claimsPrincipal;
        }
    }
}

