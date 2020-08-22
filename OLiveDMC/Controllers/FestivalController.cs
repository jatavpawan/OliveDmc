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
    public class FestivalController : ControllerBase
    {
        private IFestivalService _FestivalService;
        public FestivalController(IFestivalService FestivalService)
        {
            _FestivalService = FestivalService;
        }

        [HttpPost]
        [Route("AddUpdateFestival")]
        public async Task<ResponseModel> AddUpdateFestival([FromForm]vmFestival obj)
        {
            var Data = _FestivalService.AddUpdateFestival(obj);
            return await System.Threading.Tasks.Task.FromResult(Data);
        }


        [HttpGet]
        [Route("GetAllFestival")]
        public async Task<ResponseModel> GetAllFestival()
        {
            var Data = _FestivalService.GetAllFestival();
            return await System.Threading.Tasks.Task.FromResult(Data);
        }

        [HttpGet]
        [Route("deleteFestival")]
        public async Task<ResponseModel> deleteFestival(int? Id)
        {
            var Data = _FestivalService.deleteFestival(Id);
            return await System.Threading.Tasks.Task.FromResult(Data);
        }

        [HttpPost]
        [Route("fileUploadInFestival")]
        public async Task<ResponseModel> fileUploadInFestival([FromForm] vmfileInfo obj)
        {
            var Data = _FestivalService.fileUploadInFestival(obj);
            return await System.Threading.Tasks.Task.FromResult(Data);
        }


        [HttpGet]
        [Route("GetFestivalDetailByFestivalId")]
        public async Task<ResponseModel> GetFestivalDetailByFestivalId(int? Id)
        {
            var Data = _FestivalService.GetFestivalDetailByFestivalId(Id);
            return await System.Threading.Tasks.Task.FromResult(Data);
        }

        [HttpPost]
        [Route("videoUploadInFestival")]
        public async Task<ResponseModel> videoUploadInFestival([FromForm] vmfileInfo obj)
        {
            var Data = _FestivalService.videoUploadInFestival(obj);
            return await System.Threading.Tasks.Task.FromResult(Data);
        }

        [HttpGet]
        [Route("deleteVideoInFestival")]
        public async Task<ResponseModel> deleteVideoInFestival(string oldVideoName)
        {
            var Data = _FestivalService.deleteVideoInFestival(oldVideoName);
            return await System.Threading.Tasks.Task.FromResult(Data);
        }

        [HttpGet]
        [Route("GetAllFestivainFrontEnd")]
        public async Task<ResponseModel> GetAllFestivainFrontEnd()
        {
            var Data = _FestivalService.GetAllFestivainFrontEnd();
            return await System.Threading.Tasks.Task.FromResult(Data);
        }
    }
}