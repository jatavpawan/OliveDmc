using System;
using System.Collections.Generic;

namespace BusinessDataModel.DB
{
    public partial class FresherCareer
    {
        public int Id { get; set; }
        public string Location { get; set; }
        public string SkillId { get; set; }
        public string SocialMediaProfile { get; set; }
        public string AboutMe { get; set; }
        public string UploadResume { get; set; }
        public string UploadProject { get; set; }
        public string RecUpd { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
