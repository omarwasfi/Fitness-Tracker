using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CM.Library.DataModels.BusinessModels
{
	public class WorkoutDataModel
	{
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Location { get; set; }

        public DateTime DateTime { get; set; }

        public virtual List<ExerciseActionDataModel>  ExerciseActions { get; set; }

        public virtual PersonDataModel Member { get; set; }

        public string HRFeedBackNoteForTheCouch { get; set; }

        public string HRFeedBackNoteForTheMember { get; set; }
    }
}

