namespace CM.SharedWithClient.RequestViewModels;

public class DeleteExerciseActionRequestDataModel
{
    public string? ExerciseActionId { get; set; }
    
    /// <summary>
    /// this value Should only be
    /// 1- Workout
    /// 2- ExercisePlan
    /// </summary>
    public string? DeletingFrom { get; set; }

    public string? WorkoutId { get; set; }
    
    public string? ExercisePlanId { get; set; }
}