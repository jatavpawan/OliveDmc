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

    public class ProfessionalCareerController : ControllerBase
    {
        private IProfessionalCareerService _ProfessionalCareerService;
        public ProfessionalCareerController(IProfessionalCareerService ProfessionalCareerService)
        {
            _ProfessionalCareerService = ProfessionalCareerService;
        }

        [HttpPost]
        [Route("AddUpdateProfessionalCareer")]
        public async Task<ResponseModel> AddUpdateProfessionalCareer([FromForm] vmProfessionalCareer obj)
        {
            var Data = _ProfessionalCareerService.AddUpdateProfessionalCareer(obj);
            return await System.Threading.Tasks.Task.FromResult(Data);
        }


        [HttpGet]
        [Route("GetAllProfessionalCareer")]
        public async Task<ResponseModel> GetAllProfessionalCareer()
        {
            var Data = _ProfessionalCareerService.GetAllProfessionalCareer();
            return await System.Threading.Tasks.Task.FromResult(Data);
        }

        [HttpGet]
        [Route("deleteProfessionalCareer")]
        public async Task<ResponseModel> deleteProfessionalCareer(int? Id)
        {
            var Data = _ProfessionalCareerService.deleteProfessionalCareer(Id);
            return await System.Threading.Tasks.Task.FromResult(Data);
        }


        [HttpGet]
        [Route("GetProfessionalCareerById")]
        public async Task<ResponseModel> GetProfessionalCareerDetailByProfessionalCareerId(int? Id)
        {
            var Data = _ProfessionalCareerService.GetProfessionalCareerById(Id);
            return await System.Threading.Tasks.Task.FromResult(Data);
        }
    }
}