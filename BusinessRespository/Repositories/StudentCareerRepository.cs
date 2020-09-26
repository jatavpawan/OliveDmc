using BusinessDataModel.DB;
using BusinessDataModel.ViewModel;
using BusinessRespository.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessRespository.Repositories
{
    class StudentCareerRepository : IStudentCareerRepository
    {
        private TravelOliveContext Context;

        public StudentCareerRepository(TravelOliveContext _context)
        {
            Context = _context;
        }


        public ResponseModel AddUpdateStudentCareer(StudentCareer obj)
        {
            ResponseModel result = new ResponseModel();
            
            try
            {

                if (obj.Id > 0)
                {
                    var StudentCareerObj = Context.StudentCareer.Where(z => z.Id == obj.Id).FirstOrDefault();
                    StudentCareerObj.ApplyProject = obj.ApplyProject;
                    StudentCareerObj.ApplyInternship = obj.ApplyInternship;
                    StudentCareerObj.RecUpd = "U";

                    StudentCareerObj.UpdatedBy = obj.UpdatedBy;
                    StudentCareerObj.UpdatedDate = DateTime.Now;
                    Context.SaveChanges();
                    result.message = "Successfully Updated";
                    result.status = Status.Success;

                }
                else
                {
                        var StudentCareerDetail = new StudentCareer
                        {
                            ApplyProject= obj.ApplyProject,
                            ApplyInternship= obj.ApplyInternship,
                            RecUpd = "C",
                            CreatedBy = obj.CreatedBy,
                            CreatedDate = DateTime.Now,
                           
                        };

                        Context.StudentCareer.Add(StudentCareerDetail);
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


        public ResponseModel GetAllStudentCareer()
        {
            ResponseModel result = new ResponseModel();
            try
            {
                List<StudentCareer> resultValue = new List<StudentCareer>();
                resultValue = Context.StudentCareer.Where(z => z.RecUpd != "D").ToList();

                result.data = resultValue;
                result.status = Status.Success;
                result.message = "List for StudentCareer";
            }
            catch (Exception ex)
            {
                result.status = Status.Error;
                result.error = ex.Message;

            }
            return result;
        }


        public ResponseModel deleteStudentCareer(int? Id)
        {
            ResponseModel result = new ResponseModel();
            try
            {
                List<StudentCareer> lst = new List<StudentCareer>();
                if (Id > 0)
                {
                    var StudentCareerDetail = Context.StudentCareer.Where(z => z.Id == Id).FirstOrDefault();
                    StudentCareerDetail.RecUpd = "D";
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

        public ResponseModel GetStudentCareerById(int? Id)
        {
            ResponseModel result = new ResponseModel();
            try
            {
                var StudentCareerObj = new StudentCareer();

                if (Id > 0)
                {
                    StudentCareerObj = Context.StudentCareer.Where(z => z.Id == Id).FirstOrDefault();
                }

                result.data = StudentCareerObj;
                result.status = Status.Success;
                result.message = "StudentCareer Detail";
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
