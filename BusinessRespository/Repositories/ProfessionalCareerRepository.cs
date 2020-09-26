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
   class ProfessionalCareerRepository : IProfessionalCareerRepository
    {
        private TravelOliveContext Context;

        public ProfessionalCareerRepository(TravelOliveContext _context)
        {
            Context = _context;
        }

        public ResponseModel AddUpdateProfessionalCareer(vmProfessionalCareer obj)
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
                    if (obj.UploadResume != null) uploadcls.fileUpload(obj.UploadResume, @"Uploads\Career\ProfessionalCareer\UploadResume", UploadResume);

                }

                string UploadProject = string.Empty;
                if (obj.UploadProject != null)
                {
                    var prefixpath = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Millisecond.ToString() + DateTime.Now.Second.ToString();
                    UploadProject = obj.UploadProject != null ? prefixpath + "_" + obj.UploadProject.FileName : null;

                    FileUploadcls uploadcls = new FileUploadcls();
                    if (obj.UploadProject != null) uploadcls.fileUpload(obj.UploadProject, @"Uploads\Career\ProfessionalCareer\UploadProject", UploadProject);

                }


                if (obj.Id > 0)
                {
                    var ProfessionalCareerObj = Context.ProfessionalCareer.Where(z => z.Id == obj.Id).FirstOrDefault();
                    ProfessionalCareerObj.TotalExperience = obj.TotalExperience;
                    ProfessionalCareerObj.HighestQualification = obj.HighestQualification;
                    ProfessionalCareerObj.CurrentCompany = obj.CurrentCompany;
                    ProfessionalCareerObj.CurrentLocation = obj.CurrentLocation;
                    ProfessionalCareerObj.CurrentCtc = obj.CurrentCtc;
                    ProfessionalCareerObj.ExpectedCtc = obj.ExpectedCtc;
                    ProfessionalCareerObj.SkillId = obj.SkillId;
                    ProfessionalCareerObj.AreaOfExpertise = obj.AreaOfExpertise;
                    ProfessionalCareerObj.AboutMe = obj.AboutMe;
                    ProfessionalCareerObj.RecUpd = "U";
                    ProfessionalCareerObj.UpdatedBy = obj.UpdatedBy;
                    ProfessionalCareerObj.UpdatedDate = DateTime.Now;
                    if (obj.UploadResume != null)
                    {
                        FileUploadcls uploadcls = new FileUploadcls();
                        uploadcls.fileDeleted(@"Uploads\Career\ProfessionalCareer\UploadResume", ProfessionalCareerObj.UploadResume);
                        ProfessionalCareerObj.UploadResume = UploadResume;
                    }

                    if (obj.UploadProject != null)
                    {
                        FileUploadcls uploadcls = new FileUploadcls();
                        uploadcls.fileDeleted(@"Uploads\Career\ProfessionalCareer\UploadProject", ProfessionalCareerObj.UploadProject);
                        ProfessionalCareerObj.UploadProject = UploadProject;
                    }

                    Context.SaveChanges();
                    result.message = "Successfully Updated";
                    result.status = Status.Success;

                }
                else
                {
                   var ProfessionalCareerDetail = new ProfessionalCareer
                        {
                            TotalExperience = obj.TotalExperience,
                            HighestQualification = obj.HighestQualification,
                            CurrentCompany = obj.CurrentCompany,
                            CurrentLocation = obj.CurrentLocation,
                            CurrentCtc = obj.CurrentCtc,
                            ExpectedCtc = obj.ExpectedCtc,
                            SkillId = obj.SkillId,
                            AreaOfExpertise = obj.AreaOfExpertise,
                            AboutMe = obj.AboutMe,
                            RecUpd = "C",    
                            CreatedBy = obj.CreatedBy,
                            CreatedDate = DateTime.Now,
                            UploadProject = UploadProject,
                            UploadResume = UploadResume
                        };

                        Context.ProfessionalCareer.Add(ProfessionalCareerDetail);
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


        public ResponseModel GetAllProfessionalCareer()
        {
            ResponseModel result = new ResponseModel();
            try
            {
                List<ProfessionalCareer> resultValue = new List<ProfessionalCareer>();
                resultValue = Context.ProfessionalCareer.Where(z => z.RecUpd != "D").ToList();

                result.data = resultValue;
                result.status = Status.Success;
                result.message = "List for ProfessionalCareer";
            }
            catch (Exception ex)
            {
                result.status = Status.Error;
                result.error = ex.Message;

            }
            return result;
        }


        public ResponseModel deleteProfessionalCareer(int? Id)
        {
            ResponseModel result = new ResponseModel();
            try
            {
                List<ProfessionalCareer> lst = new List<ProfessionalCareer>();
                if (Id > 0)
                {
                    var ProfessionalCareerDetail = Context.ProfessionalCareer.Where(z => z.Id == Id).FirstOrDefault();
                    ProfessionalCareerDetail.RecUpd = "D";
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

        public ResponseModel GetProfessionalCareerById(int? Id)
        {
            ResponseModel result = new ResponseModel();
            try
            {
                var ProfessionalCareerObj = new ProfessionalCareer();

                if (Id > 0)
                {
                    ProfessionalCareerObj = Context.ProfessionalCareer.Where(z => z.Id == Id).FirstOrDefault();
                }

                result.data = ProfessionalCareerObj;
                result.status = Status.Success;
                result.message = "ProfessionalCareer Detail";
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
