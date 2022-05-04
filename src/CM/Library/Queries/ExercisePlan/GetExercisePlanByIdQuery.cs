using CM.Library.DataModels.BusinessModels;
using MediatR;

namespace CM.Library.Queries.ExercisePlan;

public class GetExercisePlanByIdQuery : IRequest<ExercisePlanDataModel>
{
    public string Id { get; set; }
 
    public GetExercisePlanByIdQuery(string id)
    {
        Id = id;
    }
}