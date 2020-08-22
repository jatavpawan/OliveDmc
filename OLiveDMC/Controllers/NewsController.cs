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
    public class NewsController : ControllerBase
    {
        private INewsService _newsService;
        public NewsController(INewsService NewsService)
        {
            _newsService = NewsService;
        }

        [HttpPost]
        [Route("AddUpdateNews")]
        public async Task<ResponseModel> AddUpdateNews([FromForm]vmNews obj)
        {
            var Data = _newsService.AddUpdateNews(obj);
            return await System.Threading.Tasks.Task.FromResult(Data);
        }


        [HttpGet]
        [Route("GetAllNews")]
        public async Task<ResponseModel> GetAllNews()
        {
            var Data = _newsService.GetAllNews();
            return await System.Threading.Tasks.Task.FromResult(Data);
        }

        [HttpGet]
        [Route("deleteNews")]
        public async Task<ResponseModel> deleteNews(int? Id)
        {
            var Data = _newsService.deleteNews(Id);
            return await System.Threading.Tasks.Task.FromResult(Data);
        }

        [HttpPost]
        [Route("fileUploadInNews")]
        public async Task<ResponseModel> fileUploadInNews([FromForm] vmfileInfo obj)
        {
            var Data = _newsService.fileUploadInNews(obj);
            return await System.Threading.Tasks.Task.FromResult(Data);
        }


        [HttpGet]
        [Route("GetNewsDetailByNewsId")]
        public async Task<ResponseModel> GetNewsDetailByNewsId(int? Id)
        {
            var Data = _newsService.GetNewsDetailByNewsId(Id);
            return await System.Threading.Tasks.Task.FromResult(Data);
        }

        [HttpPost]
        [Route("videoUploadInNews")]
        public async Task<ResponseModel> videoUploadInNews([FromForm] vmfileInfo obj)
        {
            var Data = _newsService.videoUploadInNews(obj);
            return await System.Threading.Tasks.Task.FromResult(Data);
        }

        [HttpGet]
        [Route("deleteVideoInNews")]
        public async Task<ResponseModel> deleteVideoInNews(string oldVideoName)
        {
            var Data = _newsService.deleteVideoInNews(oldVideoName);
            return await System.Threading.Tasks.Task.FromResult(Data);
        }

        [HttpGet]
        [Route("GetAllNewsinFrontEnd")]
        public async Task<ResponseModel> GetAllNewsinFrontEnd()
        {
            var Data = _newsService.GetAllNewsinFrontEnd();
            return await System.Threading.Tasks.Task.FromResult(Data);
        }
    }
}