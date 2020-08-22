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
    public class AboutUsIntroductionController : ControllerBase
    {
        private IAboutUsIntroductionService _AboutUsIntroductionService;
        public AboutUsIntroductionController(IAboutUsIntroductionService AboutUsIntroductionService)
        {
            _AboutUsIntroductionService = AboutUsIntroductionService;
        }

        [HttpPost]
        [Route("AddUpdateAboutUsIntroductionDetail")]
        public async Task<ResponseModel> AddUpdateAboutUsIntroductionDetail([FromForm]vmAboutUsIntroduction obj)
        {
            var Data = _AboutUsIntroductionService.AddUpdateAboutUsIntroductionDetail(obj);
            return await System.Threading.Tasks.Task.FromResult(Data);
        }

        [HttpGet]
        [Route("GetAboutUsIntroductionDetail")]
        public async Task<ResponseModel> GetAboutUsIntroductionDetail()
        {
            var Data = _AboutUsIntroductionService.GetAboutUsIntroductionDetail();
            return await System.Threading.Tasks.Task.FromResult(Data);
        }


        [HttpGet]
        [Route("deleteAboutUsIntroductionInfo")]
        public async Task<ResponseModel> deleteAboutUsIntroductionInfo(int? Id)
        {
            var Data = _AboutUsIntroductionService.deleteAboutUsIntroductionInfo(Id);
            return await System.Threading.Tasks.Task.FromResult(Data);
        }



        [HttpPost]
        [Route("fileUploadInAboutUsIntroduction")]
        public async Task<ResponseModel> fileUploadInAboutUsIntroduction([FromForm] vmfileInfo obj)
        {
            var Data = _AboutUsIntroductionService.fileUploadInAboutUsIntroduction(obj);
            return await System.Threading.Tasks.Task.FromResult(Data);
        }


    }
}