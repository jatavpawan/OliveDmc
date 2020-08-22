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
    public class UserPersonalInfoController : ControllerBase
    {
        private IUserPersonalInfoService _UserPersonalInfoService;
        public UserPersonalInfoController(IUserPersonalInfoService UserPersonalInfoService)
        {
            _UserPersonalInfoService = UserPersonalInfoService;
        }

        [HttpPost]
        [Route("AddUpdateUserPersonalInfo")]
        public async Task<ResponseModel> AddUpdateUserPersonalInfo([FromForm]vmUserPersonalInfo obj)
        {
            var Data = _UserPersonalInfoService.AddUpdateUserPersonalInfo(obj);
            return await System.Threading.Tasks.Task.FromResult(Data);
        }


        [HttpGet]
        [Route("GetAllUserPersonalInfo")]
        public async Task<ResponseModel> GetAllUserPersonalInfo()
        {
            var Data = _UserPersonalInfoService.GetAllUserPersonalInfo();
            return await System.Threading.Tasks.Task.FromResult(Data);
        }

        [HttpGet]
        [Route("deleteUserPersonalInfo")]
        public async Task<ResponseModel> deleteUserPersonalInfo(int? Id)
        {
            var Data = _UserPersonalInfoService.deleteUserPersonalInfo(Id);
            return await System.Threading.Tasks.Task.FromResult(Data);
        }



        [HttpGet]
        [Route("GetUserPersonalInfoByUserId")]
        public async Task<ResponseModel> GetUserPersonalInfoByUserId(int? Id)
        {
            var Data = _UserPersonalInfoService.GetUserPersonalInfoByUserId(Id);
            return await System.Threading.Tasks.Task.FromResult(Data);
        }

        [HttpPost]
        [Route("AddUpdateUserProfileImage")]
        public async Task<ResponseModel> AddUpdateUserProfileImage([FromForm]vmUserProfileImage obj)
        {
            var Data = _UserPersonalInfoService.AddUpdateUserProfileImage(obj);
            return await System.Threading.Tasks.Task.FromResult(Data);
        }


        [HttpPost]
        [Route("AddUpdateUserAboutDescription")]
        public async Task<ResponseModel> AddUpdateUserAboutDescription(vmUserAboutDescription obj)
        {
            var Data = _UserPersonalInfoService.AddUpdateUserAboutDescription(obj);
            return await System.Threading.Tasks.Task.FromResult(Data);
        }


        [HttpPost]
        [Route("AddUpdateUserCoverImage")]
        public async Task<ResponseModel> AddUpdateUserCoverImage([FromForm]vmUserCoverImg obj)
        {
            var Data = _UserPersonalInfoService.AddUpdateUserCoverImage(obj);
            return await System.Threading.Tasks.Task.FromResult(Data);
        }


    }
}