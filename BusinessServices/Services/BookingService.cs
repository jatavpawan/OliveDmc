using BusinessDataModel.DB;
using BusinessDataModel.ViewModel;
using BusinessRespository.Infrastructure;
using BusinessServices.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessServices.Services
{
    public class BookingService : IBookingService
    {
        private IUnitOfWork _unitOfWork;
        public IHttpContextAccessor __httpContextaccessor;
        private ResponseModel response;
        private IConfiguration _configuration;
        public BookingService(IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            response = new ResponseModel();
            __httpContextaccessor = httpContextAccessor;
            _configuration = configuration;
            //if (_httpContextaccessor.HttpContext.Session.GetString("Userdetail") != null)
            //    //{
            //    //    SessionUser = JsonConvert.DeserializeObject<Registration>(_httpContextaccessor.HttpContext.Session.GetString("Userdetail"));
            //    //}
        }
         
        public ResponseModel GetCityList(vmPredictCity obj)
        {          
            var res = new ResponseModel();
            obj.Listfor = _configuration.GetValue<string>("CityInfo:" + obj.Listfor);
            res.data= _unitOfWork.BookingRepository.GetCityList(obj);
            return res;
        }
    }
}
