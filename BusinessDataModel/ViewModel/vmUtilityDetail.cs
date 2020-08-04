using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessDataModel.ViewModel
{
    public partial class vmUtilityDetail
    {

        public int Id { get; set; }
        public string Description { get; set; }
        public bool? Status { get; set; }
        public string Image { get; set; }
        public int? CountryId { get; set; }
        public string CountryName { get; set; }
        public int? StateId { get; set; }
        public string StateName { get; set; }
        public int? CityId { get; set; }
        public string CityName { get; set; }
        public string RecUpd { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public string UtilityType { get; set; }
        public string Video { get; set; }
    }

   
}
