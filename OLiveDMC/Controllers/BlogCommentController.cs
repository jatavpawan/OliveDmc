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

    public class BlogCommentController : ControllerBase
    {
        private IBlogCommentService _BlogCommentService;
        public BlogCommentController(IBlogCommentService BlogCommentService)
        {
            _BlogCommentService = BlogCommentService;
        }

        [HttpPost]
        [Route("AddUpdateBlogComment")]
        public async Task<ResponseModel> AddUpdateBlogComment(BlogComment obj)
        {
            var Data = _BlogCommentService.AddUpdateBlogComment(obj);
            return await System.Threading.Tasks.Task.FromResult(Data);
        }


        [HttpGet]
        [Route("GetAllBlogComment")]
        public async Task<ResponseModel> GetAllBlogComment()
        {
            var Data = _BlogCommentService.GetAllBlogComment();
            return await System.Threading.Tasks.Task.FromResult(Data);
        }

        [HttpGet]
        [Route("deleteBlogComment")]
        public async Task<ResponseModel> deleteBlogComment(int? Id)
        {
            var Data = _BlogCommentService.deleteBlogComment(Id);
            return await System.Threading.Tasks.Task.FromResult(Data);
        }


        [HttpGet]
        [Route("GetBlogCommentById")]
        public async Task<ResponseModel> GetBlogCommentDetailByBlogCommentId(int? Id)
        {
            var Data = _BlogCommentService.GetBlogCommentById(Id);
            return await System.Threading.Tasks.Task.FromResult(Data);
        }

        [HttpGet]
        [Route("GetAllBlogCommentByBlogId")]
        public async Task<ResponseModel> GetAllBlogCommentByBlogId(int? blogId)
        {
            var Data = _BlogCommentService.GetAllBlogCommentByBlogId(blogId);
            return await System.Threading.Tasks.Task.FromResult(Data);
        }



     
    }
}