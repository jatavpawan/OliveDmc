using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessDataModel.DB;
using BusinessDataModel.ViewModel;
using BusinessServices.IServices;
using CookApp.Filters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OLiveDMC.Controllers
{
   
    [Route("[controller]")]
    [ApiController]
    [TypeFilter(typeof(CustomException))]
    public class UserNetworkController : ControllerBase
    {
        private IUserNetworkService _UserNetworkService;
        public UserNetworkController(IUserNetworkService UserNetworkService)
        {
            _UserNetworkService = UserNetworkService;
        }

        [HttpPost]
        [Route("AddUpdateUserNetwork")]
        public async Task<ResponseModel> AddUpdateUserNetwork(ContactUs obj)
        {
            var Data = _UserNetworkService.AddUpdateUserNetwork(obj);
            return await System.Threading.Tasks.Task.FromResult(Data);
        }


        [HttpGet]
        [Route("GetAllUserNetwork")]
        public async Task<ResponseModel> GetAllUserNetwork()
        {
            var Data = _UserNetworkService.GetAllUserNetwork();
            return await System.Threading.Tasks.Task.FromResult(Data);
        }

        [HttpGet]
        [Route("deleteUserNetwork")]
        public async Task<ResponseModel> deleteUserNetwork(int? Id)
        {
            var Data = _UserNetworkService.deleteUserNetwork(Id);
            return await System.Threading.Tasks.Task.FromResult(Data);
        }


        [HttpGet]
        [Route("GetUserNetworkDetailById")]
        public async Task<ResponseModel> GetUserNetworkDetailById(int? Id)
        {
            var Data = _UserNetworkService.GetUserNetworkDetailById(Id);
            return await System.Threading.Tasks.Task.FromResult(Data);
        }

        [HttpPost]
        [Route("sendFriendRequest")]
        public async Task<ResponseModel> sendFriendRequest(UserFriendsRequest obj)
        {
            var Data = _UserNetworkService.sendFriendRequest(obj);
            return await System.Threading.Tasks.Task.FromResult(Data);
        }

        [HttpGet]
        [Route("getAddFriendRequestList")]
        public async Task<ResponseModel> getAddFriendRequestList(int? userid)
        {
            var Data = _UserNetworkService.getAddFriendRequestList(userid);
            return await System.Threading.Tasks.Task.FromResult(Data);
        }

        [HttpPost]
        [Route("actionOnFriendRequest")]
        public async Task<ResponseModel> actionOnFriendRequest(UserFriendsRequest obj)
        {
            var Data = _UserNetworkService.actionOnFriendRequest(obj);
            return await System.Threading.Tasks.Task.FromResult(Data);
        }

        [HttpGet]
        [Route("userFriendList")]
        public async Task<ResponseModel> userFriendList(int? userid)
        {
            var Data = _UserNetworkService.userFriendList(userid);
            return await System.Threading.Tasks.Task.FromResult(Data);
        }


        [HttpGet]
        [Route("userPendingRequestList")]
        public async Task<ResponseModel> userPendingRequestList(int? userid)
        {
            var Data = _UserNetworkService.userPendingRequestList(userid);
            return await System.Threading.Tasks.Task.FromResult(Data);
        }

        [HttpGet]
        [Route("GetAllUserInNetwork")]
        public async Task<ResponseModel> GetAllUserInNetwork(int userid)
        {
            var Data = _UserNetworkService.GetAllUserInNetwork(userid);
            return await System.Threading.Tasks.Task.FromResult(Data);
        }

      
        [HttpPost]
        [Route("cancelSendFriendRequest")]
        public async Task<ResponseModel> cancelSendFriendRequest(vmcancelSendFriendRequest obj)
        {
            var Data = _UserNetworkService.cancelSendFriendRequest(obj);
            return await System.Threading.Tasks.Task.FromResult(Data);
        }

        [HttpPost]
        [Route("unfriend")]
        public async Task<ResponseModel> unfriend(vmUnFriend obj)
        {
            var Data = _UserNetworkService.unfriend(obj);
            return await System.Threading.Tasks.Task.FromResult(Data);
        }

        [HttpPost]
        [Route("SearchUserByText")]
        public async Task<ResponseModel> SearchUserByText(vmSearchUser obj)
        {
            var Data = _UserNetworkService.SearchUserByText(obj);
            return await System.Threading.Tasks.Task.FromResult(Data);
        }

    }
}