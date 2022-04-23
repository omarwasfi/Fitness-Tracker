using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CM.Library.DataModels.BusinessModels
{
	public class SessionDataModel
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public string Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Location { get; set; }

        public DateTime DateTime { get; set; }

        public string Duration { get; set; }

        public virtual List<WorkoutDataModel> Workouts { get; set; }

        public virtual PersonDataModel Couch { get; set; }

        public int HRFeedBackRateForCouch { get; set; }

        public string HRFeedBackForCouchNote { get; set; }

    }
}

