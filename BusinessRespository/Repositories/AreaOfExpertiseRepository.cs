using BusinessDataModel.DB;
using BusinessDataModel.ViewModel;
using BusinessRespository.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessRespository.Repositories
{
    class AreaOfExpertiseRepository : IAreaOfExpertiseRepository
    {
        private TravelOliveContext Context;

        public AreaOfExpertiseRepository(TravelOliveContext _context)
        {
            Context = _context;
        }

        public ResponseModel AddUpdateAreaOfExpertise(AreaOfExpertise obj)
        {
            ResponseModel result = new ResponseModel();
            try
            {
                if (obj.Id > 0)
                {
                    var AreaOfExpertiseObj = Context.AreaOfExpertise.Where(z => z.Id == obj.Id).FirstOrDefault();
                    AreaOfExpertiseObj.Name = obj.Name;
                    AreaOfExpertiseObj.ShowInFrontEnd = obj.ShowInFrontEnd;
                    AreaOfExpertiseObj.RecUpd = "U";

                    AreaOfExpertiseObj.UpdatedBy = obj.UpdatedBy;
                    AreaOfExpertiseObj.UpdatedDate = DateTime.Now;
                    Context.SaveChanges();
                    result.message = "Successfully Updated";
                    result.status = Status.Success;

                }
                else
                {
                    if (!Context.AreaOfExpertise.Where(z => z.Name == obj.Name && z.RecUpd != "D").Any())
                    {
                        var AreaOfExpertiseDetail = new AreaOfExpertise
                        {
                            Name = obj.Name,
                            ShowInFrontEnd = obj.ShowInFrontEnd,
                            RecUpd = "C",
                            CreatedBy = obj.CreatedBy,
                            CreatedDate = DateTime.Now,
                        };

                        Context.AreaOfExpertise.Add(AreaOfExpertiseDetail);
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


        public ResponseModel GetAllAreaOfExpertise()
        {
            ResponseModel result = new ResponseModel();
            try
            {
                List<AreaOfExpertise> resultValue = new List<AreaOfExpertise>();
                resultValue = Context.AreaOfExpertise.Where(z => z.RecUpd != "D").ToList();

                result.data = resultValue;
                result.status = Status.Success;
                result.message = "List for AreaOfExpertise";
            }
            catch (Exception ex)
            {
                result.status = Status.Error;
                result.error = ex.Message;

            }
            return result;
        }


        public ResponseModel deleteAreaOfExpertise(int? Id)
        {
            ResponseModel result = new ResponseModel();
            try
            {
                List<AreaOfExpertise> lst = new List<AreaOfExpertise>();
                if (Id > 0)
                {
                    var AreaOfExpertiseDetail = Context.AreaOfExpertise.Where(z => z.Id == Id).FirstOrDefault();
                    AreaOfExpertiseDetail.RecUpd = "D";
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

        public ResponseModel GetAreaOfExpertiseById(int? Id)
        {
            ResponseModel result = new ResponseModel();
            try
            {
                var AreaOfExpertiseObj = new AreaOfExpertise();

                if (Id > 0)
                {
                    AreaOfExpertiseObj = Context.AreaOfExpertise.Where(z => z.Id == Id).FirstOrDefault();
                }

                result.data = AreaOfExpertiseObj;
                result.status = Status.Success;
                result.message = "AreaOfExpertise Detail";
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
