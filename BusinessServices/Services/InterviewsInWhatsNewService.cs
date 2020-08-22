using BusinessDataModel.ViewModel;
using BusinessRespository.Infrastructure;
using BusinessServices.IServices;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessServices.Services
{
    public class InterviewsInWhatsNewService : IInterviewsInWhatsNewService
    {
        private IUnitOfWork _unitOfWork;
        public IHttpContextAccessor __httpContextaccessor;
        private ResponseModel response;

        public InterviewsInWhatsNewService(IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor)
        {
            _unitOfWork = unitOfWork;
            response = new ResponseModel();
            __httpContextaccessor = httpContextAccessor;
            //if (_httpContextaccessor.HttpContext.Session.GetString("Userdetail") != null)
            //    //{
            //    //    SessionUser = JsonConvert.DeserializeObject<Registration>(_httpContextaccessor.HttpContext.Session.GetString("Userdetail"));
            //    //}
        }

        public ResponseModel AddUpdateInterviewsInWhatsNew(vmInterviewsInWhatsNew obj)
        {
            try
            {
                ResponseModel result = new ResponseModel();
                result = _unitOfWork.InterviewsInWhatsNewRepository.AddUpdateInterviewsInWhatsNew(obj);

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
        public ResponseModel GetAllInterviewsInWhatsNew()
        {
            try
            {
                ResponseModel result = new ResponseModel();
                result = _unitOfWork.InterviewsInWhatsNewRepository.GetAllInterviewsInWhatsNew();

                response.data = result.data;
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

        public ResponseModel deleteInterviewsInWhatsNew(int? Id)
        {
            try
            {
                ResponseModel result = new ResponseModel();
                result = _unitOfWork.InterviewsInWhatsNewRepository.deleteInterviewsInWhatsNew(Id);

                response.data = result.data;
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


        public ResponseModel fileUploadInInterviewsInWhatsNew(vmfileInfo obj)
        {
            try
            {
                var resultValue = _unitOfWork.InterviewsInWhatsNewRepository.fileUploadInInterviewsInWhatsNew(obj);
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


        public ResponseModel GetInterviewsInWhatsNewDetailByInterviewsId(int? Id)
        {
            try
            {
                ResponseModel result = new ResponseModel();
                result = _unitOfWork.InterviewsInWhatsNewRepository.GetInterviewsInWhatsNewDetailByInterviewsId(Id);

                response.data = result.data;
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

        public ResponseModel videoUploadInInterviewsInWhatsNew(vmfileInfo obj)
        {
            try
            {
                var resultValue = _unitOfWork.InterviewsInWhatsNewRepository.videoUploadInInterviewsInWhatsNew(obj);
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

        public ResponseModel deleteVideoInInterviewsInWhatsNew(string oldVideoName)
        {
            try
            {
                _unitOfWork.InterviewsInWhatsNewRepository.deleteVideoInInterviewsInWhatsNew(oldVideoName);
                response.status = Status.Success;
                response.message = "file Delete Successfully";

            }
            catch (Exception ex)
            {
                response.data = ex.Message;
                response.status = Status.Error;
                response.message = "Execption Occured.";
            }
            return response;
        }
        public ResponseModel GetAllInterviewsInWhatsNewFrontEnd()
        {
            try
            {
                ResponseModel result = new ResponseModel();
                result = _unitOfWork.InterviewsInWhatsNewRepository.GetAllInterviewsInWhatsNewFrontEnd();

                response.data = result.data;
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
    }
}
