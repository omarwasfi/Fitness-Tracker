using System;
using System.Reflection.Metadata.Ecma335;

namespace CM.SharedWithClient.RequestViewModels
{
	public class PersonUpdateProfileRequestViewModel
	{
        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? Gender { get; set; }

        public string? PhoneNumber { get; set; }
    }
}

