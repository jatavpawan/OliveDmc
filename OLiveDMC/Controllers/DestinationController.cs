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
    public class DestinationController : ControllerBase
    {

         private IDestinationService _destinationService;
         public DestinationController(IDestinationService destinationService)
         {
            _destinationService = destinationService;
         }


        [HttpPost]
        [Route("AddUpdateDestinationInCountry")]
        public async Task<ResponseModel> AddUpdateDestinationInCountry(Destination obj)
        {
            var Data = _destinationService.AddUpdateDestinationInCountry(obj);
            return await System.Threading.Tasks.Task.FromResult(Data);
        }

        [HttpGet]
        [Route("GetCountryInfoByCountryCode")]
        public async Task<ResponseModel> GetCountryInfoByCountryCode(string countryCode)
        {
            var Data = _destinationService.GetCountryInfoByCountryCode(countryCode);
            return await System.Threading.Tasks.Task.FromResult(Data);
        }

        [HttpGet]
        [Route("deleteCountryInfoById")]
        public async Task<ResponseModel> deleteCountryInfoById(int? Id)
        {
            var Data = _destinationService.deleteCountryInfoById(Id);
            return await System.Threading.Tasks.Task.FromResult(Data);
        }

        [HttpGet]
        [Route("GetAllDestinationCountry")]
        public async Task<ResponseModel> GetAllDestinationCountry()
        {
            var Data = _destinationService.GetAllDestinationCountry();
            return await System.Threading.Tasks.Task.FromResult(Data);
        }

        [HttpPost]
        [Route("fileUploadInDestination")]
        public async Task<ResponseModel> fileUploadInDestination([FromForm] vmfileInfo obj)
        {
            var Data = _destinationService.fileUploadInDestination(obj);
            return await System.Threading.Tasks.Task.FromResult(Data);
        }


        [HttpPost]
        [Route("videoUploadInDestination")]
        public async Task<ResponseModel> videoUploadInDestination([FromForm] vmfileInfo obj)
        {
            var Data = _destinationService.videoUploadInDestination(obj);
            return await System.Threading.Tasks.Task.FromResult(Data);
        }



    }
}   