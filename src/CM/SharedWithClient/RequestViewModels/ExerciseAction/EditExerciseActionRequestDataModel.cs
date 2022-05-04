namespace CM.SharedWithClient.RequestViewModels;

public class EditExerciseActionRequestDataModel
{
    public string? ExerciseActionId { get; set; }

    public int Index { get; set; } = 0;
		
    public string? ExerciseId { get; set; }

    public string? Reps { get; set; }

    public string? Sets { get; set; }

    public string? Time { get; set; }

    public string? RestTime { get; set; }

    public string? Note { get; set; }
}