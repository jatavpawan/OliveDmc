using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessDataModel.ViewModel
{
    public partial class vmAboutUsDetail
    {
        public string Description { get; set; }
        public bool? Status { get; set; }
    }

    public partial class vmGetAboutUsDetail
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public bool? Status { get; set; }
    }


    public partial class vmfileInfo
    {
        public IFormFile fileInfo{ get; set; }
               
    }


}
