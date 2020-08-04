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
    public class DestinationService : IDestinationService
    {
        private IUnitOfWork _unitOfWork;
        public IHttpContextAccessor __httpContextaccessor;
        private ResponseModel response;

        public DestinationService(IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor)
        {
            _unitOfWork = unitOfWork;
            response = new ResponseModel();
            __httpContextaccessor = httpContextAccessor;
            //if (_httpContextaccessor.HttpContext.Session.GetString("Userdetail") != null)
            //    //{
            //    //    SessionUser = JsonConvert.DeserializeObject<Registration>(_httpContextaccessor.HttpContext.Session.GetString("Userdetail"));
            //    //}
        }

        public ResponseModel AddUpdateDestinationInCountry(Destination obj)
        {
            try
            {
                ResponseModel result = new ResponseModel();
                result = _unitOfWork.DestinationRepository.AddUpdateDestinationInCountry(obj);

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

        public ResponseModel GetCountryInfoByCountryCode(string countryCode)
        {
            try
            {
                ResponseModel result = new ResponseModel();
                result = _unitOfWork.DestinationRepository.GetCountryInfoByCountryCode(countryCode);
                response = result;

            }
            catch (Exception ex)
            {
                response.message = ex.Message;
                response.status = Status.Error;
            }
            return response;
        }

        public ResponseModel deleteCountryInfoById(int? Id)
        {
            try
            {
                ResponseModel result = new ResponseModel();
                result = _unitOfWork.DestinationRepository.deleteCountryInfoById(Id);

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

        public ResponseModel GetAllDestinationCountry()
        {
            try
            {
                ResponseModel result = new ResponseModel();
                result = _unitOfWork.DestinationRepository.GetAllDestinationCountry();

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

        public ResponseModel fileUploadInDestination(vmfileInfo obj)
        {
            try
            {
                var resultValue = _unitOfWork.DestinationRepository.fileUploadInDestination(obj);
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

        public ResponseModel videoUploadInDestination(vmfileInfo obj)
        {
            try
            {
                var resultValue = _unitOfWork.DestinationRepository.videoUploadInDestination(obj);
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
