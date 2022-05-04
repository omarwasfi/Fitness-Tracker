using System.Security.Claims;
using CM.Library.DataModels.BusinessModels;
using MediatR;

namespace CM.Library.Events.ExerciseAction;

public class EditExerciseActionCommand : IRequest<ExerciseActionDataModel>
{

    public string ExerciseActionId { get; set; }

    public int Index { get; set; }
		
    public string ExerciseId { get; set; }

    public string Reps { get; set; }

    public string Sets { get; set; }

    public string Time { get; set; }

    public string RestTime { get; set; }

    public string Note { get; set; }
    public ClaimsPrincipal ClaimsPrincipal { get; set; }
    
    
    public EditExerciseActionCommand(string exerciseActionId, int index, string exerciseId,  string reps, string sets, string time, string restTime, string note, ClaimsPrincipal claimsPrincipal)
    {
        ExerciseActionId = exerciseActionId;
        Index = index;
        ExerciseId = exerciseId;
        Reps = reps;
        Sets = sets;
        Time = time;
        RestTime = restTime;
        Note = note;
        ClaimsPrincipal = claimsPrincipal;
    }

}