using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CM.Library.DataModels.Chat;

namespace CM.Library.DataModels.BusinessModels
{
	public class ExerciseDataModel
	{
        public ExerciseDataModel()
        {
            this.ExerciseActions = new HashSet<ExerciseActionDataModel>();

        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public virtual PictureDataModel Picture { get; set; }

        public string VideoLink { get; set; }


        public virtual ICollection<ExerciseActionDataModel> ExerciseActions { get; set; }


    }
}

