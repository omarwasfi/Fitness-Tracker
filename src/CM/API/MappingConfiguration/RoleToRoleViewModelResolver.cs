using System;
using System.Collections.Generic;
using AutoMapper;
using CM.Library.DataModels;
using CM.Library.Queries.Roles;
using CM.SharedWithClient;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace CM.API.MappingConfiguration
{
	public class RoleToRoleViewModelResolver : IValueResolver<PersonDataModel,PersonDataViewModel,List<RoleDataViewModel>>
	{
        private IMediator _mediator { get; set; }

        public RoleToRoleViewModelResolver(IMediator mediator)
        {
            _mediator = mediator;
        }

        public List<RoleDataViewModel> Resolve(PersonDataModel source, PersonDataViewModel destination, List<RoleDataViewModel> destMember, ResolutionContext context)
        {
            List<IdentityRole> identityRoles =  _mediator.Send(new GetPersonRolesQuery(source.Id)).Result;

            List<RoleDataViewModel> roleDataViewModels = new List<RoleDataViewModel>();

            foreach(IdentityRole identity in identityRoles)
            {
                roleDataViewModels.Add(new RoleDataViewModel() { Id = identity.Id, Name = identity.Name });
            }

            return roleDataViewModels;
        }
    }
}

