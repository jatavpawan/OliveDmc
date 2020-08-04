using System;
using System.Collections.Generic;

namespace BusinessDataModel.DB
{
    public partial class Page
    {
        public int PageId { get; set; }
        public int LeftMenuItemId { get; set; }
        public string PageTitle { get; set; }
        public string PageName { get; set; }
        public string ApplicationType { get; set; }
        public string ShowMobile { get; set; }
        public string RecUpd { get; set; }
    }
}
