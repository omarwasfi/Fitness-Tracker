using AutoMapper;
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
public class ExerciseActionController
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

        return new ExerciseActionDataViewModel();
    }
    
    [HttpPost]
    [Route("AddListOfExercisesAction")]
    public async Task<ActionResult<List<ExerciseActionDataViewModel>>> AddListOfExercisesAction(List<AddExerciseActionRequestDataModel> addExerciseActionRequest)
    {

        return new List<ExerciseActionDataViewModel>();
    }
    
    [HttpPut]
    [Route("EditExerciseAction")]
    public async Task<ActionResult<ExerciseDataViewModel>> EditExerciseAction(EditExerciseActionRequestDataModel editExerciseActionRequest)
    {

        return new ExerciseDataViewModel();
    }
    
        
    [HttpPut]
    [Route("EditListOfExerciseAction")]
    public async Task<ActionResult<List<ExerciseDataViewModel>>> EditListOfExerciseAction(List<EditExerciseActionRequestDataModel> editExerciseActionRequest)
    {

        return new List<ExerciseDataViewModel>();
    }
    
    [HttpDelete]
    [Route("DeleteExerciseAction")]
    public async Task<ActionResult<ExerciseDataViewModel>> DeleteExerciseAction(DeleteExerciseActionRequestDataModel deleteExerciseActionRequest)
    {

        return new ExerciseDataViewModel();
    }
    
    [HttpDelete]
    [Route("DeleteListOfExerciseAction")]
    public async Task<ActionResult<List<ExerciseDataViewModel>>> DeleteExerciseAction(List<DeleteExerciseActionRequestDataModel> deleteExerciseActionRequest)
    {

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