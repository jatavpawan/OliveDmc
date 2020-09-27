using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessDataModel.ViewModel
{
    public partial class vmFresherCareer
    {
        public int Id { get; set; }
        public string Location { get; set; }
        public string SkillId { get; set; }
        public string SocialMediaProfile { get; set; }
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
