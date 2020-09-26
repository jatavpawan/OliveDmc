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

    public class StudentCareerController : ControllerBase
    {
        private IStudentCareerService _StudentCareerService;
        public StudentCareerController(IStudentCareerService StudentCareerService)
        {
            _StudentCareerService = StudentCareerService;
        }

        [HttpPost]
        [Route("AddUpdateStudentCareer")]
        public async Task<ResponseModel> AddUpdateStudentCareer(StudentCareer obj)
        {
            var Data = _StudentCareerService.AddUpdateStudentCareer(obj);
            return await System.Threading.Tasks.Task.FromResult(Data);
        }


        [HttpGet]
        [Route("GetAllStudentCareer")]
        public async Task<ResponseModel> GetAllStudentCareer()
        {
            var Data = _StudentCareerService.GetAllStudentCareer();
            return await System.Threading.Tasks.Task.FromResult(Data);
        }

        [HttpGet]
        [Route("deleteStudentCareer")]
        public async Task<ResponseModel> deleteStudentCareer(int? Id)
        {
            var Data = _StudentCareerService.deleteStudentCareer(Id);
            return await System.Threading.Tasks.Task.FromResult(Data);
        }


        [HttpGet]
        [Route("GetStudentCareerById")]
        public async Task<ResponseModel> GetStudentCareerDetailByStudentCareerId(int? Id)
        {
            var Data = _StudentCareerService.GetStudentCareerById(Id);
            return await System.Threading.Tasks.Task.FromResult(Data);
        }
    }
}