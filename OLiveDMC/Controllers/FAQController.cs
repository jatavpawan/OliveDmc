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
    public class FAQController : ControllerBase
    {
        private IFAQService _FAQService;
        public FAQController(IFAQService FAQService)
        {
            _FAQService = FAQService;
        }

        [HttpPost]
        [Route("AddUpdateFAQ")]
        public async Task<ResponseModel> AddUpdateFAQ(Faq obj)
        {
            var Data = _FAQService.AddUpdateFAQ(obj);
            return await System.Threading.Tasks.Task.FromResult(Data);
        }


        [HttpGet]
        [Route("GetAllFAQ")]
        public async Task<ResponseModel> GetAllFAQ()
        {
            var Data = _FAQService.GetAllFAQ();
            return await System.Threading.Tasks.Task.FromResult(Data);
        }

        [HttpGet]
        [Route("deleteFAQ")]
        public async Task<ResponseModel> deleteFAQ(int? Id)
        {
            var Data = _FAQService.deleteFAQ(Id);
            return await System.Threading.Tasks.Task.FromResult(Data);
        }

        [HttpPost]
        [Route("fileUploadInFAQ")]
        public async Task<ResponseModel> fileUploadInFAQ([FromForm] vmfileInfo obj)
        {
            var Data = _FAQService.fileUploadInFAQ(obj);
            return await System.Threading.Tasks.Task.FromResult(Data);
        }


        [HttpGet]
        [Route("GetFAQDetailByFAQId")]
        public async Task<ResponseModel> GetFAQDetailByFAQId(int? Id)
        {
            var Data = _FAQService.GetFAQDetailByFAQId(Id);
            return await System.Threading.Tasks.Task.FromResult(Data);
        }

     
    }
}