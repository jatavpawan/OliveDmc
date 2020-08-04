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
    public class UpcommingNewsController : ControllerBase
    {
        private IUpcommingNewsService _upcommingNewsService;
        public UpcommingNewsController(IUpcommingNewsService UpcommingNewsService)
        {
            _upcommingNewsService = UpcommingNewsService;
        }

        [HttpPost]
        [Route("AddUpdateUpcommingNews")]
        public async Task<ResponseModel> AddUpdateUpcommingNews([FromForm]vmUpcommingNews obj)
        {
            var Data = _upcommingNewsService.AddUpdateUpcommingNews(obj);
            return await System.Threading.Tasks.Task.FromResult(Data);
        }


        [HttpGet]
        [Route("GetAllUpcommingNews")]
        public async Task<ResponseModel> GetAllUpcommingNews()
        {
            var Data = _upcommingNewsService.GetAllUpcommingNews();
            return await System.Threading.Tasks.Task.FromResult(Data);
        }

        [HttpGet]
        [Route("deleteUpcommingNews")]
        public async Task<ResponseModel> deleteUpcommingNews(int? Id)
        {
            var Data = _upcommingNewsService.deleteUpcommingNews(Id);
            return await System.Threading.Tasks.Task.FromResult(Data);
        }

        [HttpPost]
        [Route("fileUploadInUpcommingNews")]
        public async Task<ResponseModel> fileUploadInUpcommingNews([FromForm] vmfileInfo obj)
        {
            var Data = _upcommingNewsService.fileUploadInUpcommingNews(obj);
            return await System.Threading.Tasks.Task.FromResult(Data);
        }


        [HttpGet]
        [Route("GetUpcommingNewsDetailByUpcommingNewsId")]
        public async Task<ResponseModel> GetUpcommingNewsDetailByUpcommingNewsId(int? Id)
        {
            var Data = _upcommingNewsService.GetUpcommingNewsDetailByUpcommingNewsId(Id);
            return await System.Threading.Tasks.Task.FromResult(Data);
        }


        [HttpPost]
        [Route("videoUploadInUpcommingNews")]
        public async Task<ResponseModel> videoUploadInUpcommingNews([FromForm] vmfileInfo obj)
        {
            var Data = _upcommingNewsService.videoUploadInUpcommingNews(obj);
            return await System.Threading.Tasks.Task.FromResult(Data);
        }

        [HttpGet]
        [Route("deleteVideoInUpcommingNews")]
        public async Task<ResponseModel> deleteVideoInUpcommingNews(string oldVideoName)
        {
            var Data = _upcommingNewsService.deleteVideoInUpcommingNews(oldVideoName);
            return await System.Threading.Tasks.Task.FromResult(Data);
        }
    }
}