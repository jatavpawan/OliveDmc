using System;
using System.Collections.Generic;

namespace BusinessDataModel.DB
{
    public partial class TravelUtilityQuery
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string RecUpd { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? TravelUtilityTypeId { get; set; }
        public string StartCountry { get; set; }
        public string DestinationCountry { get; set; }
        public DateTime? DateOfTravel { get; set; }
    }
}
