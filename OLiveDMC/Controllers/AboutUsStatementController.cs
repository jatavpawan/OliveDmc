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
    public class AboutUsStatementController : ControllerBase
    {
        private IAboutUsStatementService _AboutUsStatementService;
        public AboutUsStatementController(IAboutUsStatementService AboutUsStatementService)
        {
            _AboutUsStatementService = AboutUsStatementService;
        }

        [HttpPost]
        [Route("AddUpdateAboutUsStatement")]
        public async Task<ResponseModel> AddUpdateAboutUsStatement([FromForm]vmAboutUsStatement obj)
        {
            var Data = _AboutUsStatementService.AddUpdateAboutUsStatement(obj);
            return await System.Threading.Tasks.Task.FromResult(Data);
        }


        [HttpGet]
        [Route("GetAllAboutUsStatement")]
        public async Task<ResponseModel> GetAllAboutUsStatement()
        {
            var Data = _AboutUsStatementService.GetAllAboutUsStatement();
            return await System.Threading.Tasks.Task.FromResult(Data);
        }

        [HttpGet]
        [Route("deleteAboutUsStatement")]
        public async Task<ResponseModel> deleteAboutUsStatement(int? Id)
        {
            var Data = _AboutUsStatementService.deleteAboutUsStatement(Id);
            return await System.Threading.Tasks.Task.FromResult(Data);
        }

        [HttpPost]
        [Route("fileUploadInAboutUsStatement")]
        public async Task<ResponseModel> fileUploadInAboutUsStatement([FromForm] vmfileInfo obj)
        {
            var Data = _AboutUsStatementService.fileUploadInAboutUsStatement(obj);
            return await System.Threading.Tasks.Task.FromResult(Data);
        }


        [HttpGet]
        [Route("GetAboutUsStatementDetailByAboutUsStatementId")]
        public async Task<ResponseModel> GetAboutUsStatementDetailByAboutUsStatementId(int? Id)
        {
            var Data = _AboutUsStatementService.GetAboutUsStatementDetailByAboutUsStatementId(Id);
            return await System.Threading.Tasks.Task.FromResult(Data);
        }

        [HttpPost]
        [Route("videoUploadInAboutUsStatement")]
        public async Task<ResponseModel> videoUploadInAboutUsStatement([FromForm] vmfileInfo obj)
        {
            var Data = _AboutUsStatementService.videoUploadInAboutUsStatement(obj);
            return await System.Threading.Tasks.Task.FromResult(Data);
        }

        [HttpGet]
        [Route("deleteVideoInAboutUsStatement")]
        public async Task<ResponseModel> deleteVideoInAboutUsStatement(string oldVideoName)
        {
            var Data = _AboutUsStatementService.deleteVideoInAboutUsStatement(oldVideoName);
            return await System.Threading.Tasks.Task.FromResult(Data);
        }

        [HttpGet]
        [Route("GetAllAboutUsStatementinFrontEnd")]
        public async Task<ResponseModel> GetAllAboutUsStatementinFrontEnd()
        {
            var Data = _AboutUsStatementService.GetAllAboutUsStatementinFrontEnd();
            return await System.Threading.Tasks.Task.FromResult(Data);
        }
    }
}