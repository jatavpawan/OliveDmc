using BusinessDataModel.DB;
using BusinessDataModel.ViewModel;
using BusinessRespository.Infrastructure;
using BusinessRespository.IRepositories;
using BusinessRespository.Utility;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace BusinessRespository.Repositories
{
    class BookingRepository : IBookingRepository
    {
        private TravelOliveContext Context;

        public BookingRepository(TravelOliveContext _context)
        {
            Context = _context;
        }

        public List<string> GetCityList(vmPredictCity obj)
        {
            var lst = new List<string>();
           lst= JsonConvert.DeserializeObject<List<string>>(WebHelper.WRequestobj(obj.Listfor,JsonConvert.SerializeObject(obj)));
            return lst;
        }
     
    }
}
