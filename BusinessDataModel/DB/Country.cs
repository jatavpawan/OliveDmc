using System;
using System.Collections.Generic;

namespace BusinessDataModel.DB
{
    public partial class Country
    {
        public int Id { get; set; }
        public string CountryName { get; set; }
        public string ContinentCode { get; set; }
        public string ContinentName { get; set; }
        public string RecUpd { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? UpdatedBy { get; set; }
    }
}
