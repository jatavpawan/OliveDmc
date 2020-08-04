using BusinessDataModel.ViewModel;
using BusinessRespository.Infrastructure;
using BusinessServices.IServices;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessServices.Services
{
    public class TrendingNewsService: ITrendingNewsService
    {
        private IUnitOfWork _unitOfWork;
        public IHttpContextAccessor __httpContextaccessor;
        private ResponseModel response;

        public TrendingNewsService(IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor)
        {
            _unitOfWork = unitOfWork;
            response = new ResponseModel();
            __httpContextaccessor = httpContextAccessor;
            //if (_httpContextaccessor.HttpContext.Session.GetString("Userdetail") != null)
            //    //{
            //    //    SessionUser = JsonConvert.DeserializeObject<Registration>(_httpContextaccessor.HttpContext.Session.GetString("Userdetail"));
            //    //}
        }

        public ResponseModel AddUpdateTrendingNews(VmTrendingNews obj)
        {
            try
            {
                ResponseModel result = new ResponseModel();
                result = _unitOfWork.TrendingNewsRepository.AddUpdateTrendingNews(obj);

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
        public ResponseModel GetAllTrendingNews()
        {
            try
            {
                ResponseModel result = new ResponseModel();
                result = _unitOfWork.TrendingNewsRepository.GetAllTrendingNews();

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

        public ResponseModel deleteTrendingNews(int? Id)
        {
            try
            {
                ResponseModel result = new ResponseModel();
                result = _unitOfWork.TrendingNewsRepository.deleteTrendingNews(Id);

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


        public ResponseModel fileUploadInTrendingNews(vmfileInfo obj)
        {
            try
            {
                var resultValue = _unitOfWork.TrendingNewsRepository.fileUploadInTrendingNews(obj);
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


        public ResponseModel GetTrendingNewsDetailByTrendingNewsId(int? Id)
        {
            try
            {
                ResponseModel result = new ResponseModel();
                result = _unitOfWork.TrendingNewsRepository.GetTrendingNewsDetailByTrendingNewsId(Id);

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

        public ResponseModel videoUploadInTrendingNews(vmfileInfo obj)
        {
            try
            {
                var resultValue = _unitOfWork.TrendingNewsRepository.videoUploadInTrendingNews(obj);
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

        public ResponseModel deleteVideoInTrendingNews(string oldVideoName)
        {
            try
            {
                _unitOfWork.TrendingNewsRepository.deleteVideoInTrendingNews(oldVideoName);
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
