using BusinessDataModel.ViewModel;
using BusinessRespository.Infrastructure;
using BusinessServices.IServices;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessServices.Services
{

    public class NewDestinationsInWhatsNewService : INewDestinationsInWhatsNewService
    {
        private IUnitOfWork _unitOfWork;
        public IHttpContextAccessor __httpContextaccessor;
        private ResponseModel response;

        public NewDestinationsInWhatsNewService(IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor)
        {
            _unitOfWork = unitOfWork;
            response = new ResponseModel();
            __httpContextaccessor = httpContextAccessor;
            //if (_httpContextaccessor.HttpContext.Session.GetString("Userdetail") != null)
            //    //{
            //    //    SessionUser = JsonConvert.DeserializeObject<Registration>(_httpContextaccessor.HttpContext.Session.GetString("Userdetail"));
            //    //}
        }

        public ResponseModel AddUpdateNewDestinationsInWhatsNew(vmNewDestinationsInWhatsNew obj)
        {
            try
            {
                ResponseModel result = new ResponseModel();
                result = _unitOfWork.NewDestinationsInWhatsNewRepository.AddUpdateNewDestinationsInWhatsNew(obj);

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
        public ResponseModel GetAllNewDestinationsInWhatsNew()
        {
            try
            {
                ResponseModel result = new ResponseModel();
                result = _unitOfWork.NewDestinationsInWhatsNewRepository.GetAllNewDestinationsInWhatsNew();

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

        public ResponseModel deleteNewDestinationsInWhatsNew(int? Id)
        {
            try
            {
                ResponseModel result = new ResponseModel();
                result = _unitOfWork.NewDestinationsInWhatsNewRepository.deleteNewDestinationsInWhatsNew(Id);

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


        public ResponseModel fileUploadInNewDestinationsInWhatsNew(vmfileInfo obj)
        {
            try
            {
                var resultValue = _unitOfWork.NewDestinationsInWhatsNewRepository.fileUploadInNewDestinationsInWhatsNew(obj);
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


        public ResponseModel GetNewDestinationsInWhatsNewDetailByDestinationsId(int? Id)
        {
            try
            {
                ResponseModel result = new ResponseModel();
                result = _unitOfWork.NewDestinationsInWhatsNewRepository.GetNewDestinationsInWhatsNewDetailByDestinationsId(Id);

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

        public ResponseModel videoUploadInNewDestinationsInWhatsNew(vmfileInfo obj)
        {
            try
            {
                var resultValue = _unitOfWork.NewDestinationsInWhatsNewRepository.videoUploadInNewDestinationsInWhatsNew(obj);
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

        public ResponseModel deleteVideoInNewDestinationsInWhatsNew(string oldVideoName)
        {
            try
            {
                _unitOfWork.NewDestinationsInWhatsNewRepository.deleteVideoInNewDestinationsInWhatsNew(oldVideoName);
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

        public ResponseModel GetAllNewDestinationsInWhatsNewFrontEnd()
        {
            try
            {
                ResponseModel result = new ResponseModel();
                result = _unitOfWork.NewDestinationsInWhatsNewRepository.GetAllNewDestinationsInWhatsNewFrontEnd();

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
