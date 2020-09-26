using System;
using System.Collections.Generic;

namespace BusinessDataModel.DB
{
    public partial class Skills
    {
        public int Id { get; set; }
        public string SkillName { get; set; }
        public bool? ShowInFrontEnd { get; set; }
        public string RecUpd { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
