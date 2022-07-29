using System;
using AutoMapper;
using CM.Library.DataModels;
using CM.Library.DataModels.BusinessModels;
using CM.Library.DataModels.Chat;
using CM.Library.Queries.Picture;
using CM.SharedWithClient;
using MediatR;
using Microsoft.AspNetCore.Identity;


namespace CM.API.MappingConfiguration
{
	public class AutoMapperProfile : Profile
	{

		public AutoMapperProfile()
		{

			CreateMap<PersonDataModel, PersonDataViewModel>()
				.ForMember(p => p.Roles, opt => opt.MapFrom<RoleToRoleViewModelResolver>());

			CreateMap<IdentityRole, RoleDataViewModel>();


			CreateMap<PictureDataModel, PictureBase64DataViewModel>()
				.ForMember(p => p.Base64 ,opt => opt.MapFrom<PictureToBase64Resolver>());

			CreateMap<RoomDataModel, RoomDataViewModel>();

			CreateMap<MessageDataModel, MessageDataViewModel>();

			CreateMap<MessageContentDataModel, MessageContentDataViewModel>();

			CreateMap<ExerciseDataModel, ExerciseDataViewModel>();

			CreateMap<ExerciseActionDataModel,ExerciseActionDataViewModel>();

			CreateMap<ExercisePlanDataModel, ExercisePlanDataViewModel>();

			CreateMap<WorkoutDataModel, WorkoutDataViewModel>();
		}

		
	}

    
}

