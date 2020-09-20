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
    public class AboutUsController : ControllerBase
    {
        private IAboutUsService _aboutUsService;
        public AboutUsController(IAboutUsService aboutUsService)
        {
            _aboutUsService = aboutUsService;
        }

        [HttpPost]
        [Route("AddUpdateAboutUsDetail")]
        public async Task<ResponseModel> AddUpdateAboutUsDetail(AboutUs obj)
        {
            var Data = _aboutUsService.AddUpdateAboutUsDetail(obj);
            return await System.Threading.Tasks.Task.FromResult(Data);
        }

        //[HttpPost]
        //[Route("SaveAboutUsDetail")]
        //public async Task<ResponseModel> SaveAboutUsDetail(vmAboutUsDetail obj)
        //{
        //    var Data = _aboutUsService.SaveAboutUsDetail(obj);
        //    return await System.Threading.Tasks.Task.FromResult(Data);
        //}


        [HttpGet]
        [Route("GetAboutUsDetail")]
        public async Task<ResponseModel> GetAboutUsDetail()
        {
            var Data = _aboutUsService.GetAboutUsDetail();
            return await System.Threading.Tasks.Task.FromResult(Data);
        }


        [HttpGet]
        [Route("deleteAboutUsInfo")] 
        public async Task<ResponseModel> deleteAboutUsInfo(int? Id)
        {
            var Data = _aboutUsService.deleteAboutUsInfo(Id);
            return await System.Threading.Tasks.Task.FromResult(Data);
        }



        [HttpPost]
        [Route("fileUploadInAboutUs")]
        public async Task<ResponseModel> fileUploadInAboutUs([FromForm] vmfileInfo obj)
        {
            var Data = _aboutUsService.fileUploadInAboutUs(obj);
            return await System.Threading.Tasks.Task.FromResult(Data);
        }

        [HttpGet]
        [Route("forgotpassword")]
        public async Task<ResponseModel> forgotpassword()
        {
            var Data = _aboutUsService.forgotpassword();
            return await System.Threading.Tasks.Task.FromResult(Data);
        }


    }
}