using BusinessDataModel.DB;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessDataModel.ViewModel
{
    public class vmAllBlogInUserPanel
    {
        public List<Blog> blogList { get; set; }
        public int totalPage { get; set; }
        public int perPageRecord  { get; set; }
       
    }
}
