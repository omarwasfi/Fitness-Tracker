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

public class EditExerciseActionCommandHandler : IRequestHandler<EditExerciseActionCommand , ExerciseActionDataModel>
{
    private readonly IMediator _mediator;

    private readonly CurrentStateDBContext _currentStateDBContext;
    
    public EditExerciseActionCommandHandler(IMediator mediator, CurrentStateDBContext currentStateDbContext)
    {
        _mediator = mediator;
        _currentStateDBContext = currentStateDbContext;
    }
    
    
    public async Task<ExerciseActionDataModel> Handle(EditExerciseActionCommand request, CancellationToken cancellationToken)
    {
        ExerciseActionDataModel exerciseActionDataModel = await _mediator.Send(new GetExerciseActionByIdQuery(request.ExerciseActionId));
        exerciseActionDataModel.Index = request.Index;
        exerciseActionDataModel.Note = request.Note;
        exerciseActionDataModel.Sets = request.Sets;
        exerciseActionDataModel.Reps = request.Reps;
        exerciseActionDataModel.Time = request.Time;
        exerciseActionDataModel.RestTime = request.RestTime;
        exerciseActionDataModel.Exercise = await _mediator.Send(new GetExerciseByIdQuery(request.ExerciseId));

        await _currentStateDBContext.SaveChangesAsync();
        

        return exerciseActionDataModel;
    }
}