using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CM.Library.DataModels.BusinessModels
{
	public class ExercisePlanDataModel
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public string Id { get; set; }

        public string Name { get; set; }

		public string Description { get; set; }

        public virtual List<ExerciseActionDataModel> ExerciseActions { get; set; }
    }
}

