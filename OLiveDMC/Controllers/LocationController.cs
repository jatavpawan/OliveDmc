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
    public class LocationController : ControllerBase
    {
        private ILocationService _LocationService;
        public LocationController(ILocationService LocationService)
        {
            _LocationService = LocationService;
        }
        // -------------------------------------Country Api -----------------------------------------------------------

        [HttpPost]
        [Route("AddUpdateCountry")]
        public async Task<ResponseModel> AddUpdateCountry(Country obj)
        {
            var Data = _LocationService.AddUpdateCountry(obj);
            return await System.Threading.Tasks.Task.FromResult(Data);
        }


        [HttpGet]
        [Route("GetAllCountry")]
        public async Task<ResponseModel> GetAllCountry()
        {
            var Data = _LocationService.GetAllCountry();
            return await System.Threading.Tasks.Task.FromResult(Data);
        }

        [HttpGet]
        [Route("deleteCountry")]
        public async Task<ResponseModel> deleteCountry(int? Id)
        {
            var Data = _LocationService.deleteCountry(Id);
            return await System.Threading.Tasks.Task.FromResult(Data);
        }


        [HttpGet]
        [Route("GetCountryDetailByCountryId")]
        public async Task<ResponseModel> GetCountryDetailByCountryId(int? Id)
        {
            var Data = _LocationService.GetCountryDetailByCountryId(Id);
            return await System.Threading.Tasks.Task.FromResult(Data);
        }


        // -------------------------------------State Api -----------------------------------------------------------

        [HttpPost]
        [Route("AddUpdateState")]
        public async Task<ResponseModel> AddUpdateState(State obj)
        {
            var Data = _LocationService.AddUpdateState(obj);
            return await System.Threading.Tasks.Task.FromResult(Data);
        }


        [HttpGet]
        [Route("GetAllState")]
        public async Task<ResponseModel> GetAllState()
        {
            var Data = _LocationService.GetAllState();
            return await System.Threading.Tasks.Task.FromResult(Data);
        }

        [HttpGet]
        [Route("deleteState")]
        public async Task<ResponseModel> deleteState(int? Id)
        {
            var Data = _LocationService.deleteState(Id);
            return await System.Threading.Tasks.Task.FromResult(Data);
        }


        [HttpGet]
        [Route("GetStateDetailByStateId")]
        public async Task<ResponseModel> GetStateDetailByStateId(int? Id)
        {
            var Data = _LocationService.GetStateDetailByStateId(Id);
            return await System.Threading.Tasks.Task.FromResult(Data);
        }

        // -------------------------------------City Api -----------------------------------------------------------

        [HttpPost]
        [Route("AddUpdateCity")]
        public async Task<ResponseModel> AddUpdateCity(City obj)
        {
            var Data = _LocationService.AddUpdateCity(obj);
            return await System.Threading.Tasks.Task.FromResult(Data);
        }


        [HttpGet]
        [Route("GetAllCity")]
        public async Task<ResponseModel> GetAllCity()
        {
            var Data = _LocationService.GetAllCity();
            return await System.Threading.Tasks.Task.FromResult(Data);
        }

        [HttpGet]
        [Route("deleteCity")]
        public async Task<ResponseModel> deleteCity(int? Id)
        {
            var Data = _LocationService.deleteCity(Id);
            return await System.Threading.Tasks.Task.FromResult(Data);
        }


        [HttpGet]
        [Route("GetCityDetailByCityId")]
        public async Task<ResponseModel> GetCityDetailByCityId(int? Id)
        {
            var Data = _LocationService.GetCityDetailByCityId(Id);
            return await System.Threading.Tasks.Task.FromResult(Data);
        }

        [HttpGet]
        [Route("GetStateByCountryId")]
        public async Task<ResponseModel> GetStateByCountryId(int? countryId)
        {
            var Data = _LocationService.GetStateByCountryId(countryId);
            return await System.Threading.Tasks.Task.FromResult(Data);
        }


        [HttpGet]
        [Route("GetCityByStateId")]
        public async Task<ResponseModel> GetCityByStateId(int? stateId)
        {
            var Data = _LocationService.GetCityByStateId(stateId);
            return await System.Threading.Tasks.Task.FromResult(Data);
        }



    }
}