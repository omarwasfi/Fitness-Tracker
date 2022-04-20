using CM.Library.DataModels.Chat;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM.Library.DataModels
{
    public class PersonDataModel : IdentityUser
    {
        public PersonDataModel()
        {
           
            this.OTPs = new HashSet<OTPDataModel>();
            this.Rooms = new HashSet<RoomDataModel>();
            this.Messages = new HashSet<MessageDataModel>();
        }
        [Column(TypeName = "nvarchar(100)")]
        public string FirstName { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string LastName { get; set; }


        [Column(TypeName = "nvarchar(10)")]
        public string Gender { get; set; }

        public bool IsAFixer { get; set; } = false;


        public virtual PictureDataModel ProfilePicture { get; set; }
        public virtual ICollection<OTPDataModel> OTPs { get; set; }



        #region Chat
        public virtual ICollection<RoomDataModel> Rooms { get; set; }
        public virtual ICollection<MessageDataModel> Messages { get; set; }
        #endregion

    }
}
