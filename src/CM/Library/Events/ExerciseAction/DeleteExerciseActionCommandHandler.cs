using System.Threading;
using System.Threading.Tasks;
using CM.Library.DataModels.BusinessModels;
using CM.Library.DBContexts;
using CM.Library.Queries.Exercise;
using CM.Library.Queries.ExerciseAction;
using CM.Library.Queries.ExercisePlan;
using CM.Library.Queries.Workout;
using MediatR;

namespace CM.Library.Events.ExerciseAction;

public class DeleteExerciseActionCommandHandler : IRequestHandler<DeleteExerciseActionCommand>
{
    private readonly IMediator _mediator;

    private readonly CurrentStateDBContext _currentStateDBContext;
    
    public DeleteExerciseActionCommandHandler(IMediator mediator, CurrentStateDBContext currentStateDbContext)
    {
        _mediator = mediator;
        _currentStateDBContext = currentStateDbContext;
    }
    
    
    public async Task<Unit> Handle(DeleteExerciseActionCommand request, CancellationToken cancellationToken)
    {
        ExerciseActionDataModel exerciseActionDataModel = await _mediator.Send(new GetExerciseActionByIdQuery(request.ExerciseActionId));
        

        
        if (request.DeletingFrom == "Workout")
        {
            
            WorkoutDataModel workout = await _mediator.Send(new GetWorkoutByIdQuery(request.WorkoutId));
            workout.ExerciseActions.Remove(exerciseActionDataModel);
            
            await _currentStateDBContext.SaveChangesAsync();
        }

        if (request.DeletingFrom == "ExercisePlan")
        {
            ExercisePlanDataModel exercisePlan = await _mediator.Send(new GetExercisePlanByIdQuery(request.ExercisePlanId));
            exercisePlan.ExerciseActions.Remove(exerciseActionDataModel);
            
            await _currentStateDBContext.SaveChangesAsync();
        }

        _currentStateDBContext.Remove(exerciseActionDataModel);

        return Unit.Value;
    }
}