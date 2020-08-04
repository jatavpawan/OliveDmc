using System;
using System.Collections.Generic;

namespace BusinessDataModel.DB
{
    public partial class Destination
    {
        public int Id { get; set; }
        public string CountryCode { get; set; }
        public string AboutCountry { get; set; }
        public string TopAttraction { get; set; }
        public string TopDestination { get; set; }
        public string Visadetail { get; set; }
        public string HowToReach { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string Miscellaneous { get; set; }
        public string RecUpd { get; set; }
        public string Video { get; set; }
    }
}
