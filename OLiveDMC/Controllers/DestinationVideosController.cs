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
    public class DestinationVideosController : ControllerBase
    {
        private IDestinationVideosService _DestinationVideosService;
        public DestinationVideosController(IDestinationVideosService DestinationVideosService)
        {
            _DestinationVideosService = DestinationVideosService;
        }

        [HttpPost]
        [Route("AddUpdateDestinationVideos")]
        public async Task<ResponseModel> AddUpdateDestinationVideos([FromForm]VmDestinationVideos obj)
        {
            var Data = _DestinationVideosService.AddUpdateDestinationVideos(obj);
            return await System.Threading.Tasks.Task.FromResult(Data);
        }


        [HttpGet]
        [Route("GetAllDestinationVideos")]
        public async Task<ResponseModel> GetAllDestinationVideos()
        {
            var Data = _DestinationVideosService.GetAllDestinationVideos();
            return await System.Threading.Tasks.Task.FromResult(Data);
        }

        [HttpGet]
        [Route("deleteDestinationVideos")]
        public async Task<ResponseModel> deleteDestinationVideos(int? Id)
        {
            var Data = _DestinationVideosService.deleteDestinationVideos(Id);
            return await System.Threading.Tasks.Task.FromResult(Data);
        }

       
        [HttpGet]
        [Route("GetDestinationVideosDetailByDestinationVideosId")]
        public async Task<ResponseModel> GetDestinationVideosDetailByDestinationVideosId(int? Id)
        {
            var Data = _DestinationVideosService.GetDestinationVideosDetailByDestinationVideosId(Id);
            return await System.Threading.Tasks.Task.FromResult(Data);
        }

        [HttpPost]
        [Route("videoUploadInDestinationVideos")]
        public async Task<ResponseModel> videoUploadInDestinationVideos([FromForm] vmfileInfo obj)
        {
            var Data = _DestinationVideosService.videoUploadInDestinationVideos(obj);
            return await System.Threading.Tasks.Task.FromResult(Data);
        }

        [HttpGet]
        [Route("deleteVideoInDestinationVideos")]
        public async Task<ResponseModel> deleteVideoInDestinationVideos(string oldVideoName)
        {
            var Data = _DestinationVideosService.deleteVideoInDestinationVideos(oldVideoName);
            return await System.Threading.Tasks.Task.FromResult(Data);
        }
    }
}