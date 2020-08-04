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
    public class BannerController : ControllerBase
    {
        private IBannerService _bannerService;
        public BannerController(IBannerService bannerService)
        {
            _bannerService = bannerService;
        }

        [HttpPost]
        [Route("AddUpdateBanner")]
        public async Task<ResponseModel> AddUpdateBanner([FromForm]vmBanner obj)
        {
            var Data = _bannerService.AddUpdateBanner(obj);
            return await System.Threading.Tasks.Task.FromResult(Data);
        }


        [HttpGet]
        [Route("GetAllBanner")]
        public async Task<ResponseModel> GetAllBanner()
        {
            var Data = _bannerService.GetAllBanner();
            return await System.Threading.Tasks.Task.FromResult(Data);
        }

        [HttpGet]
        [Route("deleteBanner")]
        public async Task<ResponseModel> deleteBanner(int? Id)
        {
            var Data = _bannerService.deleteBanner(Id);
            return await System.Threading.Tasks.Task.FromResult(Data);
        }

        [HttpPost]
        [Route("fileUploadInBanner")]
        public async Task<ResponseModel> fileUploadInBanner([FromForm] vmfileInfo obj)
        {
            var Data = _bannerService.fileUploadInBanner(obj);
            return await System.Threading.Tasks.Task.FromResult(Data);
        }

        [HttpGet]
        [Route("GetBannerDetailByBannerId")]
        public async Task<ResponseModel> GetBannerDetailByBannerId(int? Id)
        {
            var Data = _bannerService.GetBannerDetailByBannerId(Id);
            return await System.Threading.Tasks.Task.FromResult(Data);
        }
    }
}