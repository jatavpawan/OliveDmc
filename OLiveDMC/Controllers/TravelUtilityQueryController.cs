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

namespace OLiveDMC.Controllers
{
    
    [Route("[controller]")]
    [ApiController]
    [TypeFilter(typeof(CustomException))]
    public class TravelUtilityQueryController : ControllerBase
    {
        private ITravelUtilityQueryService _TravelUtilityQueryService;
        public TravelUtilityQueryController(ITravelUtilityQueryService TravelUtilityQueryService)
        {
            _TravelUtilityQueryService = TravelUtilityQueryService;
        }

        [HttpPost]
        [Route("AddUpdateTravelUtilityQuery")]
        public async Task<ResponseModel> AddUpdateTravelUtilityQuery(TravelUtilityQuery obj)
        {
            var Data = _TravelUtilityQueryService.AddUpdateTravelUtilityQuery(obj);
            return await System.Threading.Tasks.Task.FromResult(Data);
        }


        [HttpGet]
        [Route("GetAllTravelUtilityQuery")]
        public async Task<ResponseModel> GetAllTravelUtilityQuery()
        {
            var Data = _TravelUtilityQueryService.GetAllTravelUtilityQuery();
            return await System.Threading.Tasks.Task.FromResult(Data);
        }

        [HttpGet]
        [Route("deleteTravelUtilityQuery")]
        public async Task<ResponseModel> deleteTravelUtilityQuery(int? Id)
        {
            var Data = _TravelUtilityQueryService.deleteTravelUtilityQuery(Id);
            return await System.Threading.Tasks.Task.FromResult(Data);
        }


        [HttpGet]
        [Route("GetTravelUtilityQueryDetailById")]
        public async Task<ResponseModel> GetTravelUtilityQueryDetailById(int? Id)
        {
            var Data = _TravelUtilityQueryService.GetTravelUtilityQueryDetailById(Id);
            return await System.Threading.Tasks.Task.FromResult(Data);
        }

    }
}