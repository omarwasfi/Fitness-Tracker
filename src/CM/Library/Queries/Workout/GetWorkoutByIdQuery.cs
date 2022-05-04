using CM.Library.DataModels.BusinessModels;
using MediatR;

namespace CM.Library.Queries.Workout;

public class GetWorkoutByIdQuery : IRequest<WorkoutDataModel>
{
    public string Id { get; set; }

    public GetWorkoutByIdQuery(string id)
    {
        Id = id;
    }
}