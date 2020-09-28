using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessDataModel.DB;
using BusinessDataModel.ViewModel;
using BusinessServices.IServices;
using CookApp.Filters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
namespace OLiveDMC.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [TypeFilter(typeof(CustomException))]
    public class BookingController : ControllerBase
    {
        private IBookingService _BookingService;
        private IConfiguration _configuration;
        public BookingController(IBookingService BookingService, IConfiguration configuration)
        {
            _BookingService = BookingService;
            _configuration = configuration;
        }

        [HttpPost]
        [Route("GetLocationList")]
        public async Task<ResponseModel> GetLocationList(vmPredictCity obj)
        {
          
            var Data = _BookingService.GetCityList(obj);
            return await System.Threading.Tasks.Task.FromResult(Data);
        }

       

    }
}