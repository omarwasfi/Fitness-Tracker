namespace CM.SharedWithClient;

public class ExercisePlanDataViewModel
{
    public string? Id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public List<ExerciseActionDataViewModel>? ExerciseActions { get; set; }
}