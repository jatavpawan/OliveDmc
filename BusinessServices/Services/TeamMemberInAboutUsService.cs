using BusinessDataModel.ViewModel;
using BusinessRespository.Infrastructure;
using BusinessServices.IServices;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessServices.Services
{
    public class TeamMemberInAboutUsService : ITeamMemberInAboutUsService
    {
        private IUnitOfWork _unitOfWork;
        public IHttpContextAccessor __httpContextaccessor;
        private ResponseModel response;

        public TeamMemberInAboutUsService(IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor)
        {
            _unitOfWork = unitOfWork;
            response = new ResponseModel();
            __httpContextaccessor = httpContextAccessor;
            //if (_httpContextaccessor.HttpContext.Session.GetString("Userdetail") != null)
            //    //{
            //    //    SessionUser = JsonConvert.DeserializeObject<Registration>(_httpContextaccessor.HttpContext.Session.GetString("Userdetail"));
            //    //}
        }

        public ResponseModel AddUpdateTeamMemberInAboutUs(vmTeamMemberInAboutUs obj)
        {
            try
            {
                ResponseModel result = new ResponseModel();
                result = _unitOfWork.TeamMemberInAboutUsRepository.AddUpdateTeamMemberInAboutUs(obj);

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
        public ResponseModel GetAllTeamMemberInAboutUs()
        {
            try
            {
                ResponseModel result = new ResponseModel();
                result = _unitOfWork.TeamMemberInAboutUsRepository.GetAllTeamMemberInAboutUs();

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

        public ResponseModel deleteTeamMemberInAboutUs(int? Id)
        {
            try
            {
                ResponseModel result = new ResponseModel();
                result = _unitOfWork.TeamMemberInAboutUsRepository.deleteTeamMemberInAboutUs(Id);

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


        public ResponseModel fileUploadInTeamMemberInAboutUs(vmfileInfo obj)
        {
            try
            {
                var resultValue = _unitOfWork.TeamMemberInAboutUsRepository.fileUploadInTeamMemberInAboutUs(obj);
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


        public ResponseModel GetTeamMemberInAboutUsDetailByTeamMemberInAboutUsId(int? Id)
        {
            try
            {
                ResponseModel result = new ResponseModel();
                result = _unitOfWork.TeamMemberInAboutUsRepository.GetTeamMemberInAboutUsDetailByTeamMemberInAboutUsId(Id);

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

        public ResponseModel videoUploadInTeamMemberInAboutUs(vmfileInfo obj)
        {
            try
            {
                var resultValue = _unitOfWork.TeamMemberInAboutUsRepository.videoUploadInTeamMemberInAboutUs(obj);
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

        public ResponseModel deleteVideoInTeamMemberInAboutUs(string oldVideoName)
        {
            try
            {
                _unitOfWork.TeamMemberInAboutUsRepository.deleteVideoInTeamMemberInAboutUs(oldVideoName);
                response.status = Status.Success;
                response.message = "file Delete Successfully";

            }
            catch (Exception ex)
            {
                response.data = ex.Message;
                response.status = Status.Error;
                response.message = "Execption Occured.";
            }
            return response;
        }

        public ResponseModel GetAllTeamMemberinFrontEnd()
        {
            try
            {
                ResponseModel result = new ResponseModel();
                result = _unitOfWork.TeamMemberInAboutUsRepository.GetAllTeamMemberinFrontEnd();

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
