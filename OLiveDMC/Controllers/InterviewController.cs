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
    public class InterviewController : ControllerBase
    {
        private IInterviewService _InterviewService;
        public InterviewController(IInterviewService InterviewService)
        {
            _InterviewService = InterviewService;
        }

        [HttpPost]
        [Route("AddUpdateInterview")]
        public async Task<ResponseModel> AddUpdateInterview([FromForm]VmInterview obj)
        {
            var Data = _InterviewService.AddUpdateInterview(obj);
            return await System.Threading.Tasks.Task.FromResult(Data);
        }


        [HttpGet]
        [Route("GetAllInterview")]
        public async Task<ResponseModel> GetAllInterview()
        {
            var Data = _InterviewService.GetAllInterview();
            return await System.Threading.Tasks.Task.FromResult(Data);
        }

        [HttpGet]
        [Route("deleteInterview")]
        public async Task<ResponseModel> deleteInterview(int? Id)
        {
            var Data = _InterviewService.deleteInterview(Id);
            return await System.Threading.Tasks.Task.FromResult(Data);
        }

        [HttpPost]
        [Route("fileUploadInInterview")]
        public async Task<ResponseModel> fileUploadInInterview([FromForm] vmfileInfo obj)
        {
            var Data = _InterviewService.fileUploadInInterview(obj);
            return await System.Threading.Tasks.Task.FromResult(Data);
        }


        [HttpGet]
        [Route("GetInterviewDetailByInterviewId")]
        public async Task<ResponseModel> GetInterviewDetailByInterviewId(int? Id)
        {
            var Data = _InterviewService.GetInterviewDetailByInterviewId(Id);
            return await System.Threading.Tasks.Task.FromResult(Data);
        }

        [HttpPost]
        [Route("videoUploadInInterview")]
        public async Task<ResponseModel> videoUploadInInterview([FromForm] vmfileInfo obj)
        {
            var Data = _InterviewService.videoUploadInInterview(obj);
            return await System.Threading.Tasks.Task.FromResult(Data);
        }

        [HttpGet]
        [Route("deleteVideoInInterview")]
        public async Task<ResponseModel> deleteVideoInInterview(string oldVideoName)
        {
            var Data = _InterviewService.deleteVideoInInterview(oldVideoName);
            return await System.Threading.Tasks.Task.FromResult(Data);
        }
    }
}