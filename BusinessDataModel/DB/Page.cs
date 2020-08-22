using System;
using System.Collections.Generic;

namespace BusinessDataModel.DB
{
    public partial class Page
    {
        public int PageId { get; set; }
        public string PageTitle { get; set; }
        public string PagePath { get; set; }
        public string RecUpd { get; set; }
    }
}
