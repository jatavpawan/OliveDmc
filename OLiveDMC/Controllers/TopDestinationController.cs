using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    public class TopDestinationController : ControllerBase
    {
        private ITopDestinationService _TopDestinationService;
        public TopDestinationController(ITopDestinationService TopDestinationService)
        {
            _TopDestinationService = TopDestinationService;
        }

        [HttpPost]
        [Route("AddUpdateTopDestination")]
        public async Task<ResponseModel> AddUpdateTopDestination([FromForm]VmTopDestination obj)
        {
            var Data = _TopDestinationService.AddUpdateTopDestination(obj);
            return await System.Threading.Tasks.Task.FromResult(Data);
        }


        [HttpGet]
        [Route("GetAllTopDestination")]
        public async Task<ResponseModel> GetAllTopDestination()
        {
            var Data = _TopDestinationService.GetAllTopDestination();
            return await System.Threading.Tasks.Task.FromResult(Data);
        }

        [HttpGet]
        [Route("deleteTopDestination")]
        public async Task<ResponseModel> deleteTopDestination(int? Id)
        {
            var Data = _TopDestinationService.deleteTopDestination(Id);
            return await System.Threading.Tasks.Task.FromResult(Data);
        }

        [HttpPost]
        [Route("fileUploadInTopDestination")]
        public async Task<ResponseModel> fileUploadInTopDestination([FromForm] vmfileInfo obj)
        {
            var Data = _TopDestinationService.fileUploadInTopDestination(obj);
            return await System.Threading.Tasks.Task.FromResult(Data);
        }


        [HttpGet]
        [Route("GetTopDestinationDetailByTopDestinationId")]
        public async Task<ResponseModel> GetTopDestinationDetailByTopDestinationId(int? Id)
        {
            var Data = _TopDestinationService.GetTopDestinationDetailByTopDestinationId(Id);
            return await System.Threading.Tasks.Task.FromResult(Data);
        }

        [HttpPost]
        [Route("videoUploadInTopDestination")]
        public async Task<ResponseModel> videoUploadInTopDestination([FromForm] vmfileInfo obj)
        {
            var Data = _TopDestinationService.videoUploadInTopDestination(obj);
            return await System.Threading.Tasks.Task.FromResult(Data);
        }

        [HttpGet]
        [Route("deleteVideoInTopDestination")]
        public async Task<ResponseModel> deleteVideoInTopDestination(string oldVideoName)
        {
            var Data = _TopDestinationService.deleteVideoInTopDestination(oldVideoName);
            return await System.Threading.Tasks.Task.FromResult(Data);
        }
        
        [HttpGet]
        [Route("GetTopDestinationByCountryId")]
        public async Task<ResponseModel> GetTopDestinationByCountryId(int? CountryId)
        {
            var Data = _TopDestinationService.GetTopDestinationByCountryId(CountryId);
            return await System.Threading.Tasks.Task.FromResult(Data);
        }

    }
}