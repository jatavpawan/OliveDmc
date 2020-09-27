using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessDataModel.ViewModel
{
   public partial class vmProfessionalCareer
    {
        public int Id { get; set; }
        public int? TotalExperience { get; set; }
        public string HighestQualification { get; set; }
        public string CurrentCompany { get; set; }
        public string CurrentLocation { get; set; }
        public string CurrentCtc { get; set; }
        public string ExpectedCtc { get; set; }
        public string SkillId { get; set; }
        public string AreaOfExpertise { get; set; }
        public string AboutMe { get; set; }
        public IFormFile UploadResume { get; set; }
        public IFormFile UploadProject { get; set; }
        public string RecUpd { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }


}
