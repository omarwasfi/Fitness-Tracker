using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CM.Library.DataModels.BusinessModels
{
	public class ExerciseActionDataModel
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public string Id { get; set; }

		public int Index { get; set; }
		
        public virtual ExerciseDataModel Exercise { get; set; }

        public string Reps { get; set; }

        public string Sets { get; set; }

        public string Time { get; set; }

        public string RestTime { get; set; }

        public string Note { get; set; }

		public int MemberFeedBackRateForTheCouch { get; set; }

		public string MemberFeedBackRateNoteForTheCouch { get; set; }

        public string TechnicalFeedBackNoteForTheCouch { get; set; }

        public int CouchRateForTheMember { get; set; }

        public string CouchRateNoteForTheMember { get; set; }



    }
}

