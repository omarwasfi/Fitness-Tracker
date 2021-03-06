using System.Security.Claims;
using CM.Library.DataModels.BusinessModels;
using MediatR;

namespace CM.Library.Events.ExerciseAction;

public class AddExerciseActionCommand : IRequest<ExerciseActionDataModel>
{


    public int Index { get; set; }
		
    public string ExerciseId { get; set; }

    /// <summary>
    /// this value Should only be
    /// 1- Workout
    /// 2- ExercisePlan
    /// </summary>
    public string AddingTo { get; set; }

    public string WorkoutId { get; set; }
    
    public string ExercisePlanId { get; set; }

    public string Reps { get; set; }

    public string Sets { get; set; }

    public string Time { get; set; }

    public string RestTime { get; set; }

    public string Note { get; set; }
    public ClaimsPrincipal ClaimsPrincipal { get; set; }
    
    
    public AddExerciseActionCommand(int index, string exerciseId, string addingTo, string workoutId, string exercisePlanId, string reps, string sets, string time, string restTime, string note, ClaimsPrincipal claimsPrincipal)
    {
        Index = index;
        ExerciseId = exerciseId;
        AddingTo = addingTo;
        WorkoutId = workoutId;
        ExercisePlanId = exercisePlanId;
        Reps = reps;
        Sets = sets;
        Time = time;
        RestTime = restTime;
        Note = note;
        ClaimsPrincipal = claimsPrincipal;
    }

}