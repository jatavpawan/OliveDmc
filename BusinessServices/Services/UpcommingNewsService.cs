using BusinessDataModel.ViewModel;
using BusinessRespository.Infrastructure;
using BusinessServices.IServices;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessServices.Services
{
    public class UpcommingNewsService : IUpcommingNewsService
    {
        private IUnitOfWork _unitOfWork;
        public IHttpContextAccessor __httpContextaccessor;
        private ResponseModel response;

        public UpcommingNewsService(IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor)
        {
            _unitOfWork = unitOfWork;
            response = new ResponseModel();
            __httpContextaccessor = httpContextAccessor;
            //if (_httpContextaccessor.HttpContext.Session.GetString("Userdetail") != null)
            //    //{
            //    //    SessionUser = JsonConvert.DeserializeObject<Registration>(_httpContextaccessor.HttpContext.Session.GetString("Userdetail"));
            //    //}
        }

        public ResponseModel AddUpdateUpcommingNews(vmUpcommingNews obj)
        {
            try
            {
                ResponseModel result = new ResponseModel();
                result = _unitOfWork.UpcommingNewsRepository.AddUpdateUpcommingNews(obj);

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
        public ResponseModel GetAllUpcommingNews()
        {
            try
            {
                ResponseModel result = new ResponseModel();
                result = _unitOfWork.UpcommingNewsRepository.GetAllUpcommingNews();

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

        public ResponseModel deleteUpcommingNews(int? Id)
        {
            try
            {
                ResponseModel result = new ResponseModel();
                result = _unitOfWork.UpcommingNewsRepository.deleteUpcommingNews(Id);

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


        public ResponseModel fileUploadInUpcommingNews(vmfileInfo obj)
        {
            try
            {
                var resultValue = _unitOfWork.UpcommingNewsRepository.fileUploadInUpcommingNews(obj);
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


        public ResponseModel GetUpcommingNewsDetailByUpcommingNewsId(int? Id)
        {
            try
            {
                ResponseModel result = new ResponseModel();
                result = _unitOfWork.UpcommingNewsRepository.GetUpcommingNewsDetailByUpcommingNewsId(Id);

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

        public ResponseModel videoUploadInUpcommingNews(vmfileInfo obj)
        {
            try
            {
                var resultValue = _unitOfWork.UpcommingNewsRepository.videoUploadInUpcommingNews(obj);
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

        public ResponseModel deleteVideoInUpcommingNews(string oldVideoName)
        {
            try
            {
                _unitOfWork.UpcommingNewsRepository.deleteVideoInUpcommingNews(oldVideoName);
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
