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
    public class TourThemeController : ControllerBase
    {
            private ITourThemeService _tourThemeService;
            public TourThemeController(ITourThemeService tourThemeService)
            {
              _tourThemeService = tourThemeService;
            }

        [HttpPost]
        [Route("AddUpdateTheme")]
        public async Task<ResponseModel> AddUpdateTheme([FromForm]vmTourTheme obj)
        {
            var Data = _tourThemeService.AddUpdateTheme(obj);
            return await System.Threading.Tasks.Task.FromResult(Data);
        }


        [HttpGet]
        [Route("GetAllTheme")]
        public async Task<ResponseModel> GetAllTheme()
        {
            var Data = _tourThemeService.GetAllTheme();
            return await System.Threading.Tasks.Task.FromResult(Data);
        }

        [HttpGet]
        [Route("deleteTourTheme")]
        public async Task<ResponseModel> deleteTourTheme(int? Id)
        {
            var Data = _tourThemeService.deleteTourTheme(Id);
            return await System.Threading.Tasks.Task.FromResult(Data);
        }

        [HttpPost]
        [Route("fileUploadInTourTheme")]
        public async Task<ResponseModel> fileUploadInTourTheme([FromForm] vmfileInfo obj)
        {
            var Data = _tourThemeService.fileUploadInTourTheme(obj);
            return await System.Threading.Tasks.Task.FromResult(Data);
        }

        [HttpGet]
        [Route("GetThemeDetailByThemeId")]
        public async Task<ResponseModel> GetThemeDetailByThemeId(int? Id)
        {
            var Data = _tourThemeService.GetThemeDetailByThemeId(Id);
            return await System.Threading.Tasks.Task.FromResult(Data);
        }

        [HttpPost]
        [Route("videoUploadInTheme")]
        public async Task<ResponseModel> videoUploadInTheme([FromForm] vmfileInfo obj)
        {
            var Data = _tourThemeService.videoUploadInTheme(obj);
            return await System.Threading.Tasks.Task.FromResult(Data);
        }


        [HttpGet]
        [Route("deleteVideoInTheme")]
        public async Task<ResponseModel> deleteVideoInTheme(string oldVideoName)
        {
            var Data = _tourThemeService.deleteVideoInTheme(oldVideoName);
            return await System.Threading.Tasks.Task.FromResult(Data);
        }

    }
}