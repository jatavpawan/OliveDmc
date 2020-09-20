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
    public class UserPersonalInfoService : IUserPersonalInfoService
    {
        private IUnitOfWork _unitOfWork;
        public IHttpContextAccessor __httpContextaccessor;
        private ResponseModel response;

        public UserPersonalInfoService(IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor)
        {
            _unitOfWork = unitOfWork;
            response = new ResponseModel();
            __httpContextaccessor = httpContextAccessor;
            //if (_httpContextaccessor.HttpContext.Session.GetString("Userdetail") != null)
            //    //{
            //    //    SessionUser = JsonConvert.DeserializeObject<Registration>(_httpContextaccessor.HttpContext.Session.GetString("Userdetail"));
            //    //}
        }

        public ResponseModel AddUpdateUserPersonalInfo(Registration obj)
        {
            try
            {
                ResponseModel result = new ResponseModel();
                result = _unitOfWork.UserPersonalInfoRepository.AddUpdateUserPersonalInfo(obj);

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
        public ResponseModel GetAllUserPersonalInfo()
        {
            try
            {
                ResponseModel result = new ResponseModel();
                result = _unitOfWork.UserPersonalInfoRepository.GetAllUserPersonalInfo();

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

        public ResponseModel deleteUserPersonalInfo(int? Id)
        {
            try
            {
                ResponseModel result = new ResponseModel();
                result = _unitOfWork.UserPersonalInfoRepository.deleteUserPersonalInfo(Id);

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



        public ResponseModel GetUserPersonalInfoByUserId(int? Id)
        {
            try
            {
                ResponseModel result = new ResponseModel();
                result = _unitOfWork.UserPersonalInfoRepository.GetUserPersonalInfoByUserId(Id);

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


        public ResponseModel AddUpdateUserProfileImage(vmUserProfileImage obj)
        {
            try
            {
                ResponseModel result = new ResponseModel();
                result = _unitOfWork.UserPersonalInfoRepository.AddUpdateUserProfileImage(obj);

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

        public ResponseModel AddUpdateUserAboutDescription(vmUserAboutDescription obj)
        {
            try
            {
                ResponseModel result = new ResponseModel();
                result = _unitOfWork.UserPersonalInfoRepository.AddUpdateUserAboutDescription(obj);

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

        public ResponseModel AddUpdateUserCoverImage(vmUserCoverImg obj)
        {
            try
            {
                ResponseModel result = new ResponseModel();
                result = _unitOfWork.UserPersonalInfoRepository.AddUpdateUserCoverImage(obj);

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

        public ResponseModel increamentInVisitCount(int? profleUserId)
        {
            try
            {
                ResponseModel result = new ResponseModel();
                result = _unitOfWork.UserPersonalInfoRepository.increamentInVisitCount(profleUserId);

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
