using BusinessDataModel.ViewModel;
using BusinessRespository.Infrastructure;
using BusinessServices.IServices;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessServices.Services
{
    public class UserPostService : IUserPostService
    {
        private IUnitOfWork _unitOfWork;
        public IHttpContextAccessor __httpContextaccessor;
        private ResponseModel response;

        public UserPostService(IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor)
        {
            _unitOfWork = unitOfWork;
            response = new ResponseModel();
            __httpContextaccessor = httpContextAccessor;
            //if (_httpContextaccessor.HttpContext.Session.GetString("Userdetail") != null)
            //    //{
            //    //    SessionUser = JsonConvert.DeserializeObject<Registration>(_httpContextaccessor.HttpContext.Session.GetString("Userdetail"));
            //    //}
        }

        public ResponseModel AddUpdateUserPost(vmUserPost obj)
        {
            try
            {
                ResponseModel result = new ResponseModel();
                result = _unitOfWork.UserPostRepository.AddUpdateUserPost(obj);

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
        public ResponseModel GetAllUserPost()
        {
            try
            {
                ResponseModel result = new ResponseModel();
                result = _unitOfWork.UserPostRepository.GetAllUserPost();

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

        public ResponseModel deleteUserPost(int? Id)
        {
            try
            {
                ResponseModel result = new ResponseModel();
                result = _unitOfWork.UserPostRepository.deleteUserPost(Id);

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


        public ResponseModel fileUploadInUserPost(vmfileInfo obj)
        {
            try
            {
                var resultValue = _unitOfWork.UserPostRepository.fileUploadInUserPost(obj);
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


        public ResponseModel GetUserPostDetailByUserPostId(int? Id)
        {
            try
            {
                ResponseModel result = new ResponseModel();
                result = _unitOfWork.UserPostRepository.GetUserPostDetailByUserPostId(Id);

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

        public ResponseModel videoUploadInUserPost(vmfileInfo obj)
        {
            try
            {
                var resultValue = _unitOfWork.UserPostRepository.videoUploadInUserPost(obj);
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

        public ResponseModel deleteVideoInUserPost(string oldVideoName)
        {
            try
            {
                _unitOfWork.UserPostRepository.deleteVideoInUserPost(oldVideoName);
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

        public ResponseModel GetAllUserPostByUserId(int? userId)
        {
            try
            {
                ResponseModel result = new ResponseModel();
                result = _unitOfWork.UserPostRepository.GetAllUserPostByUserId(userId);

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
       

         public ResponseModel userReactOnPost(vmUserPostReaction obj)
        {
            try
            {
                ResponseModel result = new ResponseModel();
                result = _unitOfWork.UserPostRepository.userReactOnPost(obj);

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


        public ResponseModel userCommentOnPost(vmPostComment obj)
        {
            try
            {
                ResponseModel result = new ResponseModel();
                result = _unitOfWork.UserPostRepository.userCommentOnPost(obj);

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

        public ResponseModel reactOnPostComment(vmPostCommentReaction obj)
        {
            try
            {
                ResponseModel result = new ResponseModel();
                result = _unitOfWork.UserPostRepository.reactOnPostComment(obj);

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


        public ResponseModel GetLoggedInUserPost(int? userId)
        {
            try
            {
                ResponseModel result = new ResponseModel();
                result = _unitOfWork.UserPostRepository.GetLoggedInUserPost(userId);

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

        public ResponseModel GetLoggedInUserFriendPost(int? userId)
        {
            try
            {
                ResponseModel result = new ResponseModel();
                result = _unitOfWork.UserPostRepository.GetLoggedInUserFriendPost(userId);

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


