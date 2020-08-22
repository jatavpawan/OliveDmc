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
    public class TeamMemberInAboutUsController : ControllerBase
    {
        private ITeamMemberInAboutUsService _TeamMemberInAboutUsService;
        public TeamMemberInAboutUsController(ITeamMemberInAboutUsService TeamMemberInAboutUsService)
        {
            _TeamMemberInAboutUsService = TeamMemberInAboutUsService;
        }

        [HttpPost]
        [Route("AddUpdateTeamMemberInAboutUs")]
        public async Task<ResponseModel> AddUpdateTeamMemberInAboutUs([FromForm]vmTeamMemberInAboutUs obj)
        {
            var Data = _TeamMemberInAboutUsService.AddUpdateTeamMemberInAboutUs(obj);
            return await System.Threading.Tasks.Task.FromResult(Data);
        }


        [HttpGet]
        [Route("GetAllTeamMemberInAboutUs")]
        public async Task<ResponseModel> GetAllTeamMemberInAboutUs()
        {
            var Data = _TeamMemberInAboutUsService.GetAllTeamMemberInAboutUs();
            return await System.Threading.Tasks.Task.FromResult(Data);
        }

        [HttpGet]
        [Route("deleteTeamMemberInAboutUs")]
        public async Task<ResponseModel> deleteTeamMemberInAboutUs(int? Id)
        {
            var Data = _TeamMemberInAboutUsService.deleteTeamMemberInAboutUs(Id);
            return await System.Threading.Tasks.Task.FromResult(Data);
        }

        [HttpPost]
        [Route("fileUploadInTeamMemberInAboutUs")]
        public async Task<ResponseModel> fileUploadInTeamMemberInAboutUs([FromForm] vmfileInfo obj)
        {
            var Data = _TeamMemberInAboutUsService.fileUploadInTeamMemberInAboutUs(obj);
            return await System.Threading.Tasks.Task.FromResult(Data);
        }


        [HttpGet]
        [Route("GetTeamMemberInAboutUsDetailByTeamMemberInAboutUsId")]
        public async Task<ResponseModel> GetTeamMemberInAboutUsDetailByTeamMemberInAboutUsId(int? Id)
        {
            var Data = _TeamMemberInAboutUsService.GetTeamMemberInAboutUsDetailByTeamMemberInAboutUsId(Id);
            return await System.Threading.Tasks.Task.FromResult(Data);
        }

        [HttpPost]
        [Route("videoUploadInTeamMemberInAboutUs")]
        public async Task<ResponseModel> videoUploadInTeamMemberInAboutUs([FromForm] vmfileInfo obj)
        {
            var Data = _TeamMemberInAboutUsService.videoUploadInTeamMemberInAboutUs(obj);
            return await System.Threading.Tasks.Task.FromResult(Data);
        }

        [HttpGet]
        [Route("deleteVideoInTeamMemberInAboutUs")]
        public async Task<ResponseModel> deleteVideoInTeamMemberInAboutUs(string oldVideoName)
        {
            var Data = _TeamMemberInAboutUsService.deleteVideoInTeamMemberInAboutUs(oldVideoName);
            return await System.Threading.Tasks.Task.FromResult(Data);
        }
        
        [HttpGet]
        [Route("GetAllTeamMemberinFrontEnd")]
        public async Task<ResponseModel> GetAllTeamMemberinFrontEnd()
        {
            var Data = _TeamMemberInAboutUsService.GetAllTeamMemberinFrontEnd();
            return await System.Threading.Tasks.Task.FromResult(Data);
        }
    }
}