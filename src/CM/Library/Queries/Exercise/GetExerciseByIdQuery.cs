using CM.Library.DataModels.BusinessModels;
using MediatR;

namespace CM.Library.Queries.Exercise;

public class GetExerciseByIdQuery : IRequest<ExerciseDataModel>
{
    public string ExerciseId { get; set; }

    public GetExerciseByIdQuery(string exerciseId)
    {
        ExerciseId = exerciseId;
    }

}