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
    public class NewDestinationsInWhatsNewController : ControllerBase
    {
        private INewDestinationsInWhatsNewService _NewDestinationsInWhatsNewService;
        public NewDestinationsInWhatsNewController(INewDestinationsInWhatsNewService NewDestinationsInWhatsNewService)
        {
            _NewDestinationsInWhatsNewService = NewDestinationsInWhatsNewService;
        }

        [HttpPost]
        [Route("AddUpdateNewDestinationsInWhatsNew")]
        public async Task<ResponseModel> AddUpdateNewDestinationsInWhatsNew([FromForm]vmNewDestinationsInWhatsNew obj)
        {
            var Data = _NewDestinationsInWhatsNewService.AddUpdateNewDestinationsInWhatsNew(obj);
            return await System.Threading.Tasks.Task.FromResult(Data);
        }


        [HttpGet]
        [Route("GetAllNewDestinationsInWhatsNew")]
        public async Task<ResponseModel> GetAllNewDestinationsInWhatsNew()
        {
            var Data = _NewDestinationsInWhatsNewService.GetAllNewDestinationsInWhatsNew();
            return await System.Threading.Tasks.Task.FromResult(Data);
        }

        [HttpGet]
        [Route("deleteNewDestinationsInWhatsNew")]
        public async Task<ResponseModel> deleteNewDestinationsInWhatsNew(int? Id)
        {
            var Data = _NewDestinationsInWhatsNewService.deleteNewDestinationsInWhatsNew(Id);
            return await System.Threading.Tasks.Task.FromResult(Data);
        }

        [HttpPost]
        [Route("fileUploadInNewDestinationsInWhatsNew")]
        public async Task<ResponseModel> fileUploadInNewDestinationsInWhatsNew([FromForm] vmfileInfo obj)
        {
            var Data = _NewDestinationsInWhatsNewService.fileUploadInNewDestinationsInWhatsNew(obj);
            return await System.Threading.Tasks.Task.FromResult(Data);
        }


        [HttpGet]
        [Route("GetNewDestinationsInWhatsNewDetailByDestinationsId")]
        public async Task<ResponseModel> GetNewDestinationsInWhatsNewDetailByDestinationsId(int? Id)
        {
            var Data = _NewDestinationsInWhatsNewService.GetNewDestinationsInWhatsNewDetailByDestinationsId(Id);
            return await System.Threading.Tasks.Task.FromResult(Data);
        }

        [HttpPost]
        [Route("videoUploadInNewDestinationsInWhatsNew")]
        public async Task<ResponseModel> videoUploadInNewDestinationsInWhatsNew([FromForm] vmfileInfo obj)
        {
            var Data = _NewDestinationsInWhatsNewService.videoUploadInNewDestinationsInWhatsNew(obj);
            return await System.Threading.Tasks.Task.FromResult(Data);
        }

        [HttpGet]
        [Route("deleteVideoInNewDestinationsInWhatsNew")]
        public async Task<ResponseModel> deleteVideoInNewDestinationsInWhatsNew(string oldVideoName)
        {
            var Data = _NewDestinationsInWhatsNewService.deleteVideoInNewDestinationsInWhatsNew(oldVideoName);
            return await System.Threading.Tasks.Task.FromResult(Data);
        }

        [HttpGet]
        [Route("GetAllNewDestinationsInWhatsNewFrontEnd")]
        public async Task<ResponseModel> GetAllNewDestinationsInWhatsNewFrontEnd()
        {
            var Data = _NewDestinationsInWhatsNewService.GetAllNewDestinationsInWhatsNewFrontEnd();
            return await System.Threading.Tasks.Task.FromResult(Data);
        }
    }
}