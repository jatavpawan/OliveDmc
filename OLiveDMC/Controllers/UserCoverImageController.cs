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
    public class UserCoverImageController : ControllerBase
    {
        private IUserCoverImageService _UserCoverImageService;
        public UserCoverImageController(IUserCoverImageService UserCoverImageService)
        {
            _UserCoverImageService = UserCoverImageService;
        }

        [HttpPost]
        [Route("AddUpdateUserCoverImage")]
        public async Task<ResponseModel> AddUpdateUserCoverImage([FromForm]vmUserCoverImage obj)
        {
            var Data = _UserCoverImageService.AddUpdateUserCoverImage(obj);
            return await System.Threading.Tasks.Task.FromResult(Data);
        }


        [HttpGet]
        [Route("GetAllUserCoverImage")]
        public async Task<ResponseModel> GetAllUserCoverImage()
        {
            var Data = _UserCoverImageService.GetAllUserCoverImage();
            return await System.Threading.Tasks.Task.FromResult(Data);
        }

        [HttpGet]
        [Route("deleteUserCoverImage")]
        public async Task<ResponseModel> deleteUserCoverImage(int? Id)
        {
            var Data = _UserCoverImageService.deleteUserCoverImage(Id);
            return await System.Threading.Tasks.Task.FromResult(Data);
        }


        [HttpGet]
        [Route("GetUserCoverImageByUserId")]
        public async Task<ResponseModel> GetUserCoverImageByUserId(int? Id)
        {
            var Data = _UserCoverImageService.GetUserCoverImageByUserId(Id);
            return await System.Threading.Tasks.Task.FromResult(Data);
        }

    }
}