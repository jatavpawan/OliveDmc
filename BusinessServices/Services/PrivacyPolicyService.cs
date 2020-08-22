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
        public class PrivacyPolicyService : IPrivacyPolicyService
        {
            private IUnitOfWork _unitOfWork;
            public IHttpContextAccessor __httpContextaccessor;
            private ResponseModel response;

            public PrivacyPolicyService(IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor)
            {
                _unitOfWork = unitOfWork;
                response = new ResponseModel();
                __httpContextaccessor = httpContextAccessor;
                //if (_httpContextaccessor.HttpContext.Session.GetString("Userdetail") != null)
                //    //{
                //    //    SessionUser = JsonConvert.DeserializeObject<Registration>(_httpContextaccessor.HttpContext.Session.GetString("Userdetail"));
                //    //}
            }

            public ResponseModel AddUpdatePrivacyPolicyDetail(PrivacyPolicy obj)
            {
                try
                {
                    ResponseModel result = new ResponseModel();
                    result = _unitOfWork.PrivacyPolicyRepository.AddUpdatePrivacyPolicyDetail(obj);

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

            public ResponseModel GetPrivacyPolicyDetail()
            {
                try
                {
                    var resultValue = _unitOfWork.PrivacyPolicyRepository.GetPrivacyPolicyDetail();
                    response.data = resultValue;
                    response.status = Status.Success;
                    //response.message = "About Us Listing";

                }
                catch (Exception ex)
                {
                    response.message = ex.Message;
                    response.status = Status.Error;
                }
                return response;
            }

            public ResponseModel deletePrivacyPolicyInfo(int? Id)
            {
                try
                {
                    var resultValue = _unitOfWork.PrivacyPolicyRepository.deletePrivacyPolicyInfo(Id);
                    if (resultValue != null)
                    {
                        response.status = Status.Success;
                        response.data = resultValue;
                        response.message = "Privacy Policy Information Deleted Successfully";
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

            public ResponseModel fileUploadInPrivacyPolicy(vmfileInfo obj)
            {
                try
                {
                    var resultValue = _unitOfWork.PrivacyPolicyRepository.fileUploadInPrivacyPolicy(obj);
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




        }
    }
