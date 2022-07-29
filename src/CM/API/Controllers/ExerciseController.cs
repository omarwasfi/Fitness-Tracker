using AutoMapper;
using CM.Library.DataModels.BusinessModels;
using CM.Library.Events.Exercise;
using CM.Library.Events.ExerciseAction;
using CM.SharedWithClient;
using CM.SharedWithClient.RequestViewModels;
using CM.SharedWithClient.RequestViewModels.Exercise;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CM.API.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class ExerciseController : ControllerBase
{


    private IMediator _mediator { get; set; }
    private readonly IMapper _mapper;
    private IConfiguration _configuration;


    public ExerciseController(IMapper mapper, IMediator mediator, IConfiguration configuration)
    {
        _mapper = mapper;
        _mediator = mediator;
        this._configuration = configuration;
    }


    [HttpPost]
    [Route("AddExercise")]
    public async Task<ActionResult<ExerciseDataViewModel>> AddExercise(AddExerciseRequestDataViewModel addExerciseRequest)
    {
        ExerciseDataModel exerciseDataModel = await _mediator.Send(
                new AddExerciseCommand(
            name: addExerciseRequest.Name,
            description: addExerciseRequest.Description,
            videoLink: addExerciseRequest.VideoLink,
            defaultExercisePictureFileName: _configuration.GetValue<string>("DefaultExerciseImg:FileName"),
            defaultExercisePictureFileExtension: _configuration.GetValue<string>("DefaultExerciseImg:FileExtension"),
            defaultExercisePictureFilePath: _configuration.GetValue<string>("DefaultExerciseImg:Path"),
            this.User
        )
    ) ;

        ExerciseDataViewModel exerciseDataViewModel = _mapper.Map<ExerciseDataViewModel>(exerciseDataModel);
        return exerciseDataViewModel;
    }

}