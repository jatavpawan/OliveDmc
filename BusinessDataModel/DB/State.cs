using System;
using System.Collections.Generic;

namespace BusinessDataModel.DB
{
    public partial class State
    {
        public int Id { get; set; }
        public string StateName { get; set; }
        public int? CountryId { get; set; }
        public string RecUpd { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? UpdatedBy { get; set; }
    }
}
