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

    public class ProfileCategoryController : ControllerBase
    {
        private IProfileCategoryService _ProfileCategoryService;
        public ProfileCategoryController(IProfileCategoryService ProfileCategoryService)
        {
            _ProfileCategoryService = ProfileCategoryService;
        }

        [HttpPost]
        [Route("AddUpdateProfileCategory")]
        public async Task<ResponseModel> AddUpdateProfileCategory(ProfileCategory obj)
        {
            var Data = _ProfileCategoryService.AddUpdateProfileCategory(obj);
            return await System.Threading.Tasks.Task.FromResult(Data);
        }


        [HttpGet]
        [Route("GetAllProfileCategory")]
        public async Task<ResponseModel> GetAllProfileCategory()
        {
            var Data = _ProfileCategoryService.GetAllProfileCategory();
            return await System.Threading.Tasks.Task.FromResult(Data);
        }

        [HttpGet]
        [Route("deleteProfileCategory")]
        public async Task<ResponseModel> deleteProfileCategory(int? Id)
        {
            var Data = _ProfileCategoryService.deleteProfileCategory(Id);
            return await System.Threading.Tasks.Task.FromResult(Data);
        }


        [HttpGet]
        [Route("GetProfileCategoryById")]
        public async Task<ResponseModel> GetProfileCategoryDetailByProfileCategoryId(int? Id)
        {
            var Data = _ProfileCategoryService.GetProfileCategoryById(Id);
            return await System.Threading.Tasks.Task.FromResult(Data);
        }
    }
}