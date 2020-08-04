using BusinessDataModel.ViewModel;
using BusinessRespository.Infrastructure;
using BusinessServices.IServices;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessServices.Services
{
    public class TopDestinationService: ITopDestinationService
    {
        private IUnitOfWork _unitOfWork;
        public IHttpContextAccessor __httpContextaccessor;
        private ResponseModel response;

        public TopDestinationService(IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor)
        {
            _unitOfWork = unitOfWork;
            response = new ResponseModel();
            __httpContextaccessor = httpContextAccessor;
            //if (_httpContextaccessor.HttpContext.Session.GetString("Userdetail") != null)
            //    //{
            //    //    SessionUser = JsonConvert.DeserializeObject<Registration>(_httpContextaccessor.HttpContext.Session.GetString("Userdetail"));
            //    //}
        }

        public ResponseModel AddUpdateTopDestination(VmTopDestination obj)
        {
            try
            {
                ResponseModel result = new ResponseModel();
                result = _unitOfWork.TopDestinationRepository.AddUpdateTopDestination(obj);

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
        public ResponseModel GetAllTopDestination()
        {
            try
            {
                ResponseModel result = new ResponseModel();
                result = _unitOfWork.TopDestinationRepository.GetAllTopDestination();

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

        public ResponseModel deleteTopDestination(int? Id)
        {
            try
            {
                ResponseModel result = new ResponseModel();
                result = _unitOfWork.TopDestinationRepository.deleteTopDestination(Id);

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


        public ResponseModel fileUploadInTopDestination(vmfileInfo obj)
        {
            try
            {
                var resultValue = _unitOfWork.TopDestinationRepository.fileUploadInTopDestination(obj);
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


        public ResponseModel GetTopDestinationDetailByTopDestinationId(int? Id)
        {
            try
            {
                ResponseModel result = new ResponseModel();
                result = _unitOfWork.TopDestinationRepository.GetTopDestinationDetailByTopDestinationId(Id);

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

        public ResponseModel videoUploadInTopDestination(vmfileInfo obj)
        {
            try
            {
                var resultValue = _unitOfWork.TopDestinationRepository.videoUploadInTopDestination(obj);
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

        public ResponseModel deleteVideoInTopDestination(string oldVideoName)
        {
            try
            {
                _unitOfWork.TopDestinationRepository.deleteVideoInTopDestination(oldVideoName);
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

        

        public ResponseModel GetTopDestinationByCountryId(int? CountryId)
        {
            try
            {
                ResponseModel result = new ResponseModel();
                result = _unitOfWork.TopDestinationRepository.GetTopDestinationByCountryId(CountryId);

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
