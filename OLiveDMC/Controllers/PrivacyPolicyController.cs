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

    public class PrivacyPolicyController : ControllerBase
    {
        private IPrivacyPolicyService _PrivacyPolicyService;
        public PrivacyPolicyController(IPrivacyPolicyService PrivacyPolicyService)
        {
            _PrivacyPolicyService = PrivacyPolicyService;
        }

        [HttpPost]
        [Route("AddUpdatePrivacyPolicyDetail")]
        public async Task<ResponseModel> AddUpdatePrivacyPolicyDetail(PrivacyPolicy obj)
        {
            var Data = _PrivacyPolicyService.AddUpdatePrivacyPolicyDetail(obj);
            return await System.Threading.Tasks.Task.FromResult(Data);
        }

        [HttpGet]
        [Route("GetPrivacyPolicyDetail")]
        public async Task<ResponseModel> GetPrivacyPolicyDetail()
        {
            var Data = _PrivacyPolicyService.GetPrivacyPolicyDetail();
            return await System.Threading.Tasks.Task.FromResult(Data);
        }


        [HttpGet]
        [Route("deletePrivacyPolicyInfo")]
        public async Task<ResponseModel> deletePrivacyPolicyInfo(int? Id)
        {
            var Data = _PrivacyPolicyService.deletePrivacyPolicyInfo(Id);
            return await System.Threading.Tasks.Task.FromResult(Data);
        }



        [HttpPost]
        [Route("fileUploadInPrivacyPolicy")]
        public async Task<ResponseModel> fileUploadInPrivacyPolicy([FromForm] vmfileInfo obj)
        {
            var Data = _PrivacyPolicyService.fileUploadInPrivacyPolicy(obj);
            return await System.Threading.Tasks.Task.FromResult(Data);
        }


    }
}