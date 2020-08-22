using BusinessDataModel.DB;
using BusinessDataModel.ViewModel;
using BusinessRespository.Infrastructure;
using BusinessServices.IServices;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessServices.Services
{
    public class AboutUsIntroductionService : IAboutUsIntroductionService
    {
        private IUnitOfWork _unitOfWork;
        public IHttpContextAccessor __httpContextaccessor;
        private ResponseModel response;

        public AboutUsIntroductionService(IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor)
        {
            _unitOfWork = unitOfWork;
            response = new ResponseModel();
            __httpContextaccessor = httpContextAccessor;
            //if (_httpContextaccessor.HttpContext.Session.GetString("Userdetail") != null)
            //    //{
            //    //    SessionUser = JsonConvert.DeserializeObject<Registration>(_httpContextaccessor.HttpContext.Session.GetString("Userdetail"));
            //    //}
        }

        public ResponseModel AddUpdateAboutUsIntroductionDetail(vmAboutUsIntroduction obj)
        {
            try
            {
                ResponseModel result = new ResponseModel();
                result = _unitOfWork.AboutUsIntroductionRepository.AddUpdateAboutUsIntroductionDetail(obj);

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

        public ResponseModel GetAboutUsIntroductionDetail()
        {
            try
            {
                var resultValue = _unitOfWork.AboutUsIntroductionRepository.GetAboutUsIntroductionDetail();
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

        public ResponseModel deleteAboutUsIntroductionInfo(int? Id)
        {
            try
            {
                var resultValue = _unitOfWork.AboutUsIntroductionRepository.deleteAboutUsIntroductionInfo(Id);
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

        public ResponseModel fileUploadInAboutUsIntroduction(vmfileInfo obj)
        {
            try
            {
                var resultValue = _unitOfWork.AboutUsIntroductionRepository.fileUploadInAboutUsIntroduction(obj);
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




    }
}

