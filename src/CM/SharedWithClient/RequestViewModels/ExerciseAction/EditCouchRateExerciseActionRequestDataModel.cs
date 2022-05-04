namespace CM.SharedWithClient.RequestViewModels;

public class EditCouchRateExerciseActionRequestDataModel
{
    public string? ExerciseActionId { get; set; }
    
    public int? CouchRateForTheMember { get; set; }

    public string? CouchRateNoteForTheMember { get; set; }
}