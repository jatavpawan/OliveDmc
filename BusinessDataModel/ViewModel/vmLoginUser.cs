using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Text;

namespace BusinessDataModel.ViewModel {

    public partial class vmLoginUser {

        public string Email { get; set; }
        public string Password { get; set; }

    }

    public partial class vmOtpVerify
    {
        public string Email { get; set; }
        public string Otp { get; set; }
    }

    public partial class vmResendOtp
    {
        public string Email { get; set; }
    }

    public partial class vmForgotPassword
    {
        public string Email { get; set; }
    }

    public partial class vmChangePassword
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public partial class vmRegistration {
        public int? Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailId { get; set; }
        public string MobileNo { get; set; }
        public int? Category { get; set; }
        public bool? TravelEnthuiast { get; set; }
        public string Otp { get; set; }
        public string Gmcid { get; set; }
        public DateTime? CreatedDate { get; set; }

        public string Password { get; set; }
   
    }
    public partial class Registration_result
    {
        public string Email { get; set; }
        public int? RegistrationId { get; set; }
        public string Name { get; set; }
        public int? RoleId { get; set; }      
        public string MobileNo { get; set; }
        public string ProfilePic { get; set; }
        public string Otp { get; set; }
        public bool? Otpverify { get; set; }
        public string Gcmid { get; set; }
       
    }

    public partial class getAllUser
    {
        public int? Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string EmailId { get; set; }
        public string MobileNo { get; set; }
        public int? Category { get; set; }
        public bool? TravelEnthuiast { get; set; }
       
    }

    //public partial class vmAboutUsDetail
    //{
    //    public string Description { get; set; }
    //    public bool? Status { get; set; }
    //}

    //public partial class vmGetAboutUsDetail
    //{
    //    public int Id { get; set; }
    //    public string Description { get; set; }
    //    public bool? Status { get; set; }
    //}
    public partial class vmResetPassword { 
         public string NewPassword { get; set; }
        public string encrypPath { get; set; }
    }


    public partial class vmUserChangePassword
    {
        public int? RegistrationId { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }

    }






}
