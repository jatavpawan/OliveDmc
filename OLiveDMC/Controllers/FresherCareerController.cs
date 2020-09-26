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

    public class FresherCareerController : ControllerBase
    {
        private IFresherCareerService _FresherCareerService;
        public FresherCareerController(IFresherCareerService FresherCareerService)
        {
            _FresherCareerService = FresherCareerService;
        }

        [HttpPost]
        [Route("AddUpdateFresherCareer")]
        public async Task<ResponseModel> AddUpdateFresherCareer([FromForm] vmFresherCareer obj)
        {
            var Data = _FresherCareerService.AddUpdateFresherCareer(obj);
            return await System.Threading.Tasks.Task.FromResult(Data);
        }


        [HttpGet]
        [Route("GetAllFresherCareer")]
        public async Task<ResponseModel> GetAllFresherCareer()
        {
            var Data = _FresherCareerService.GetAllFresherCareer();
            return await System.Threading.Tasks.Task.FromResult(Data);
        }

        [HttpGet]
        [Route("deleteFresherCareer")]
        public async Task<ResponseModel> deleteFresherCareer(int? Id)
        {
            var Data = _FresherCareerService.deleteFresherCareer(Id);
            return await System.Threading.Tasks.Task.FromResult(Data);
        }


        [HttpGet]
        [Route("GetFresherCareerById")]
        public async Task<ResponseModel> GetFresherCareerDetailByFresherCareerId(int? Id)
        {
            var Data = _FresherCareerService.GetFresherCareerById(Id);
            return await System.Threading.Tasks.Task.FromResult(Data);
        }
    }
}