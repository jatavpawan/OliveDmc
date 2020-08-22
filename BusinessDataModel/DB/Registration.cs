using System;
using System.Collections.Generic;

namespace BusinessDataModel.DB
{
    public partial class Registration
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailId { get; set; }
        public string MobileNo { get; set; }
        public int? Category { get; set; }
        public bool? TravelEnthuiast { get; set; }
        public string Otp { get; set; }
        public string Gmcid { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public string ProfileImage { get; set; }
        public int? RoleId { get; set; }
    }
}
