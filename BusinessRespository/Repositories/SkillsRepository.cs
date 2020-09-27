using BusinessDataModel.DB;
using BusinessDataModel.ViewModel;
using BusinessRespository.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessRespository.Repositories
{
    class SkillsRepository : ISkillsRepository
    {
        private TravelOliveContext Context;

        public SkillsRepository(TravelOliveContext _context)
        {
            Context = _context;
        }

        public ResponseModel AddUpdateSkills(Skills obj)
        {
            ResponseModel result = new ResponseModel();
            try
            {
                if (obj.Id > 0)
                {
                    var SkillsObj = Context.Skills.Where(z => z.Id == obj.Id).FirstOrDefault();
                    SkillsObj.SkillName = obj.SkillName;
                    SkillsObj.ShowInFrontEnd = obj.ShowInFrontEnd;
                    SkillsObj.RecUpd = "U";

                    SkillsObj.UpdatedBy = obj.UpdatedBy;
                    SkillsObj.UpdatedDate = DateTime.Now;
                    Context.SaveChanges();
                    result.message = "Successfully Updated";
                    result.status = Status.Success;

                }
                else
                {
                    if (!Context.Skills.Where(z => z.SkillName == obj.SkillName && z.RecUpd != "D").Any())
                    {
                        var SkillsDetail = new Skills
                        {
                            SkillName = obj.SkillName,
                            ShowInFrontEnd = obj.ShowInFrontEnd,
                            RecUpd = "C",
                            CreatedBy = obj.CreatedBy,
                            CreatedDate = DateTime.Now,
                        };

                        Context.Skills.Add(SkillsDetail);
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


        public ResponseModel GetAllSkills()
        {
            ResponseModel result = new ResponseModel();
            try
            {
                List<Skills> resultValue = new List<Skills>();
                resultValue = Context.Skills.Where(z => z.RecUpd != "D").ToList();

                result.data = resultValue;
                result.status = Status.Success;
                result.message = "List for Skills";
            }
            catch (Exception ex)
            {
                result.status = Status.Error;
                result.error = ex.Message;

            }
            return result;
        }


        public ResponseModel deleteSkills(int? Id)
        {
            ResponseModel result = new ResponseModel();
            try
            {
                List<Skills> lst = new List<Skills>();
                if (Id > 0)
                {
                    var SkillsDetail = Context.Skills.Where(z => z.Id == Id).FirstOrDefault();
                    SkillsDetail.RecUpd = "D";
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

        public ResponseModel GetSkillsById(int? Id)
        {
            ResponseModel result = new ResponseModel();
            try
            {
                var SkillsObj = new Skills();

                if (Id > 0)
                {
                    SkillsObj = Context.Skills.Where(z => z.Id == Id).FirstOrDefault();
                }

                result.data = SkillsObj;
                result.status = Status.Success;
                result.message = "Skills Detail";
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
