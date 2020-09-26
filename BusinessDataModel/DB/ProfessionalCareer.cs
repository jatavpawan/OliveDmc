using System;
using System.Collections.Generic;

namespace BusinessDataModel.DB
{
    public partial class ProfessionalCareer
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
        public string UploadResume { get; set; }
        public string UploadProject { get; set; }
        public string RecUpd { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
