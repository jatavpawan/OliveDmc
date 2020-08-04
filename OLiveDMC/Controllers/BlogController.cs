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
    public class BlogController : ControllerBase
    {
        private IBlogService _BlogService;
        public BlogController(IBlogService BlogService)
        {
            _BlogService = BlogService;
        }

        [HttpPost]
        [Route("AddUpdateBlog")]
        public async Task<ResponseModel> AddUpdateBlog([FromForm]vmBlog obj)
        {
            var Data = _BlogService.AddUpdateBlog(obj);
            return await System.Threading.Tasks.Task.FromResult(Data);
        }


        [HttpGet]
        [Route("GetAllBlog")]
        public async Task<ResponseModel> GetAllBlog()
        {
            var Data = _BlogService.GetAllBlog();
            return await System.Threading.Tasks.Task.FromResult(Data);
        }

        [HttpGet]
        [Route("deleteBlog")]
        public async Task<ResponseModel> deleteBlog(int? Id)
        {
            var Data = _BlogService.deleteBlog(Id);
            return await System.Threading.Tasks.Task.FromResult(Data);
        }

        [HttpPost]
        [Route("fileUploadInBlog")]
        public async Task<ResponseModel> fileUploadInBlog([FromForm] vmfileInfo obj)
        {
            var Data = _BlogService.fileUploadInBlog(obj);
            return await System.Threading.Tasks.Task.FromResult(Data);
        }

        [HttpGet]
        [Route("GetBlogDetailByBlogId")]
        public async Task<ResponseModel> GetBlogDetailByBlogId(int? Id)
        {
            var Data = _BlogService.GetBlogDetailByBlogId(Id);
            return await System.Threading.Tasks.Task.FromResult(Data);
        }

        [HttpPost]
        [Route("setBlogPriority")]
        public async Task<ResponseModel> setBlogPriority( List<BlogPriority> obj)
        {
            var Data = _BlogService.setBlogPriority(obj);
            return await System.Threading.Tasks.Task.FromResult(Data);
        }


        [HttpGet]
        [Route("AllBlogPriorityList")]
        public async Task<ResponseModel> AllBlogPriorityList()
        {
            var Data = _BlogService.AllBlogPriorityList();
            return await System.Threading.Tasks.Task.FromResult(Data);
        }
        [HttpGet]
        [Route("AllBlogPriorityListInUserPanel")]
        public async Task<ResponseModel> AllBlogPriorityListInUserPanel()
        {
            var Data = _BlogService.AllBlogPriorityListInUserPanel();
            return await System.Threading.Tasks.Task.FromResult(Data);
        }
        



    }
}