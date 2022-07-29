using System;
using System.Security.Claims;
using CM.Library.DataModels;
using CM.Library.DataModels.BusinessModels;
using MediatR;

namespace CM.Library.Events.Exercise
{
    public class AddExerciseCommand : IRequest<ExerciseDataModel>
    {

        public string Name { get; set; }

        public string Description { get; set; }

        public string VideoLink { get; set; }

        public string DefaultExercisePictureFileName { get; set; }

        public string DefaultExercisePictureFileExtension { get; set; }

        public string DefaultExercisePictureFilePath { get; set; }

        public ClaimsPrincipal ClaimsPrincipal { get; set; }


        public AddExerciseCommand( string name, string description, string videoLink, string defaultExercisePictureFileName, string defaultExercisePictureFileExtension, string defaultExercisePictureFilePath, ClaimsPrincipal claimsPrincipal)
        {
            Name = name;
            Description = description;
            VideoLink = videoLink;
            DefaultExercisePictureFileName = defaultExercisePictureFileName;
            DefaultExercisePictureFileExtension = defaultExercisePictureFileExtension;
            DefaultExercisePictureFilePath = defaultExercisePictureFilePath;
            ClaimsPrincipal = claimsPrincipal;
        }
    }
}

