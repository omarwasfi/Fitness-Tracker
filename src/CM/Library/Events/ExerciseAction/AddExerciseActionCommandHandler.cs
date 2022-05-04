using System.Threading;
using System.Threading.Tasks;
using CM.Library.DataModels.BusinessModels;
using CM.Library.DBContexts;
using CM.Library.Queries.Exercise;
using CM.Library.Queries.ExercisePlan;
using CM.Library.Queries.Workout;
using MediatR;

namespace CM.Library.Events.ExerciseAction;

public class AddExerciseActionCommandHandler : IRequestHandler<AddExerciseActionCommand , ExerciseActionDataModel>
{
    private readonly IMediator _mediator;

    private readonly CurrentStateDBContext _currentStateDBContext;
    
    public AddExerciseActionCommandHandler(IMediator mediator, CurrentStateDBContext currentStateDbContext)
    {
        _mediator = mediator;
        _currentStateDBContext = currentStateDbContext;
    }
    
    
    public async Task<ExerciseActionDataModel> Handle(AddExerciseActionCommand request, CancellationToken cancellationToken)
    {
        ExerciseActionDataModel exerciseActionDataModel = new ExerciseActionDataModel();
        exerciseActionDataModel.Index = request.Index;
        exerciseActionDataModel.Note = request.Note;
        exerciseActionDataModel.Sets = request.Sets;
        exerciseActionDataModel.Reps = request.Reps;
        exerciseActionDataModel.Time = request.Time;
        exerciseActionDataModel.RestTime = request.RestTime;
        exerciseActionDataModel.Exercise = await _mediator.Send(new GetExerciseByIdQuery(request.ExerciseId));

        await _currentStateDBContext.ExerciseActions.AddAsync(exerciseActionDataModel);
        await _currentStateDBContext.SaveChangesAsync();

        if (request.AddingTo == "Workout")
        {
            
            WorkoutDataModel workout = await _mediator.Send(new GetWorkoutByIdQuery(request.WorkoutId));
            workout.ExerciseActions.Add(exerciseActionDataModel);
            
            await _currentStateDBContext.SaveChangesAsync();
        }

        if (request.AddingTo == "ExercisePlan")
        {
            ExercisePlanDataModel exercisePlan = await _mediator.Send(new GetExercisePlanByIdQuery(request.ExercisePlanId));
            exercisePlan.ExerciseActions.Add(exerciseActionDataModel);
            
            await _currentStateDBContext.SaveChangesAsync();
        }

        return exerciseActionDataModel;
    }
}