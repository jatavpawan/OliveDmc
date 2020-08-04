using BusinessDataModel.DB;
using BusinessDataModel.ViewModel;
using BusinessRespository.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessRespository.Repositories
{
    class ProfileCategoryRepository: IProfileCategoryRepository
    {
        private TravelOliveContext Context;

        public ProfileCategoryRepository(TravelOliveContext _context)
        {
            Context = _context;
        }
     
        public ResponseModel AddUpdateProfileCategory(ProfileCategory obj)
        {
            ResponseModel result = new ResponseModel();
            try
            {
                if (obj.Id > 0)
                {
                    var ProfileCategoryObj = Context.ProfileCategory.Where(z => z.Id == obj.Id).FirstOrDefault();
                    ProfileCategoryObj.CategoryName = obj.CategoryName;
                    ProfileCategoryObj.RecUpd = "U";

                    ProfileCategoryObj.UpdatedBy = obj.UpdatedBy;
                    ProfileCategoryObj.UpdatedDate = DateTime.Now;
                    Context.SaveChanges();
                    result.message = "Successfully Updated";
                    result.status = Status.Success;

                }
                else
                {
                    if (!Context.ProfileCategory.Where(z => z.CategoryName == obj.CategoryName && z.RecUpd != "D").Any())
                    {
                        var ProfileCategoryDetail = new ProfileCategory
                        {
                            CategoryName = obj.CategoryName,
                            RecUpd = "C",
                            CreatedBy = obj.CreatedBy,
                            CreatedDate = DateTime.Now,
                        };

                        Context.ProfileCategory.Add(ProfileCategoryDetail);
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


        public ResponseModel GetAllProfileCategory()
        {
            ResponseModel result = new ResponseModel();
            try
            {
                List<ProfileCategory> resultValue = new List<ProfileCategory>();
                resultValue = Context.ProfileCategory.Where(z => z.RecUpd != "D").ToList();

                result.data = resultValue;
                result.status = Status.Success;
                result.message = "List for ProfileCategory";
            }
            catch (Exception ex)
            {
                result.status = Status.Error;
                result.error = ex.Message;

            }
            return result;
        }


        public ResponseModel deleteProfileCategory(int? Id)
        {
            ResponseModel result = new ResponseModel();
            try
            {
                List<ProfileCategory> lst = new List<ProfileCategory>();
                if (Id > 0)
                {
                    var ProfileCategoryDetail = Context.ProfileCategory.Where(z => z.Id == Id).FirstOrDefault();
                    ProfileCategoryDetail.RecUpd = "D";
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

        public ResponseModel GetProfileCategoryById(int? Id)
        {
            ResponseModel result = new ResponseModel();
            try
            {
                var ProfileCategoryObj = new ProfileCategory();

                if (Id > 0)
                {
                    ProfileCategoryObj = Context.ProfileCategory.Where(z => z.Id == Id).FirstOrDefault();
                }

                result.data = ProfileCategoryObj;
                result.status = Status.Success;
                result.message = "ProfileCategory Detail";
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
