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
    public class UserGalleryController : ControllerBase
    {
        private IUserGalleryService _UserGalleryService;
        public UserGalleryController(IUserGalleryService UserGalleryService)
        {
            _UserGalleryService = UserGalleryService;
        }

        [HttpPost]
        [Route("AddUpdateUserGallery")]
        public async Task<ResponseModel> AddUpdateUserGallery([FromForm]vmUserGallery obj)
        {
            var Data = _UserGalleryService.AddUpdateUserGallery(obj);
            return await System.Threading.Tasks.Task.FromResult(Data);
        }


        [HttpGet]
        [Route("GetAllUserGallery")]
        public async Task<ResponseModel> GetAllUserGallery()
        {
            var Data = _UserGalleryService.GetAllUserGallery();
            return await System.Threading.Tasks.Task.FromResult(Data);
        }

        [HttpGet]
        [Route("deleteUserGallery")]
        public async Task<ResponseModel> deleteUserGallery(int? Id)
        {
            var Data = _UserGalleryService.deleteUserGallery(Id);
            return await System.Threading.Tasks.Task.FromResult(Data);
        }

       
        [HttpGet]
        [Route("GetUserGalleryById")]
        public async Task<ResponseModel> GetUserGalleryById(int? Id)
        {
            var Data = _UserGalleryService.GetUserGalleryById(Id);
            return await System.Threading.Tasks.Task.FromResult(Data);
        }

        [HttpPost]
        [Route("videoUploadInUserGallery")]
        public async Task<ResponseModel> videoUploadInUserGallery([FromForm] vmfileInfo obj)
        {
            var Data = _UserGalleryService.videoUploadInUserGallery(obj);
            return await System.Threading.Tasks.Task.FromResult(Data);
        }

        [HttpGet]
        [Route("deleteVideoInUserGallery")]
        public async Task<ResponseModel> deleteVideoInUserGallery(string oldVideoName)
        {
            var Data = _UserGalleryService.deleteVideoInUserGallery(oldVideoName);
            return await System.Threading.Tasks.Task.FromResult(Data);
        }

        [HttpGet]
        [Route("GetAllUserGalleryByUserId")]
        public async Task<ResponseModel> GetAllUserGalleryByUserId(int? userId)
        {
            var Data = _UserGalleryService.GetAllUserGalleryByUserId(userId);
            return await System.Threading.Tasks.Task.FromResult(Data);
        }


        [HttpPost]
        [Route("userReactOnGallery")]
        public async Task<ResponseModel> userReactOnGallery(vmUserGalleryReaction obj)
        {
            var Data = _UserGalleryService.userReactOnGallery(obj);
            return await System.Threading.Tasks.Task.FromResult(Data);
        }

        [HttpPost]
        [Route("userCommentOnGallery")]
        public async Task<ResponseModel> userCommentOnGallery(vmGalleryComment obj)
        {
            var Data = _UserGalleryService.userCommentOnGallery(obj);
            return await System.Threading.Tasks.Task.FromResult(Data);
        }

        [HttpPost]
        [Route("reactOnGalleryComment")]
        public async Task<ResponseModel> reactOnGalleryComment(vmGalleryCommentReaction obj)
        {
            var Data = _UserGalleryService.reactOnGalleryComment(obj);
            return await System.Threading.Tasks.Task.FromResult(Data);
        }

        [HttpGet]
        [Route("GalleryDetailByUserId")]
        public async Task<ResponseModel> GalleryDetailByUserId(int? galleryId)
        {
            var Data = _UserGalleryService.GalleryDetailByUserId(galleryId);
            return await System.Threading.Tasks.Task.FromResult(Data);
        }



    }
}
