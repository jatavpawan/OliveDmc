using BusinessDataModel.DB;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessDataModel.ViewModel
{
    public class vmAllBlogInUserPanel
    {
        public IEnumerable<Blog> blogList { get; set; }
        public int totalPage { get; set; }
        public int totalRecord { get; set; }
        public int perPageRecord  { get; set; }
       
    }


    public class vmUserPostBlogResponse
    {
        public List<vmUserPostBlogList> blogList { get; set; }
        public int totalPage { get; set; }
        public int totalRecord { get; set; }
        public int perPageRecord { get; set; }

    }
}
