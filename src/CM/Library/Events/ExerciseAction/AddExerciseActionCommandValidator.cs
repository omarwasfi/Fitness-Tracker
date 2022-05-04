using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using CM.Library.DataModels;
using CM.Library.Queries.Person;
using CM.Library.Queries.Roles;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace CM.Library.Events.ExerciseAction;

public class AddExerciseActionCommandValidator : AbstractValidator<AddExerciseActionCommand>
{
    private readonly IMediator _mediator;

    public AddExerciseActionCommandValidator(IMediator mediator)
    {
        _mediator = mediator;

        CascadeMode = CascadeMode.Stop;
        
        RuleFor(x => x).MustAsync(async (AddExerciseActionCommand, cancellation) => {
            return await IsTheAuthorizedUserIsAdminstratorOrHROrCouch(AddExerciseActionCommand.ClaimsPrincipal);
        }).WithMessage("You must be an Administrator or HR or couch"); 
        
        RuleFor(x => x)
            .MustAsync(async (AddExerciseActionCommand, cancellation) => {
            return await IsAddingToValid(AddExerciseActionCommand.AddingTo);
        }).WithMessage("The adding to is not valid !");
        
        RuleFor(x => x)
            .MustAsync(async (AddExerciseActionCommand, cancellation) => {
                return await IsWorkoutIdExercisePlanIdValid(AddExerciseActionCommand.WorkoutId,AddExerciseActionCommand.ExercisePlanId);
            }).WithMessage("The WorkoutId or ExercisePlanId is not valid !");
        
        RuleFor(x => x.ExerciseId)
            .NotEmpty().NotNull()
            .WithMessage("The ExerciseId is null or empty !");
    }
    
    private async Task<bool> IsTheAuthorizedUserIsAdminstratorOrHROrCouch( ClaimsPrincipal claimsPrincipal)
    {
        PersonDataModel authorizedPerson = await _mediator.Send(new GetTheAuthorizedPersonQuery(claimsPrincipal));

        List<IdentityRole> roles = await _mediator.Send(new GetPersonRolesQuery(authorizedPerson.Id));

        if(roles.Find(x=>x.Id == "Administrator") != null)
        {
            return true;
        }
        else if(roles.Find(x => x.Id == "HR") != null)
        {
            return true;
        }
        else if (roles.Find(x => x.Id == "Couch") != null)
        {
            return true;
        }
        else
        {
            return false;
        }

    }
    
    private async Task<bool> IsAddingToValid( string addingTo)
    {
        if (String.IsNullOrEmpty(addingTo) == false && String.IsNullOrWhiteSpace(addingTo) == false)
        {
            if (addingTo == "Workout")
            {
                return true;
            }
            else if (addingTo == "ExercisePlan")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        return false;

    }
    
    private async Task<bool> IsWorkoutIdExercisePlanIdValid( string workoutId , string exercisePlanId)
    {
        if (String.IsNullOrEmpty(workoutId) == false ||  String.IsNullOrEmpty(exercisePlanId) == false)
        {
            return true;
        }

        return false;

    }
    
    
}