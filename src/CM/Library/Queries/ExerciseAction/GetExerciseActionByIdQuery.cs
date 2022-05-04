using System.Reflection.Metadata.Ecma335;
using CM.Library.DataModels.BusinessModels;
using MediatR;

namespace CM.Library.Queries.ExerciseAction;

public class GetExerciseActionByIdQuery : IRequest<ExerciseActionDataModel>
{

    public string Id { get; set; }
    
    public GetExerciseActionByIdQuery(string id)
    {
        Id = id;
    }

}