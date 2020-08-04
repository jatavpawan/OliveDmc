using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessDataModel.ViewModel {
    public class ResponseModel {
        public dynamic data { get; set; }
        public string message { get; set; }
        public Status status { get; set; }
        public string error { get; set; }

    }
    public enum Status {
        Error,
        Success,
        Warning
    }
}
