using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessDataModel.ViewModel
{

    public partial class vmUserPersonalInfo
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public DateTime? Birthday { get; set; }
        public string Occupation { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        
      
        public string RecUpd { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }

    public partial class vmUserProfileImage
    {
        public int UserId { get; set; }
        public IFormFile ProfileImg { get; set; }

    }

    public partial class vmUserCoverImg
    {
        public int UserId { get; set; }
        public IFormFile CoverImage { get; set; }

    }

    public partial class vmUserAboutDescription
    {
        public int UserId { get; set; }
        public string AboutDescription { get; set; }

    }

}
