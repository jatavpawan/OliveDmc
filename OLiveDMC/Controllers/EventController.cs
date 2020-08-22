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
    public class EventController : ControllerBase
    {
        private IEventService _eventService;
        public EventController(IEventService EventService)
        {
            _eventService = EventService;
        }

        [HttpPost]
        [Route("AddUpdateEvent")]
        public async Task<ResponseModel> AddUpdateEvent([FromForm]vmEvent obj)
        {
            var Data = _eventService.AddUpdateEvent(obj);
            return await System.Threading.Tasks.Task.FromResult(Data);
        }


        [HttpGet]
        [Route("GetAllEvent")]
        public async Task<ResponseModel> GetAllEvent()
        {
            var Data = _eventService.GetAllEvent();
            return await System.Threading.Tasks.Task.FromResult(Data);
        }

        [HttpGet]
        [Route("deleteEvent")]
        public async Task<ResponseModel> deleteEvent(int? Id)
        {
            var Data = _eventService.deleteEvent(Id);
            return await System.Threading.Tasks.Task.FromResult(Data);
        }

        [HttpPost]
        [Route("fileUploadInEvent")]
        public async Task<ResponseModel> fileUploadInEvent([FromForm] vmfileInfo obj)
        {
            var Data = _eventService.fileUploadInEvent(obj);
            return await System.Threading.Tasks.Task.FromResult(Data);
        }


        [HttpGet]
        [Route("GetEventDetailByEventId")]
        public async Task<ResponseModel> GetEventDetailByEventId(int? Id)
        {
            var Data = _eventService.GetEventDetailByEventId(Id);
            return await System.Threading.Tasks.Task.FromResult(Data);
        }

        [HttpPost]
        [Route("videoUploadInEvent")]
        public async Task<ResponseModel> videoUploadInEvent([FromForm] vmfileInfo obj)
        {
            var Data = _eventService.videoUploadInEvent(obj);
            return await System.Threading.Tasks.Task.FromResult(Data);
        }

        [HttpGet]
        [Route("deleteVideoInEvent")]
        public async Task<ResponseModel> deleteVideoInEvent(string oldVideoName)
        {
            var Data = _eventService.deleteVideoInEvent(oldVideoName);
            return await System.Threading.Tasks.Task.FromResult(Data);
        }
        
        [HttpGet]
        [Route("GetAllEventInFrontEnd")]
        public async Task<ResponseModel> GetAllEventInFrontEnd()
        {
            var Data = _eventService.GetAllEventInFrontEnd();
            return await System.Threading.Tasks.Task.FromResult(Data);
        }

    }
}