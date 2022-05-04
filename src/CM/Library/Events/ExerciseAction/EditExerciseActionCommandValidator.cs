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

public class EditExerciseActionCommandValidator : AbstractValidator<EditExerciseActionCommand>
{
    private readonly IMediator _mediator;

    public EditExerciseActionCommandValidator(IMediator mediator)
    {
        _mediator = mediator;

        CascadeMode = CascadeMode.Stop;
        
        RuleFor(x => x).MustAsync(async (EditExerciseActionCommand, cancellation) => {
            return await IsTheAuthorizedUserIsAdminstratorOrHROrCouch(EditExerciseActionCommand.ClaimsPrincipal);
        }).WithMessage("You must be an Administrator or HR or couch"); 
        
        RuleFor(x => x.ExerciseActionId)
            .NotEmpty().NotNull()
            .WithMessage("The ExerciseActionId is null or empty !");
        
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
    
    
    
}