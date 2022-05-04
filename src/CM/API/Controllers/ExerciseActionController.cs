

using AutoMapper;
using CM.Library.DataModels.BusinessModels;
using CM.Library.Events.ExerciseAction;
using CM.SharedWithClient;
using CM.SharedWithClient.RequestViewModels;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CM.API.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class ExerciseActionController : ControllerBase
{
    
    private IMediator _mediator { get; set; }
    private readonly IMapper _mapper;
    
    public ExerciseActionController(IMapper mapper, IMediator mediator)
    {
        _mapper = mapper;
        _mediator = mediator;
    }

    [HttpPost]
    [Route("AddExerciseAction")]
    public async Task<ActionResult<ExerciseActionDataViewModel>> AddExerciseAction(AddExerciseActionRequestDataModel addExerciseActionRequest)
    {
        ExerciseActionDataModel exerciseActionDataModel = await _mediator.Send(
                new AddExerciseActionCommand(
            index: addExerciseActionRequest.Index,
            exerciseId: addExerciseActionRequest.ExerciseId,
            addExerciseActionRequest.AddingTo,
            addExerciseActionRequest.WorkoutId,
            addExerciseActionRequest.ExercisePlanId,
            addExerciseActionRequest.Reps,
            addExerciseActionRequest.Sets,
            addExerciseActionRequest.Time,
            addExerciseActionRequest.RestTime,
            addExerciseActionRequest.Note,
            this.User
        )
    );

        // TODO call the mapper
    return new ExerciseActionDataViewModel();
    }

    [HttpPost]
    [Route("AddListOfExercisesAction")]
    public async Task<ActionResult<List<ExerciseActionDataViewModel>>> AddListOfExercisesAction(
        List<AddExerciseActionRequestDataModel> addExerciseActionRequests)
    {
        List<ExerciseActionDataModel> newExerciseActions = new List<ExerciseActionDataModel>();

        foreach (AddExerciseActionRequestDataModel addExerciseActionRequest in addExerciseActionRequests)
        {
            ExerciseActionDataModel exerciseActionDataModel = await _mediator.Send(
                new AddExerciseActionCommand(
                    index: addExerciseActionRequest.Index,
                    exerciseId: addExerciseActionRequest.ExerciseId,
                    addExerciseActionRequest.AddingTo,
                    addExerciseActionRequest.WorkoutId,
                    addExerciseActionRequest.ExercisePlanId,
                    addExerciseActionRequest.Reps,
                    addExerciseActionRequest.Sets,
                    addExerciseActionRequest.Time,
                    addExerciseActionRequest.RestTime,
                    addExerciseActionRequest.Note,
                    this.User
                )
            );

            newExerciseActions.Add(exerciseActionDataModel);
        }

        // TODO call the mapper

        return new List<ExerciseActionDataViewModel>();
    }

    [HttpPut]
    [Route("EditExerciseAction")]
    public async Task<ActionResult<ExerciseActionDataModel>> EditExerciseAction(EditExerciseActionRequestDataModel editExerciseActionRequest)
    {
        ExerciseActionDataModel exerciseActionDataModel = await _mediator.Send(new EditExerciseActionCommand(
            exerciseActionId: editExerciseActionRequest.ExerciseActionId,
            index: editExerciseActionRequest.Index,
            exerciseId: editExerciseActionRequest.ExerciseId,
            reps: editExerciseActionRequest.Reps,
            sets: editExerciseActionRequest.Sets,
            time: editExerciseActionRequest.Time,
            restTime:editExerciseActionRequest.RestTime,
            note: editExerciseActionRequest.Note,
            this.User
            
            ));
        return new ExerciseActionDataModel();
    }
    
        
    [HttpPut]
    [Route("EditListOfExerciseAction")]
    public async Task<ActionResult<List<ExerciseActionDataModel>>> EditListOfExerciseAction(List<EditExerciseActionRequestDataModel> editExerciseActionRequests)
    {
        List<ExerciseActionDataModel> editedExerciseActions = new List<ExerciseActionDataModel>();

        foreach (EditExerciseActionRequestDataModel editExerciseActionRequest in editExerciseActionRequests)
        {
            ExerciseActionDataModel exerciseActionDataModel = await _mediator.Send(new EditExerciseActionCommand(
                exerciseActionId: editExerciseActionRequest.ExerciseActionId,
                index: editExerciseActionRequest.Index,
                exerciseId: editExerciseActionRequest.ExerciseId,
                reps: editExerciseActionRequest.Reps,
                sets: editExerciseActionRequest.Sets,
                time: editExerciseActionRequest.Time,
                restTime:editExerciseActionRequest.RestTime,
                note: editExerciseActionRequest.Note,
                this.User
            
            ));
            
            editedExerciseActions.Add(exerciseActionDataModel);
        }
            
        return new List<ExerciseActionDataModel>();
    }
    
    [HttpDelete]
    [Route("DeleteExerciseAction")]
    public async Task<ActionResult> DeleteExerciseAction(DeleteExerciseActionRequestDataModel deleteExerciseActionRequest)
    {
        await _mediator.Send(new DeleteExerciseActionCommand(
            exerciseActionId: deleteExerciseActionRequest.ExerciseActionId,
            deletingFrom: deleteExerciseActionRequest.DeletingFrom,
            workoutId: deleteExerciseActionRequest.WorkoutId,
            exercisePlanId: deleteExerciseActionRequest.ExercisePlanId,
            this.User
        ));
        return new OkResult();
    }
    
    [HttpDelete]
    [Route("DeleteListOfExerciseAction")]
    public async Task<ActionResult<List<ExerciseDataViewModel>>> DeleteExerciseAction(List<DeleteExerciseActionRequestDataModel> deleteExerciseActionRequests)
    {
        foreach (var deleteExerciseActionRequest in deleteExerciseActionRequests)
        {
            await _mediator.Send(new DeleteExerciseActionCommand(
                exerciseActionId: deleteExerciseActionRequest.ExerciseActionId,
                deletingFrom: deleteExerciseActionRequest.DeletingFrom,
                workoutId: deleteExerciseActionRequest.WorkoutId,
                exercisePlanId: deleteExerciseActionRequest.ExercisePlanId,
                this.User
            ));
        }
        return new List<ExerciseDataViewModel>();
    }
    
    [HttpPut]
    [Route("EditCouchRateExerciseAction")]
    public async Task<ActionResult<ExerciseDataViewModel>> EditCouchRateExerciseAction(EditCouchRateExerciseActionRequestDataModel editCouchRateExerciseActionRequest)
    {

        return new ExerciseDataViewModel();
    }
    
    [HttpPut]
    [Route("EditMemberRateExerciseAction")]
    public async Task<ActionResult<ExerciseDataViewModel>> EditMemberRateExerciseAction(EditMemberFeedBackExerciseActionRequestDataModel editMemberFeedBackExerciseActionRequest)
    {

        return new ExerciseDataViewModel();
    }
    
    [HttpPut]
    [Route("EditTechnicalFeedBackExerciseActionRequestDataModel")]
    public async Task<ActionResult<ExerciseDataViewModel>> EditTechnicalFeedBackExerciseAction(EditTechnicalFeedBackExerciseActionRequestDataModel editTechnicalFeedBackExerciseActionRequest)
    {

        return new ExerciseDataViewModel();
    }


}