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
        public int? RoleId { get; set; }
        public DateTime? Birthday { get; set; }
        public string Occupation { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string AboutDescription { get; set; }
        public string ProfileImg { get; set; }
        public string CoverImage { get; set; }
        public string RecUpd { get; set; }
        public int? ProfileVisit { get; set; }
    }
}
