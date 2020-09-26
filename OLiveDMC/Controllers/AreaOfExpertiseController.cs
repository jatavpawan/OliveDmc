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

    public class AreaOfExpertiseController : ControllerBase
    {
        private IAreaOfExpertiseService _AreaOfExpertiseService;
        public AreaOfExpertiseController(IAreaOfExpertiseService AreaOfExpertiseService)
        {
            _AreaOfExpertiseService = AreaOfExpertiseService;
        }

        [HttpPost]
        [Route("AddUpdateAreaOfExpertise")]
        public async Task<ResponseModel> AddUpdateAreaOfExpertise(AreaOfExpertise obj)
        {
            var Data = _AreaOfExpertiseService.AddUpdateAreaOfExpertise(obj);
            return await System.Threading.Tasks.Task.FromResult(Data);
        }


        [HttpGet]
        [Route("GetAllAreaOfExpertise")]
        public async Task<ResponseModel> GetAllAreaOfExpertise()
        {
            var Data = _AreaOfExpertiseService.GetAllAreaOfExpertise();
            return await System.Threading.Tasks.Task.FromResult(Data);
        }

        [HttpGet]
        [Route("deleteAreaOfExpertise")]
        public async Task<ResponseModel> deleteAreaOfExpertise(int? Id)
        {
            var Data = _AreaOfExpertiseService.deleteAreaOfExpertise(Id);
            return await System.Threading.Tasks.Task.FromResult(Data);
        }


        [HttpGet]
        [Route("GetAreaOfExpertiseById")]
        public async Task<ResponseModel> GetAreaOfExpertiseDetailByAreaOfExpertiseId(int? Id)
        {
            var Data = _AreaOfExpertiseService.GetAreaOfExpertiseById(Id);
            return await System.Threading.Tasks.Task.FromResult(Data);
        }
    }
}