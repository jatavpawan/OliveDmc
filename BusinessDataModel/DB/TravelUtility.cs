using System;
using System.Collections.Generic;

namespace BusinessDataModel.DB
{
    public partial class TravelUtility
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public bool? Status { get; set; }
        public string Image { get; set; }
        public int? CountryId { get; set; }
        public int? StateId { get; set; }
        public int? CityId { get; set; }
        public string RecUpd { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public string UtilityType { get; set; }
        public string Video { get; set; }
    }
}
