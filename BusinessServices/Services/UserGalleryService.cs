using BusinessDataModel.ViewModel;
using BusinessRespository.Infrastructure;
using BusinessServices.IServices;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessServices.Services
{
    public class UserGalleryService : IUserGalleryService
    {
        private IUnitOfWork _unitOfWork;
        public IHttpContextAccessor __httpContextaccessor;
        private ResponseModel response;

        public UserGalleryService(IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor)
        {
            _unitOfWork = unitOfWork;
            response = new ResponseModel();
            __httpContextaccessor = httpContextAccessor;
            //if (_httpContextaccessor.HttpContext.Session.GetString("Userdetail") != null)
            //    //{
            //    //    SessionUser = JsonConvert.DeserializeObject<Registration>(_httpContextaccessor.HttpContext.Session.GetString("Userdetail"));
            //    //}
        }

        public ResponseModel AddUpdateUserGallery(vmUserGallery obj)
        {
            try
            {
                ResponseModel result = new ResponseModel();
                result = _unitOfWork.UserGalleryRepository.AddUpdateUserGallery(obj);

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
        public ResponseModel GetAllUserGallery()
        {
            try
            {
                ResponseModel result = new ResponseModel();
                result = _unitOfWork.UserGalleryRepository.GetAllUserGallery();

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

        public ResponseModel deleteUserGallery(int? Id)
        {
            try
            {
                ResponseModel result = new ResponseModel();
                result = _unitOfWork.UserGalleryRepository.deleteUserGallery(Id);

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
               
        public ResponseModel GetUserGalleryById(int? Id)
        {
            try
            {
                ResponseModel result = new ResponseModel();
                result = _unitOfWork.UserGalleryRepository.GetUserGalleryById(Id);

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

        public ResponseModel videoUploadInUserGallery(vmfileInfo obj)
        {
            try
            {
                var resultValue = _unitOfWork.UserGalleryRepository.videoUploadInUserGallery(obj);
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

        public ResponseModel deleteVideoInUserGallery(string oldVideoName)
        {
            try
            {
                _unitOfWork.UserGalleryRepository.deleteVideoInUserGallery(oldVideoName);
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

        public ResponseModel GetAllUserGalleryByUserId(int? userId)
        {
            try
            {
                ResponseModel result = new ResponseModel();
                result = _unitOfWork.UserGalleryRepository.GetAllUserGalleryByUserId(userId);

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

        public ResponseModel userReactOnGallery(vmUserGalleryReaction obj)
        {
            try
            {
                ResponseModel result = new ResponseModel();
                result = _unitOfWork.UserGalleryRepository.userReactOnGallery(obj);

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


        public ResponseModel userCommentOnGallery(vmGalleryComment obj)
        {
            try
            {
                ResponseModel result = new ResponseModel();
                result = _unitOfWork.UserGalleryRepository.userCommentOnGallery(obj);

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

        public ResponseModel reactOnGalleryComment(vmGalleryCommentReaction obj)
        {
            try
            {
                ResponseModel result = new ResponseModel();
                result = _unitOfWork.UserGalleryRepository.reactOnGalleryComment(obj);

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

        public ResponseModel GalleryDetailByUserId(int? galleryId)
        {
            try
            {
                ResponseModel result = new ResponseModel();
                result = _unitOfWork.UserGalleryRepository.GalleryDetailByUserId(galleryId);

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


