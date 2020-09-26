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

    public class SkillsController : ControllerBase
    {
        private ISkillsService _SkillsService;
        public SkillsController(ISkillsService SkillsService)
        {
            _SkillsService = SkillsService;
        }

        [HttpPost]
        [Route("AddUpdateSkills")]
        public async Task<ResponseModel> AddUpdateSkills(Skills obj)
        {
            var Data = _SkillsService.AddUpdateSkills(obj);
            return await System.Threading.Tasks.Task.FromResult(Data);
        }


        [HttpGet]
        [Route("GetAllSkills")]
        public async Task<ResponseModel> GetAllSkills()
        {
            var Data = _SkillsService.GetAllSkills();
            return await System.Threading.Tasks.Task.FromResult(Data);
        }

        [HttpGet]
        [Route("deleteSkills")]
        public async Task<ResponseModel> deleteSkills(int? Id)
        {
            var Data = _SkillsService.deleteSkills(Id);
            return await System.Threading.Tasks.Task.FromResult(Data);
        }


        [HttpGet]
        [Route("GetSkillsById")]
        public async Task<ResponseModel> GetSkillsDetailBySkillsId(int? Id)
        {
            var Data = _SkillsService.GetSkillsById(Id);
            return await System.Threading.Tasks.Task.FromResult(Data);
        }
    }
}