namespace CM.SharedWithClient;

public class WorkoutDataViewModel
{

    public string? Id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public string? Location { get; set; }

    public DateTime? DateTime { get; set; }

    public List<ExerciseActionDataViewModel>  ExerciseActions { get; set; }

    public PersonDataViewModel Member { get; set; }

    public string? HRFeedBackNoteForTheCouch { get; set; }

    public string? HRFeedBackNoteForTheMember { get; set; }
}