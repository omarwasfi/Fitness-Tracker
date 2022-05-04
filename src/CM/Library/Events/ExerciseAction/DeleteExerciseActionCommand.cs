using System.Security.Claims;
using CM.Library.DataModels.BusinessModels;
using MediatR;

namespace CM.Library.Events.ExerciseAction;

public class DeleteExerciseActionCommand : IRequest
{

    public string ExerciseActionId { get; set; }
    
    /// <summary>
    /// this value Should only be
    /// 1- Workout
    /// 2- ExercisePlan
    /// </summary>
    public string DeletingFrom { get; set; }

    public string WorkoutId { get; set; }
    
    public string ExercisePlanId { get; set; }
    public ClaimsPrincipal ClaimsPrincipal { get; set; }
    
    public DeleteExerciseActionCommand(string exerciseActionId, string deletingFrom, string workoutId, string exercisePlanId, ClaimsPrincipal claimsPrincipal)
    {
        ExerciseActionId = exerciseActionId;
        DeletingFrom = deletingFrom;
        WorkoutId = workoutId;
        ExercisePlanId = exercisePlanId;
        ClaimsPrincipal = claimsPrincipal;
    }



}