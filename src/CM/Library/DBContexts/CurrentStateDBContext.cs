using CM.Library.DataModels;
using CM.Library.DataModels.Chat;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CM.Library.DataModels.BusinessModels;

namespace CM.Library.DBContexts
{
    [System.Data.Entity.DbConfigurationType(typeof(MySql.Data.EntityFramework.MySqlEFConfiguration))]
    public class CurrentStateDBContext : IdentityDbContext<PersonDataModel>
    {
    
        public DbSet<PictureDataModel> Pictures { get; set; }
        public DbSet<OTPDataModel> OTPs { get; set; }
        public DbSet<RoomDataModel> Rooms { get; set; }
        public DbSet<MessageDataModel> Messages { get; set; }
        public DbSet<MessageContentDataModel> MessageContents { get; set; }

        public DbSet<ExerciseActionDataModel> ExerciseActions { get; set; }

        public DbSet<ExerciseDataModel> Exercises { get; set; }

        public DbSet<ExercisePlanDataModel> ExercisePlans { get; set; }

        public DbSet<WorkoutDataModel> Workouts { get; set; }

        public DbSet<SessionDataModel> Sessions { get; set; }
        public CurrentStateDBContext(DbContextOptions<CurrentStateDBContext> options) : base(options)
        {


        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies(true);
        }
       

    }
}
