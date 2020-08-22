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
    public class ContactUsController : ControllerBase
    {
        private IContactUsService _ContactUsService;
        public ContactUsController(IContactUsService ContactUsService)
        {
            _ContactUsService = ContactUsService;
        }

        [HttpPost]
        [Route("AddUpdateContactUs")]
        public async Task<ResponseModel> AddUpdateContactUs(ContactUs obj)
        {
            var Data = _ContactUsService.AddUpdateContactUs(obj);
            return await System.Threading.Tasks.Task.FromResult(Data);
        }


        [HttpGet]
        [Route("GetAllContactUs")]
        public async Task<ResponseModel> GetAllContactUs()
        {
            var Data = _ContactUsService.GetAllContactUs();
            return await System.Threading.Tasks.Task.FromResult(Data);
        }

        [HttpGet]
        [Route("deleteContactUs")]
        public async Task<ResponseModel> deleteContactUs(int? Id)
        {
            var Data = _ContactUsService.deleteContactUs(Id);
            return await System.Threading.Tasks.Task.FromResult(Data);
        }


        [HttpGet]
        [Route("GetContactUsDetailById")]
        public async Task<ResponseModel> GetContactUsDetailById(int? Id)
        {
            var Data = _ContactUsService.GetContactUsDetailById(Id);
            return await System.Threading.Tasks.Task.FromResult(Data);
        }

    }
}