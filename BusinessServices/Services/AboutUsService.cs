using BusinessDataModel.DB;
using BusinessDataModel.ViewModel;
using BusinessRespository.Infrastructure;
using BusinessServices.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace BusinessServices.Services
{ 
    public class AboutUsService : IAboutUsService
    {
        private IUnitOfWork _unitOfWork;
        public IHttpContextAccessor __httpContextaccessor;
        private ResponseModel response;

        public AboutUsService(IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor)
        {
            _unitOfWork = unitOfWork;
            response = new ResponseModel();
            __httpContextaccessor = httpContextAccessor;
            //if (_httpContextaccessor.HttpContext.Session.GetString("Userdetail") != null)
            //    //{
            //    //    SessionUser = JsonConvert.DeserializeObject<Registration>(_httpContextaccessor.HttpContext.Session.GetString("Userdetail"));
            //    //}
        }

        public ResponseModel AddUpdateAboutUsDetail(AboutUs obj)
        {
            try
            {
                ResponseModel result = new ResponseModel();
                result =_unitOfWork.AboutUsRepository.AddUpdateAboutUsDetail(obj);

                response.status = result.status;
                response.message = result.message;

            }
            catch (Exception ex)
            {
                response.message = ex.Message;
                response.status = Status.Error;
            }
            return response;
        }

        public ResponseModel GetAboutUsDetail()
        {
            try
            {
                var resultValue = _unitOfWork.AboutUsRepository.GetAboutUsDetail();
                response.data = resultValue;
                response.status = Status.Success;
                //response.message = "About Us Listing";

            }
            catch (Exception ex)
            {
                response.message = ex.Message;
                response.status = Status.Error;
            }
            return response;
        }

        public ResponseModel deleteAboutUsInfo(int? Id)
        {
            try
            {
                var resultValue = _unitOfWork.AboutUsRepository.deleteAboutUsInfo(Id);
                if (resultValue != null)
                {
                    response.status = Status.Success;
                    response.data = resultValue;
                    response.message = "About Us Information Deleted Successfully";
                }
            }
            catch (Exception ex)
            {
                response.data = ex.Message;
                response.status = Status.Error;
                response.message = "Execption Occured.";
            }
            return response;
        }

        public ResponseModel fileUploadInAboutUs(vmfileInfo obj)
        {
            try
            {
                var resultValue = _unitOfWork.AboutUsRepository.fileUploadInAboutUs(obj);
                if (resultValue != null)
                {
                    response.status = Status.Success;
                    response.data = resultValue;
                    response.message = "file saved";
                }
            }
            catch (Exception ex)
            {
                response.data = ex.Message;
                response.status = Status.Error;
                response.message = "Execption Occured.";
            }
            return response;
        }
        

        public ResponseModel forgotpassword()
        {
            try
            {
                var resultValue = _unitOfWork.AboutUsRepository.forgotpassword();
                if (resultValue != null)
                {
                    response.status = Status.Success;
                    response.data = resultValue;
                    response.message = "About Us Information Deleted Successfully";
                }
            }
            catch (Exception ex)
            {
                response.data = ex.Message;
                response.status = Status.Error;
                response.message = "Execption Occured.";
            }
            return response;
        }


    }
}
