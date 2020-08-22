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
    public class InterviewsInWhatsNewController : ControllerBase
    {
        private IInterviewsInWhatsNewService _InterviewsInWhatsNewService;
        public InterviewsInWhatsNewController(IInterviewsInWhatsNewService InterviewsInWhatsNewService)
        {
            _InterviewsInWhatsNewService = InterviewsInWhatsNewService;
        }

        [HttpPost]
        [Route("AddUpdateInterviewsInWhatsNew")]
        public async Task<ResponseModel> AddUpdateInterviewsInWhatsNew([FromForm]vmInterviewsInWhatsNew obj)
        {
            var Data = _InterviewsInWhatsNewService.AddUpdateInterviewsInWhatsNew(obj);
            return await System.Threading.Tasks.Task.FromResult(Data);
        }


        [HttpGet]
        [Route("GetAllInterviewsInWhatsNew")]
        public async Task<ResponseModel> GetAllInterviewsInWhatsNew()
        {
            var Data = _InterviewsInWhatsNewService.GetAllInterviewsInWhatsNew();
            return await System.Threading.Tasks.Task.FromResult(Data);
        }

        [HttpGet]
        [Route("deleteInterviewsInWhatsNew")]
        public async Task<ResponseModel> deleteInterviewsInWhatsNew(int? Id)
        {
            var Data = _InterviewsInWhatsNewService.deleteInterviewsInWhatsNew(Id);
            return await System.Threading.Tasks.Task.FromResult(Data);
        }

        [HttpPost]
        [Route("fileUploadInInterviewsInWhatsNew")]
        public async Task<ResponseModel> fileUploadInInterviewsInWhatsNew([FromForm] vmfileInfo obj)
        {
            var Data = _InterviewsInWhatsNewService.fileUploadInInterviewsInWhatsNew(obj);
            return await System.Threading.Tasks.Task.FromResult(Data);
        }


        [HttpGet]
        [Route("GetInterviewsInWhatsNewDetailByInterviewsId")]
        public async Task<ResponseModel> GetInterviewsInWhatsNewDetailByInterviewsId(int? Id)
        {
            var Data = _InterviewsInWhatsNewService.GetInterviewsInWhatsNewDetailByInterviewsId(Id);
            return await System.Threading.Tasks.Task.FromResult(Data);
        }

        [HttpPost]
        [Route("videoUploadInInterviewsInWhatsNew")]
        public async Task<ResponseModel> videoUploadInInterviewsInWhatsNew([FromForm] vmfileInfo obj)
        {
            var Data = _InterviewsInWhatsNewService.videoUploadInInterviewsInWhatsNew(obj);
            return await System.Threading.Tasks.Task.FromResult(Data);
        }

        [HttpGet]
        [Route("deleteVideoInInterviewsInWhatsNew")]
        public async Task<ResponseModel> deleteVideoInInterviewsInWhatsNew(string oldVideoName)
        {
            var Data = _InterviewsInWhatsNewService.deleteVideoInInterviewsInWhatsNew(oldVideoName);
            return await System.Threading.Tasks.Task.FromResult(Data);
        }

        [HttpGet]
        [Route("GetAllInterviewsInWhatsNewFrontEnd")]
        public async Task<ResponseModel> GetAllInterviewsInWhatsNewFrontEnd()
        {
            var Data = _InterviewsInWhatsNewService.GetAllInterviewsInWhatsNewFrontEnd();
            return await System.Threading.Tasks.Task.FromResult(Data);
        }

    }
}