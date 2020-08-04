using System;
using System.Collections.Generic;

namespace BusinessDataModel.DB
{
    public partial class UserRegLogin
    {
        public int UserId { get; set; }
        public int? RegistrationId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int? RoleId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public bool? IsOtpVerify { get; set; }
    }
}
