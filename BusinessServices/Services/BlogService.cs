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
    public class BlogService : IBlogService
    {
        private IUnitOfWork _unitOfWork;
        public IHttpContextAccessor __httpContextaccessor;
        private ResponseModel response;

        public BlogService(IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor)
        {
            _unitOfWork = unitOfWork;
            response = new ResponseModel();
            __httpContextaccessor = httpContextAccessor;
            //if (_httpContextaccessor.HttpContext.Session.GetString("Userdetail") != null)
            //    //{
            //    //    SessionUser = JsonConvert.DeserializeObject<Registration>(_httpContextaccessor.HttpContext.Session.GetString("Userdetail"));
            //    //}
        }

        public ResponseModel AddUpdateBlog(vmBlog obj)
        {
            try
            {
                ResponseModel result = new ResponseModel();
                result = _unitOfWork.BlogRepository.AddUpdateBlog(obj);

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
        public ResponseModel GetAllBlog()
        {
            try
            {
                ResponseModel result = new ResponseModel();
                result = _unitOfWork.BlogRepository.GetAllBlog();

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

        public ResponseModel deleteBlog(int? Id)
        {
            try
            {
                ResponseModel result = new ResponseModel();
                result = _unitOfWork.BlogRepository.deleteBlog(Id);

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


        public ResponseModel fileUploadInBlog(vmfileInfo obj)
        {
            try
            {
                var resultValue = _unitOfWork.BlogRepository.fileUploadInBlog(obj);
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

        

        public ResponseModel GetBlogDetailByBlogId(int? Id)
        {
            try
            {
                ResponseModel result = new ResponseModel();
                result = _unitOfWork.BlogRepository.GetBlogDetailByBlogId(Id);

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

        public ResponseModel setBlogPriority(List<BlogPriority> obj)
        {
            try
            {
                var resultValue = _unitOfWork.BlogRepository.setBlogPriority(obj);
                if (resultValue != null)
                {
                    response.status = Status.Success;
                    response.data = resultValue;
                    response.message = "Your Blog Priority Set ";
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

        public ResponseModel AllBlogPriorityList()
        {
            try
            {
                ResponseModel result = new ResponseModel();
                result = _unitOfWork.BlogRepository.AllBlogPriorityList();

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
        public ResponseModel AllBlogPriorityListInUserPanel()
        {
            try
            {
                ResponseModel result = new ResponseModel();
                result = _unitOfWork.BlogRepository.AllBlogPriorityListInUserPanel();

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

        public ResponseModel AllBlogInUserPanel(int pageNo)
        {
            try
            {
                ResponseModel result = new ResponseModel();
                result = _unitOfWork.BlogRepository.AllBlogInUserPanel(pageNo);

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
        
        public ResponseModel RandomBlogList()
        {
            try
            {
                ResponseModel result = new ResponseModel();
                result = _unitOfWork.BlogRepository.RandomBlogList();

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

        public ResponseModel RandomBlogListInDetail()
        {
            try
            {
                ResponseModel result = new ResponseModel();
                result = _unitOfWork.BlogRepository.RandomBlogListInDetail();

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



        public ResponseModel BlogListByCategoryId(vmCategoriesBlog obj)
        {
            try
            {
                ResponseModel result = new ResponseModel();
                result = _unitOfWork.BlogRepository.BlogListByCategoryId(obj);

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

        public ResponseModel userPostBlog(vmUserPostBlog obj)
        {
            try
            {
                ResponseModel result = new ResponseModel();
                result = _unitOfWork.BlogRepository.userPostBlog(obj);

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

        public ResponseModel userReactOnBlog(BlogReaction obj)
        {
            try
            {
                ResponseModel result = new ResponseModel();
                result = _unitOfWork.BlogRepository.userReactOnBlog(obj);

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

        public ResponseModel getPopularTag()
        {
            try
            {
                ResponseModel result = new ResponseModel();
                result = _unitOfWork.BlogRepository.getPopularTag();

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

        public ResponseModel searchBlog(vmSearchBlog obj)
        {
            try
            {
                ResponseModel result = new ResponseModel();
                result = _unitOfWork.BlogRepository.searchBlog(obj);

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
