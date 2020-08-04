using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessDataModel.ViewModel
{
    public partial class vmUserRegistration
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string EmailId { get; set; }
        public string MobileNo { get; set; }
        public int? Category { get; set; }
        public bool? TravelEnthuiast { get; set; }
        public IFormFile ProfileImage { get; set; }
    }
}
