using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    public class UserPostController : ControllerBase
    {
        private IUserPostService _UserPostService;
        public UserPostController(IUserPostService UserPostService)
        {
            _UserPostService = UserPostService;
        }

        [HttpPost]
        [Route("AddUpdateUserPost")]
        public async Task<ResponseModel> AddUpdateUserPost([FromForm]vmUserPost obj)
        {
            var Data = _UserPostService.AddUpdateUserPost(obj);
            return await System.Threading.Tasks.Task.FromResult(Data);
        }


        [HttpGet]
        [Route("GetAllUserPost")]
        public async Task<ResponseModel> GetAllUserPost()
        {
            var Data = _UserPostService.GetAllUserPost();
            return await System.Threading.Tasks.Task.FromResult(Data);
        }

        [HttpGet]
        [Route("deleteUserPost")]
        public async Task<ResponseModel> deleteUserPost(int? Id)
        {
            var Data = _UserPostService.deleteUserPost(Id);
            return await System.Threading.Tasks.Task.FromResult(Data);
        }

        [HttpPost]
        [Route("fileUploadInUserPost")]
        public async Task<ResponseModel> fileUploadInUserPost([FromForm] vmfileInfo obj)
        {
            var Data = _UserPostService.fileUploadInUserPost(obj);
            return await System.Threading.Tasks.Task.FromResult(Data);
        }


        [HttpGet]
        [Route("GetUserPostDetailByUserPostId")]
        public async Task<ResponseModel> GetUserPostDetailByUserPostId(int? Id)
        {
            var Data = _UserPostService.GetUserPostDetailByUserPostId(Id);
            return await System.Threading.Tasks.Task.FromResult(Data);
        }

        [HttpPost]
        [Route("videoUploadInUserPost")]
        public async Task<ResponseModel> videoUploadInUserPost([FromForm] vmfileInfo obj)
        {
            var Data = _UserPostService.videoUploadInUserPost(obj);
            return await System.Threading.Tasks.Task.FromResult(Data);
        }

        [HttpGet]
        [Route("deleteVideoInUserPost")]
        public async Task<ResponseModel> deleteVideoInUserPost(string oldVideoName)
        {
            var Data = _UserPostService.deleteVideoInUserPost(oldVideoName);
            return await System.Threading.Tasks.Task.FromResult(Data);
        }

        [HttpGet]
        [Route("GetAllUserPostByUserId")]
        public async Task<ResponseModel> GetAllUserPostByUserId(int? userId)
        {
            var Data = _UserPostService.GetAllUserPostByUserId(userId);
            return await System.Threading.Tasks.Task.FromResult(Data);
        }

        [HttpPost]
        [Route("userReactOnPost")]
        public async Task<ResponseModel> userReactOnPost(vmUserPostReaction obj)
        {
            var Data = _UserPostService.userReactOnPost(obj);
            return await System.Threading.Tasks.Task.FromResult(Data);
        }

        [HttpPost]
        [Route("userCommentOnPost")]
        public async Task<ResponseModel> userCommentOnPost(vmPostComment obj)
        {
            var Data = _UserPostService.userCommentOnPost(obj);
            return await System.Threading.Tasks.Task.FromResult(Data);
        }

        [HttpPost]
        [Route("reactOnPostComment")]
        public async Task<ResponseModel> reactOnPostComment(vmPostCommentReaction obj)
        {
            var Data = _UserPostService.reactOnPostComment(obj);
            return await System.Threading.Tasks.Task.FromResult(Data);
        }

        [HttpGet]
        [Route("GetLoggedInUserPost")]
        public async Task<ResponseModel> GetLoggedInUserPost(int? userId)
        {
            var Data = _UserPostService.GetLoggedInUserPost(userId);
            return await System.Threading.Tasks.Task.FromResult(Data);
        }

        [HttpGet]
        [Route("GetLoggedInUserFriendPost")]
        public async Task<ResponseModel> GetLoggedInUserFriendPost(int? userId)
        {
            var Data = _UserPostService.GetLoggedInUserFriendPost(userId);
            return await System.Threading.Tasks.Task.FromResult(Data);
        }

    }
}