using System;
using System.Threading;
using System.Threading.Tasks;
using CM.Library.DataModels;
using CM.Library.DataModels.BusinessModels;
using CM.Library.DBContexts;
using MediatR;

namespace CM.Library.Events.Exercise
{
    public class AddExerciseCommandHandler : IRequestHandler<AddExerciseCommand,ExerciseDataModel>
    {
        private readonly IMediator _mediator;

        private readonly CurrentStateDBContext _currentStateDBContext;

        public AddExerciseCommandHandler(IMediator mediator, CurrentStateDBContext currentStateDbContext)
        {
            this._mediator = mediator;
            this._currentStateDBContext = currentStateDbContext;
        }

        public async Task<ExerciseDataModel> Handle(AddExerciseCommand request, CancellationToken cancellationToken)
        {


            PictureDataModel pictureDataModel = new PictureDataModel() { FileExtension = request.DefaultExercisePictureFileExtension, Path = request.DefaultExercisePictureFilePath, FileName = request.DefaultExercisePictureFileName };
            await _currentStateDBContext.Pictures.AddAsync(pictureDataModel);

            ExerciseDataModel newExercise = new ExerciseDataModel();
            newExercise.Name = request.Name;
            newExercise.Description = request.Description;
            newExercise.Picture = pictureDataModel;
            newExercise.VideoLink = request.VideoLink;

            await _currentStateDBContext.Exercises.AddAsync(newExercise);

            return newExercise;
        }
    }
}

