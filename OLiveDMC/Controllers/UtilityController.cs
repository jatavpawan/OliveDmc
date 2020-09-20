using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessDataModel.ViewModel;
using BusinessServices.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OLiveDMC.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UtilityController : ControllerBase
    {
        private IUtilityService _UtilityService;
        public UtilityController(IUtilityService UtilityService)
        {
            _UtilityService = UtilityService;
        }

        [HttpPost]
        [Route("AddUpdateUtility")]
        public async Task<ResponseModel> AddUpdateUtility([FromForm]vmUtility obj)
        {
            var Data = _UtilityService.AddUpdateUtility(obj);
            return await System.Threading.Tasks.Task.FromResult(Data);
        }


        [HttpGet]
        [Route("GetAllUtility")]
        public async Task<ResponseModel> GetAllUtility()
        {
            var Data = _UtilityService.GetAllUtility();
            return await System.Threading.Tasks.Task.FromResult(Data);
        }

        [HttpGet]
        [Route("deleteUtility")]
        public async Task<ResponseModel> deleteUtility(int? Id)
        {
            var Data = _UtilityService.deleteUtility(Id);
            return await System.Threading.Tasks.Task.FromResult(Data);
        }

        [HttpPost]
        [Route("fileUploadInUtility")]
        public async Task<ResponseModel> fileUploadInUtility([FromForm] vmfileInfo obj)
        {
            var Data = _UtilityService.fileUploadInUtility(obj);
            return await System.Threading.Tasks.Task.FromResult(Data);
        }

        [HttpGet]
        [Route("getUtilityDetailByUtilityType")]
        public async Task<ResponseModel> getUtilityDetailByUtilityType(string UtilityType)
        {
            var Data = _UtilityService.getUtilityDetailByUtilityType(UtilityType);
            return await System.Threading.Tasks.Task.FromResult(Data);
        }

        [HttpGet]
        [Route("getUtilityDetailById")]
        public async Task<ResponseModel> getUtilityDetailById(int? UtilityId)
        {
            var Data = _UtilityService.getUtilityDetailById(UtilityId);
            return await System.Threading.Tasks.Task.FromResult(Data);
        }

        [HttpGet]
        [Route("deleteVideoInUtility")]
        public async Task<ResponseModel> deleteVideoInUtility(string oldVideoName)
        {
            var Data = _UtilityService.deleteVideoInUtility(oldVideoName);
            return await System.Threading.Tasks.Task.FromResult(Data);
        }

        [HttpPost]
        [Route("videoUploadInUtility")]
        public async Task<ResponseModel> videoUploadInUtility([FromForm] vmfileInfo obj)
        {
            var Data = _UtilityService.videoUploadInUtility(obj);
            return await System.Threading.Tasks.Task.FromResult(Data);
        }
     


    }
}