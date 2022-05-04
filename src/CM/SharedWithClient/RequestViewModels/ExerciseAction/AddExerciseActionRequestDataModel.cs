namespace CM.SharedWithClient.RequestViewModels;

public class AddExerciseActionRequestDataModel
{
    public int Index { get; set; } = 0;
    
    public string? ExerciseId { get; set; }

    /// <summary>
    /// this value Should only be
    /// 1- Workout
    /// 2- ExercisePlan
    /// </summary>
    public string? AddingTo { get; set; }

    public string? WorkoutId { get; set; }
    
    public string? ExercisePlanId { get; set; }

    public string? Reps { get; set; }

    public string? Sets { get; set; }

    public string? Time { get; set; }

    public string? RestTime { get; set; }

    public string? Note { get; set; }
}