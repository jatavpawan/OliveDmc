using BusinessDataModel.ViewModel;
using BusinessRespository.Infrastructure;
using BusinessServices.IServices;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessServices.Services
{
    public class EventService : IEventService
    {
        private IUnitOfWork _unitOfWork;
        public IHttpContextAccessor __httpContextaccessor;
        private ResponseModel response;

        public EventService(IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor)
        {
            _unitOfWork = unitOfWork;
            response = new ResponseModel();
            __httpContextaccessor = httpContextAccessor;
            //if (_httpContextaccessor.HttpContext.Session.GetString("Userdetail") != null)
            //    //{
            //    //    SessionUser = JsonConvert.DeserializeObject<Registration>(_httpContextaccessor.HttpContext.Session.GetString("Userdetail"));
            //    //}
        }

        public ResponseModel AddUpdateEvent(vmEvent obj)
        {
            try
            {
                ResponseModel result = new ResponseModel();
                result = _unitOfWork.EventRepository.AddUpdateEvent(obj);

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
        public ResponseModel GetAllEvent()
        {
            try
            {
                ResponseModel result = new ResponseModel();
                result = _unitOfWork.EventRepository.GetAllEvent();

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

        public ResponseModel deleteEvent(int? Id)
        {
            try
            {
                ResponseModel result = new ResponseModel();
                result = _unitOfWork.EventRepository.deleteEvent(Id);

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


        public ResponseModel fileUploadInEvent(vmfileInfo obj)
        {
            try
            {
                var resultValue = _unitOfWork.EventRepository.fileUploadInEvent(obj);
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


        public ResponseModel GetEventDetailByEventId(int? Id)
        {
            try
            {
                ResponseModel result = new ResponseModel();
                result = _unitOfWork.EventRepository.GetEventDetailByEventId(Id);

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

        public ResponseModel videoUploadInEvent(vmfileInfo obj)
        {
            try
            {
                var resultValue = _unitOfWork.EventRepository.videoUploadInEvent(obj);
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

        public ResponseModel deleteVideoInEvent(string oldVideoName)
        {
            try
            {
                _unitOfWork.EventRepository.deleteVideoInEvent(oldVideoName);
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
    }
}
