//using BusinessEntities.Account;
//using BusinessRespository.Infrastructure;
using BusinessServices.IServices;
//using DataModel.ViewModel;
//using Microsoft.AspNetCore.Http;
//using Microsoft.Extensions.Configuration;
//using Newtonsoft.Json;
//using System;
//using System.Collections.Generic;
//using System.Text;

namespace BusinessServices.Services
{
    public class AboutService: IAboutService
    {
        //private IUnitOfWork _unitOfWork;
        //public IHttpContextAccessor _httpContextaccessor;
        //private LoginPerson SessionUser;
        //public IConnectionService _connectionService;
        //public IConfiguration _configuration;
        //public AboutService(IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor, IConnectionService connectionService, IConfiguration configuration)
        //{
        //    _unitOfWork = unitOfWork;
        //    _httpContextaccessor = httpContextAccessor;
        //    _connectionService = connectionService;
        //    _configuration = configuration;
        //    if (_httpContextaccessor.HttpContext.Session.GetString("Userdetail") != null)
        //    {
        //        SessionUser = JsonConvert.DeserializeObject<LoginPerson>(_httpContextaccessor.HttpContext.Session.GetString("Userdetail"));
        //    }
        //}

        //public ResponseModel send(RegisterViewModel obj)
        //{

        //    ResponseModel response = new ResponseModel();
        //    try
        //    {
        //        StringBuilder sb = new StringBuilder();
        //        sb.Append("<b>Full Name:</b> " + obj.Name);
        //        sb.Append("<br/><br/>");
        //        sb.Append("<b>Job Title:</b> " + obj.Job);
        //        sb.Append("<br/><br/>");
        //        sb.Append("<b>District/School Name:</b> " + obj.District);
        //        sb.Append("<br/><br/>");
        //        sb.Append("<b>Telephone:</b> " + obj.Phone);
        //        sb.Append("<br/><br/>");
        //        sb.Append("<b>Email Address:</b> " + obj.Email);
        //        sb.Append("<br/><br/>");
        //        sb.Append("<b>Zip Code:</b> " + obj.Zip);
        //        sb.Append("<br/><br/>");
        //        sb.Append("<b>Comments:</b> " + obj.comments);
        //        sb.Append("<br/><br/>");
        //        EZSchoolMail mail = new EZSchoolMail(_configuration);
        //        mail.SendUsingEZSchoolMailDomain("sales@ezschoolapps.com", "", "", "EZ School Apps – Contact Sales", sb.ToString(), "", "", "", "", null, null);
        //        string DistrictId = string.Empty;
        //        _unitOfWork = _connectionService.GetDynamicConnection(DistrictId);
        //        response.data = _unitOfWork.AboutRepository.AddMail(obj.Email,obj.Job);
        //        response.message = "done";
        //        response.status = Status.Success;
        //    }
        //    catch (Exception ex)
        //    {
        //        response.message = ex.Message;
        //        response.status = Status.Error;
        //    }
        //    return response;

        //}
    }
}
