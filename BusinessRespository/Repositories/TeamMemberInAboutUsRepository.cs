using BusinessDataModel.DB;
using BusinessDataModel.ViewModel;
using BusinessRespository.IRepositories;
using BusinessRespository.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessRespository.Repositories
{
    class TeamMemberInAboutUsRepository : ITeamMemberInAboutUsRepository
    {
        private TravelOliveContext Context;

        public TeamMemberInAboutUsRepository(TravelOliveContext _context)
        {
            Context = _context;
        }

        public ResponseModel AddUpdateTeamMemberInAboutUs(vmTeamMemberInAboutUs obj)
        {
            ResponseModel result = new ResponseModel();
            try
            {
                string FeaturedImage = string.Empty;
                if (obj.FeaturedImage != null || obj.FeaturedImage != null || obj.FeaturedImage != null || obj.FeaturedImage != null)
                {
                    var prefixpath = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Millisecond.ToString() + DateTime.Now.Second.ToString();
                    FeaturedImage = obj.FeaturedImage != null ? prefixpath + "_" + obj.FeaturedImage.FileName : null;

                    FileUploadcls uploadcls = new FileUploadcls();
                    if (obj.FeaturedImage != null) uploadcls.fileUpload(obj.FeaturedImage, @"Uploads\TeamMemberInAboutUs\image", FeaturedImage);

                }

                if (obj.Id > 0)
                {
                    var TeamMemberInAboutUsObj = Context.TeamMemberInAboutUs.Where(z => z.Id == obj.Id).FirstOrDefault();
                    TeamMemberInAboutUsObj.Name = obj.Name;
                    TeamMemberInAboutUsObj.Designation = obj.Designation;
                    TeamMemberInAboutUsObj.ShowInFrontEnd = obj.ShowInFrontEnd;
                    TeamMemberInAboutUsObj.RecUpd = "U";
                    TeamMemberInAboutUsObj.UpdatedBy = obj.UpdatedBy;
                    TeamMemberInAboutUsObj.UpdatedDate = DateTime.Now;
                    if (obj.FeaturedImage != null)
                    {
                        FileUploadcls uploadcls = new FileUploadcls();
                        uploadcls.fileDeleted(@"Uploads\TeamMemberInAboutUs\image", TeamMemberInAboutUsObj.FeaturedImage);
                        TeamMemberInAboutUsObj.FeaturedImage = FeaturedImage;
                    }
                    Context.SaveChanges();
                    result.message = "Successfully Updated";
                    result.status = Status.Success;

                }
                else
                {

                    //var result1 = Context.TeamMemberInAboutUs.Where(z => z.TeamMemberInAboutUsName == obj.TeamMemberInAboutUsName).Any();


                    if (!Context.TeamMemberInAboutUs.Where(z => z.Name == obj.Name && z.RecUpd != "D").Any())
                    {
                        var TeamMemberInAboutUsDetail = new TeamMemberInAboutUs
                        {
                            Name = obj.Name,
                            Designation = obj.Designation,
                            ShowInFrontEnd = obj.ShowInFrontEnd,
                            RecUpd = "C",
                            CreatedBy = obj.CreatedBy,
                            CreatedDate = DateTime.Now,
                            FeaturedImage = FeaturedImage
                        };
                        Context.TeamMemberInAboutUs.Add(TeamMemberInAboutUsDetail);
                        Context.SaveChanges();
                        result.message = "Successfully Saved";
                        result.status = Status.Success;
                    }
                    else
                    {
                        result.message = "Record already Exists";
                        result.status = Status.Warning;
                    }

                }

            }
            catch (Exception ex)
            {
                result.status = Status.Error;
                result.error = ex.Message;
            }
            return result;
        }


        public ResponseModel GetAllTeamMemberInAboutUs()
        {
            ResponseModel result = new ResponseModel();
            try
            {
                List<TeamMemberInAboutUs> resultValue = new List<TeamMemberInAboutUs>();
                resultValue = Context.TeamMemberInAboutUs.Where(z => z.RecUpd != "D").ToList();

                result.data = resultValue;
                result.status = Status.Success;
                result.message = "List for TeamMemberInAboutUs";
            }
            catch (Exception ex)
            {
                result.status = Status.Error;
                result.error = ex.Message;

            }
            return result;
        }


        public ResponseModel deleteTeamMemberInAboutUs(int? Id)
        {
            ResponseModel result = new ResponseModel();
            try
            {
                List<TeamMemberInAboutUs> lst = new List<TeamMemberInAboutUs>();
                if (Id > 0)
                {
                    var TeamMemberInAboutUsDetail = Context.TeamMemberInAboutUs.Where(z => z.Id == Id).FirstOrDefault();
                    //FileUploadcls uploadcls = new FileUploadcls();
                    //uploadcls.fileDeleted(@"Uploads\TeamMemberInAboutUs\image", TeamMemberInAboutUsDetail.FeaturedImage);
                    TeamMemberInAboutUsDetail.RecUpd = "D";
                    //Context.TeamMemberInAboutUs.Remove(TeamMemberInAboutUsDetail);
                    Context.SaveChanges();
                }

                result.data = lst;
                result.status = Status.Success;
                result.message = "delete successfully";
            }
            catch (Exception ex)
            {
                result.status = Status.Error;
                result.error = ex.Message;

            }
            return result;
        }

        public string fileUploadInTeamMemberInAboutUs(vmfileInfo obj)
        {

            string imageFile = string.Empty;
            if (obj.fileInfo != null)
            {
                imageFile = obj.fileInfo != null ? obj.fileInfo.FileName : null;

                FileUploadcls uploadcls = new FileUploadcls();
                if (obj.fileInfo != null) uploadcls.fileUpload(obj.fileInfo, @"Uploads\TeamMemberInAboutUs\image", imageFile);

            }

            return imageFile;
        }


        public ResponseModel GetTeamMemberInAboutUsDetailByTeamMemberInAboutUsId(int? Id)
        {
            ResponseModel result = new ResponseModel();
            try
            {
                var TeamMemberInAboutUsDetail = new TeamMemberInAboutUs();
                if (Id > 0)
                {
                    TeamMemberInAboutUsDetail = Context.TeamMemberInAboutUs.Where(z => z.Id == Id).FirstOrDefault();
                }

                result.data = TeamMemberInAboutUsDetail;
                result.status = Status.Success;
                result.message = "TeamMemberInAboutUs Detail";
            }
            catch (Exception ex)
            {
                result.status = Status.Error;
                result.error = ex.Message;

            }
            return result;
        }

        public string videoUploadInTeamMemberInAboutUs(vmfileInfo obj)
        {
            throw new NotImplementedException();
        }

        public void deleteVideoInTeamMemberInAboutUs(string oldVideoName)
        {
            throw new NotImplementedException();
        }

        public ResponseModel GetAllTeamMemberinFrontEnd()
        {
            ResponseModel result = new ResponseModel();
            try
            {
                List<TeamMemberInAboutUs> resultValue = new List<TeamMemberInAboutUs>();
                resultValue = Context.TeamMemberInAboutUs.Where(z => z.RecUpd != "D" && z.ShowInFrontEnd == true).ToList();

                result.data = resultValue;
                result.status = Status.Success;
                result.message = "List for TeamMemberInAboutUs";
            }
            catch (Exception ex)
            {
                result.status = Status.Error;
                result.error = ex.Message;

            }
            return result;
        }

    }
}
