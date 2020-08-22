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
    public class LatestEventController : ControllerBase
    {
        private ILatestEventService _LatestEventService;
        public LatestEventController(ILatestEventService LatestEventService)
        {
            _LatestEventService = LatestEventService;
        }

        [HttpPost]
        [Route("AddUpdateLatestEvent")]
        public async Task<ResponseModel> AddUpdateLatestEvent([FromForm]vmLatestEvent obj)
        {
            var Data = _LatestEventService.AddUpdateLatestEvent(obj);
            return await System.Threading.Tasks.Task.FromResult(Data);
        }


        [HttpGet]
        [Route("GetAllLatestEvent")]
        public async Task<ResponseModel> GetAllLatestEvent()
        {
            var Data = _LatestEventService.GetAllLatestEvent();
            return await System.Threading.Tasks.Task.FromResult(Data);
        }

        [HttpGet]
        [Route("deleteLatestEvent")]
        public async Task<ResponseModel> deleteLatestEvent(int? Id)
        {
            var Data = _LatestEventService.deleteLatestEvent(Id);
            return await System.Threading.Tasks.Task.FromResult(Data);
        }

        [HttpPost]
        [Route("fileUploadInLatestEvent")]
        public async Task<ResponseModel> fileUploadInLatestEvent([FromForm] vmfileInfo obj)
        {
            var Data = _LatestEventService.fileUploadInLatestEvent(obj);
            return await System.Threading.Tasks.Task.FromResult(Data);
        }


        [HttpGet]
        [Route("GetLatestEventDetailByEventId")]
        public async Task<ResponseModel> GetLatestEventDetailByEventId(int? Id)
        {
            var Data = _LatestEventService.GetLatestEventDetailByEventId(Id);
            return await System.Threading.Tasks.Task.FromResult(Data);
        }

        [HttpPost]
        [Route("videoUploadInLatestEvent")]
        public async Task<ResponseModel> videoUploadInLatestEvent([FromForm] vmfileInfo obj)
        {
            var Data = _LatestEventService.videoUploadInLatestEvent(obj);
            return await System.Threading.Tasks.Task.FromResult(Data);
        }

        [HttpGet]
        [Route("deleteVideoInLatestEvent")]
        public async Task<ResponseModel> deleteVideoInLatestEvent(string oldVideoName)
        {
            var Data = _LatestEventService.deleteVideoInLatestEvent(oldVideoName);
            return await System.Threading.Tasks.Task.FromResult(Data);
        }
     
        [HttpGet]
        [Route("GetAllLatestEventInFrontEnd")]
        public async Task<ResponseModel> GetAllLatestEventInFrontEnd()
        {
            var Data = _LatestEventService.GetAllLatestEventInFrontEnd();
            return await System.Threading.Tasks.Task.FromResult(Data);
        }


    }
}