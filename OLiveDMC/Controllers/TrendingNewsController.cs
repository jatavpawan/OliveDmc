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
    public class TrendingNewsController : ControllerBase
    {
        private ITrendingNewsService _TrendingNewsService;
        public TrendingNewsController(ITrendingNewsService TrendingNewsService)
        {
            _TrendingNewsService = TrendingNewsService;
        }

        [HttpPost]
        [Route("AddUpdateTrendingNews")]
        public async Task<ResponseModel> AddUpdateTrendingNews([FromForm]VmTrendingNews obj)
        {
            var Data = _TrendingNewsService.AddUpdateTrendingNews(obj);
            return await System.Threading.Tasks.Task.FromResult(Data);
        }


        [HttpGet]
        [Route("GetAllTrendingNews")]
        public async Task<ResponseModel> GetAllTrendingNews()
        {
            var Data = _TrendingNewsService.GetAllTrendingNews();
            return await System.Threading.Tasks.Task.FromResult(Data);
        }

        [HttpGet]
        [Route("deleteTrendingNews")]
        public async Task<ResponseModel> deleteTrendingNews(int? Id)
        {
            var Data = _TrendingNewsService.deleteTrendingNews(Id);
            return await System.Threading.Tasks.Task.FromResult(Data);
        }

        [HttpPost]
        [Route("fileUploadInTrendingNews")]
        public async Task<ResponseModel> fileUploadInTrendingNews([FromForm] vmfileInfo obj)
        {
            var Data = _TrendingNewsService.fileUploadInTrendingNews(obj);
            return await System.Threading.Tasks.Task.FromResult(Data);
        }


        [HttpGet]
        [Route("GetTrendingNewsDetailByTrendingNewsId")]
        public async Task<ResponseModel> GetTrendingNewsDetailByTrendingNewsId(int? Id)
        {
            var Data = _TrendingNewsService.GetTrendingNewsDetailByTrendingNewsId(Id);
            return await System.Threading.Tasks.Task.FromResult(Data);
        }

        [HttpPost]
        [Route("videoUploadInTrendingNews")]
        public async Task<ResponseModel> videoUploadInTrendingNews([FromForm] vmfileInfo obj)
        {
            var Data = _TrendingNewsService.videoUploadInTrendingNews(obj);
            return await System.Threading.Tasks.Task.FromResult(Data);
        }

        [HttpGet]
        [Route("deleteVideoInTrendingNews")]
        public async Task<ResponseModel> deleteVideoInTrendingNews(string oldVideoName)
        {
            var Data = _TrendingNewsService.deleteVideoInTrendingNews(oldVideoName);
            return await System.Threading.Tasks.Task.FromResult(Data);
        }
    }
}