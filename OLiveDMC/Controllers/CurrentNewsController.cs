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
    public class CurrentNewsController : ControllerBase
    {
        private ICurrentNewsService _currentNewsService;
        public CurrentNewsController(ICurrentNewsService CurrentNewsService)
        {
            _currentNewsService = CurrentNewsService;
        }

        [HttpPost]
        [Route("AddUpdateCurrentNews")]
        public async Task<ResponseModel> AddUpdateCurrentNews([FromForm]vmCurrentNews obj)
        {
            var Data = _currentNewsService.AddUpdateCurrentNews(obj);
            return await System.Threading.Tasks.Task.FromResult(Data);
        }


        [HttpGet]
        [Route("GetAllCurrentNews")]
        public async Task<ResponseModel> GetAllCurrentNews()
        {
            var Data = _currentNewsService.GetAllCurrentNews();
            return await System.Threading.Tasks.Task.FromResult(Data);
        }

        [HttpGet]
        [Route("deleteCurrentNews")]
        public async Task<ResponseModel> deleteCurrentNews(int? Id)
        {
            var Data = _currentNewsService.deleteCurrentNews(Id);
            return await System.Threading.Tasks.Task.FromResult(Data);
        }

        [HttpPost]
        [Route("fileUploadInCurrentNews")]
        public async Task<ResponseModel> fileUploadInCurrentNews([FromForm] vmfileInfo obj)
        {
            var Data = _currentNewsService.fileUploadInCurrentNews(obj);
            return await System.Threading.Tasks.Task.FromResult(Data);
        }


        [HttpGet]
        [Route("GetCurrentNewsDetailByCurrentNewsId")]
        public async Task<ResponseModel> GetCurrentNewsDetailByCurrentNewsId(int? Id)
        {
            var Data = _currentNewsService.GetCurrentNewsDetailByCurrentNewsId(Id);
            return await System.Threading.Tasks.Task.FromResult(Data);
        }


        [HttpPost]
        [Route("videoUploadInCurrentNews")]
        public async Task<ResponseModel> videoUploadInCurrentNews([FromForm] vmfileInfo obj)
        {
            var Data = _currentNewsService.videoUploadInCurrentNews(obj);
            return await System.Threading.Tasks.Task.FromResult(Data);
        }

        [HttpGet]
        [Route("deleteVideoInCurrentNews")]
        public async Task<ResponseModel> deleteVideoInCurrentNews(string oldVideoName)
        {
            var Data = _currentNewsService.deleteVideoInCurrentNews(oldVideoName);
            return await System.Threading.Tasks.Task.FromResult(Data);
        }
    }
}