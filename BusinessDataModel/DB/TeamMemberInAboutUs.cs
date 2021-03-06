﻿using System;
using System.Collections.Generic;

namespace BusinessDataModel.DB
{
    public partial class TeamMemberInAboutUs
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Designation { get; set; }
        public string FeaturedImage { get; set; }
        public bool? ShowInFrontEnd { get; set; }
        public string RecUpd { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
