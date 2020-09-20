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

    public class BlogCategoryController : ControllerBase
    {
        private IBlogCategoryService _BlogCategoryService;
        public BlogCategoryController(IBlogCategoryService BlogCategoryService)
        {
            _BlogCategoryService = BlogCategoryService;
        }

        [HttpPost]
        [Route("AddUpdateBlogCategory")]
        public async Task<ResponseModel> AddUpdateBlogCategory(BlogCategory obj)
        {
            var Data = _BlogCategoryService.AddUpdateBlogCategory(obj);
            return await System.Threading.Tasks.Task.FromResult(Data);
        }


        [HttpGet]
        [Route("GetAllBlogCategory")]
        public async Task<ResponseModel> GetAllBlogCategory()
        {
            var Data = _BlogCategoryService.GetAllBlogCategory();
            return await System.Threading.Tasks.Task.FromResult(Data);
        }

        [HttpGet]
        [Route("deleteBlogCategory")]
        public async Task<ResponseModel> deleteBlogCategory(int? Id)
        {
            var Data = _BlogCategoryService.deleteBlogCategory(Id);
            return await System.Threading.Tasks.Task.FromResult(Data);
        }


        [HttpGet]
        [Route("GetBlogCategoryById")]
        public async Task<ResponseModel> GetBlogCategoryDetailByBlogCategoryId(int? Id)
        {
            var Data = _BlogCategoryService.GetBlogCategoryById(Id);
            return await System.Threading.Tasks.Task.FromResult(Data);
        }
    }
}