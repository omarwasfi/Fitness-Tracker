using System;
using System.Security.Claims;
using CM.Library.DataModels;
using MediatR;

namespace CM.Library.Events.Person
{
	public class UpdateProfileCommand : IRequest<PersonDataModel>
	{
        public ClaimsPrincipal ClaimsPrincipal { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Gender { get; set; }

        public string PhoneNumber { get; set; }


        public UpdateProfileCommand(ClaimsPrincipal claimsPrincipal, string firstName, string lastName, string gender, string phoneNumber)
        {
            ClaimsPrincipal = claimsPrincipal;
            FirstName = firstName;
            LastName = lastName;
            Gender = gender;
            PhoneNumber = phoneNumber;

        }
    }
}

