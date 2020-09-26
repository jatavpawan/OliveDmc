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
    class FresherCareerRepository : IFresherCareerRepository
    {
        private TravelOliveContext Context;

        public FresherCareerRepository(TravelOliveContext _context)
        {
            Context = _context;
        }

        public ResponseModel AddUpdateFresherCareer(vmFresherCareer obj)
        {
            ResponseModel result = new ResponseModel();
            try
            {
                string UploadResume = string.Empty;
                if (obj.UploadResume != null)
                {
                    var prefixpath = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Millisecond.ToString() + DateTime.Now.Second.ToString();
                    UploadResume = obj.UploadResume != null ? prefixpath + "_" + obj.UploadResume.FileName : null;

                    FileUploadcls uploadcls = new FileUploadcls();
                    if (obj.UploadResume != null) uploadcls.fileUpload(obj.UploadResume, @"Uploads\Career\FresherCareer\UploadResume", UploadResume);

                }

                string UploadProject = string.Empty;
                if (obj.UploadProject != null)
                {
                    var prefixpath = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Millisecond.ToString() + DateTime.Now.Second.ToString();
                    UploadProject = obj.UploadProject != null ? prefixpath + "_" + obj.UploadProject.FileName : null;

                    FileUploadcls uploadcls = new FileUploadcls();
                    if (obj.UploadProject != null) uploadcls.fileUpload(obj.UploadProject, @"Uploads\Career\FresherCareer\UploadProject", UploadProject);

                }


                if (obj.Id > 0)
                {
                    var FresherCareerObj = Context.FresherCareer.Where(z => z.Id == obj.Id).FirstOrDefault();
                    FresherCareerObj.Location = obj.Location;
                    FresherCareerObj.SkillId = obj.SkillId;
                    FresherCareerObj.SocialMediaProfile = obj.SocialMediaProfile;
                    FresherCareerObj.AboutMe = obj.AboutMe;
                    FresherCareerObj.RecUpd = "U";
                    FresherCareerObj.UpdatedBy = obj.UpdatedBy;
                    FresherCareerObj.UpdatedDate = DateTime.Now;
                    if (obj.UploadResume != null)
                    {
                        FileUploadcls uploadcls = new FileUploadcls();
                        uploadcls.fileDeleted(@"Uploads\Career\FresherCareer\UploadResume", FresherCareerObj.UploadResume);
                        FresherCareerObj.UploadResume = UploadResume;
                    }

                    if (obj.UploadProject != null)
                    {
                        FileUploadcls uploadcls = new FileUploadcls();
                        uploadcls.fileDeleted(@"Uploads\Career\FresherCareer\UploadProject", FresherCareerObj.UploadProject);
                        FresherCareerObj.UploadProject = UploadProject;
                    }

                    Context.SaveChanges();
                    result.message = "Successfully Updated";
                    result.status = Status.Success;

                }
                else
                {
                    var FresherCareerDetail = new FresherCareer
                    {
                        Location = obj.Location,
                        SkillId = obj.SkillId,
                        SocialMediaProfile = obj.SocialMediaProfile,
                        AboutMe = obj.AboutMe,
                        RecUpd = "C",
                        CreatedBy = obj.CreatedBy,
                        CreatedDate = DateTime.Now,
                        UploadProject = UploadProject,
                        UploadResume = UploadResume
                    };

                    Context.FresherCareer.Add(FresherCareerDetail);
                    Context.SaveChanges();
                    result.message = "Successfully Saved";
                    result.status = Status.Success;


                }

            }
            catch (Exception ex)
            {
                result.status = Status.Error;
                result.error = ex.Message;
            }
            return result;
        }


        public ResponseModel GetAllFresherCareer()
        {
            ResponseModel result = new ResponseModel();
            try
            {
                List<FresherCareer> resultValue = new List<FresherCareer>();
                resultValue = Context.FresherCareer.Where(z => z.RecUpd != "D").ToList();

                result.data = resultValue;
                result.status = Status.Success;
                result.message = "List for FresherCareer";
            }
            catch (Exception ex)
            {
                result.status = Status.Error;
                result.error = ex.Message;

            }
            return result;
        }


        public ResponseModel deleteFresherCareer(int? Id)
        {
            ResponseModel result = new ResponseModel();
            try
            {
                List<FresherCareer> lst = new List<FresherCareer>();
                if (Id > 0)
                {
                    var FresherCareerDetail = Context.FresherCareer.Where(z => z.Id == Id).FirstOrDefault();
                    FresherCareerDetail.RecUpd = "D";
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

        public ResponseModel GetFresherCareerById(int? Id)
        {
            ResponseModel result = new ResponseModel();
            try
            {
                var FresherCareerObj = new FresherCareer();

                if (Id > 0)
                {
                    FresherCareerObj = Context.FresherCareer.Where(z => z.Id == Id).FirstOrDefault();
                }

                result.data = FresherCareerObj;
                result.status = Status.Success;
                result.message = "FresherCareer Detail";
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
