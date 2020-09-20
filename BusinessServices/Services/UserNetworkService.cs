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
   
    public class UserNetworkService : IUserNetworkService
    {
        private IUnitOfWork _unitOfWork;
        public IHttpContextAccessor __httpContextaccessor;
        private ResponseModel response;

        public UserNetworkService(IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor)
        {
            _unitOfWork = unitOfWork;
            response = new ResponseModel();
            __httpContextaccessor = httpContextAccessor;
            //if (_httpContextaccessor.HttpContext.Session.GetString("Userdetail") != null)
            //    //{
            //    //    SessionUser = JsonConvert.DeserializeObject<Registration>(_httpContextaccessor.HttpContext.Session.GetString("Userdetail"));
            //    //}
        }

        public ResponseModel AddUpdateUserNetwork(ContactUs obj)
        {
            try
            {
                ResponseModel result = new ResponseModel();
                result = _unitOfWork.UserNetworkRepository.AddUpdateUserNetwork(obj);

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
        public ResponseModel GetAllUserNetwork()
        {
            try
            {
                ResponseModel result = new ResponseModel();
                result = _unitOfWork.UserNetworkRepository.GetAllUserNetwork();

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

        public ResponseModel deleteUserNetwork(int? Id)
        {
            try
            {
                ResponseModel result = new ResponseModel();
                result = _unitOfWork.UserNetworkRepository.deleteUserNetwork(Id);

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



        public ResponseModel GetUserNetworkDetailById(int? Id)
        {
            try
            {
                ResponseModel result = new ResponseModel();
                result = _unitOfWork.UserNetworkRepository.GetUserNetworkDetailById(Id);

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

        public ResponseModel sendFriendRequest(UserFriendsRequest obj)
        {
            try
            {
                ResponseModel result = new ResponseModel();
                result = _unitOfWork.UserNetworkRepository.sendFriendRequest(obj);

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

        public ResponseModel getAddFriendRequestList(int? userid)
        {
            try
            {
                ResponseModel result = new ResponseModel();
                result = _unitOfWork.UserNetworkRepository.getAddFriendRequestList(userid);

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

        public ResponseModel actionOnFriendRequest(UserFriendsRequest obj)
        {
            try
            {
                ResponseModel result = new ResponseModel();
                result = _unitOfWork.UserNetworkRepository.actionOnFriendRequest(obj);
                
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

        public ResponseModel userFriendList(int? userid)
        {
            try
            {
                ResponseModel result = new ResponseModel();
                result = _unitOfWork.UserNetworkRepository.userFriendList(userid);

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

        public ResponseModel userPendingRequestList(int? userid)
        {
            try
            {
                ResponseModel result = new ResponseModel();
                result = _unitOfWork.UserNetworkRepository.userPendingRequestList(userid);

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

        public ResponseModel GetAllUserInNetwork(int userid)
        {
            try
            {
                ResponseModel result = new ResponseModel();
                result = _unitOfWork.UserNetworkRepository.GetAllUserInNetwork(userid);

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

        public ResponseModel cancelSendFriendRequest(vmcancelSendFriendRequest obj)
        {
            try
            {
                ResponseModel result = new ResponseModel();
                result = _unitOfWork.UserNetworkRepository.cancelSendFriendRequest(obj);

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

       
        public ResponseModel unfriend(vmUnFriend obj)
        {
            try
            {
                ResponseModel result = new ResponseModel();
                result = _unitOfWork.UserNetworkRepository.unfriend(obj);

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
