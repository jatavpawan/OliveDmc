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
    public class BannerService : IBannerService
    {
        private IUnitOfWork _unitOfWork;
        public IHttpContextAccessor __httpContextaccessor;
        private ResponseModel response;

        public BannerService(IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor)
        {
            _unitOfWork = unitOfWork;
            response = new ResponseModel();
            __httpContextaccessor = httpContextAccessor;
            //if (_httpContextaccessor.HttpContext.Session.GetString("Userdetail") != null)
            //    //{
            //    //    SessionUser = JsonConvert.DeserializeObject<Registration>(_httpContextaccessor.HttpContext.Session.GetString("Userdetail"));
            //    //}
        }

        public ResponseModel AddUpdateBanner(vmBanner obj)
        {
            try
            {
                ResponseModel result = new ResponseModel();
                result = _unitOfWork.BannerRepository.AddUpdateBanner(obj);

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
        public ResponseModel GetAllBanner()
        {
            try
            {
                ResponseModel result = new ResponseModel();
                result = _unitOfWork.BannerRepository.GetAllBanner();

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

        public ResponseModel deleteBanner(int? Id)
        {
            try
            {
                ResponseModel result = new ResponseModel();
                result = _unitOfWork.BannerRepository.deleteBanner(Id);

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


        public ResponseModel fileUploadInBanner(vmfileInfo obj)
        {
            try
            {
                var resultValue = _unitOfWork.BannerRepository.fileUploadInBanner(obj);
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


     

        public ResponseModel GetBannerDetailByBannerId(int? Id)
        {
            try
            {
                ResponseModel result = new ResponseModel();
                result = _unitOfWork.BannerRepository.GetBannerDetailByBannerId(Id);

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
