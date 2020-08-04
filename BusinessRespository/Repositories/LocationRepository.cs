using BusinessDataModel.DB;
using BusinessDataModel.ViewModel;
using BusinessRespository.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessRespository.Repositories
{
    class LocationRepository: ILocationRepository
    {
        private TravelOliveContext Context;

        public LocationRepository(TravelOliveContext _context)
        {
            Context = _context;
        }

        //--------------------------------Country-------------------------------------------

        public ResponseModel AddUpdateCountry(Country obj)
        {
            ResponseModel result = new ResponseModel();
            try
            {

                if (obj.Id > 0)
                {
                    var CountryObj = Context.Country.Where(z => z.Id == obj.Id).FirstOrDefault();
                    CountryObj.CountryName = obj.CountryName;
                    CountryObj.ContinentCode = obj.ContinentCode;
                    CountryObj.ContinentName = obj.ContinentName;
                    CountryObj.RecUpd = "U";

                    CountryObj.UpdatedBy = obj.UpdatedBy;
                    CountryObj.UpdatedDate = DateTime.Now;

                    Context.SaveChanges();
                    result.message = "Successfully Updated";
                    result.status = Status.Success;

                }
                else
                {

                    //var result1 = Context.Country.Where(z => z.CountryName == obj.CountryName).Any();


                    if (!Context.Country.Where(z => z.CountryName == obj.CountryName && z.RecUpd != "D").Any())
                    {
                        var CountryDetail = new Country
                        {
                            CountryName = obj.CountryName,
                            ContinentCode = obj.ContinentCode,
                            ContinentName = obj.ContinentName,
                            RecUpd = "C",
                            CreatedBy = obj.CreatedBy,
                            CreatedDate = DateTime.Now,
                        };
                        Context.Country.Add(CountryDetail);
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


        public ResponseModel GetAllCountry()
        {
            ResponseModel result = new ResponseModel();
            try
            {
                List<Country> resultValue = new List<Country>();
                resultValue = Context.Country.Where(z => z.RecUpd != "D").ToList();

                result.data = resultValue;
                result.status = Status.Success;
                result.message = "List for Country";
            }
            catch (Exception ex)
            {
                result.status = Status.Error;
                result.error = ex.Message;

            }
            return result;
        }


        public ResponseModel deleteCountry(int? Id)
        {
            ResponseModel result = new ResponseModel();
            try
            {
                List<Country> lst = new List<Country>();
                if (Id > 0)
                {
                    var CountryDetail = Context.Country.Where(z => z.Id == Id).FirstOrDefault();
                    CountryDetail.RecUpd = "D";
                    //Context.Country.Remove(CountryDetail);
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

        public ResponseModel GetCountryDetailByCountryId(int? Id)
        {
            ResponseModel result = new ResponseModel();
            try
            {
                var CountryDetail = new Country();
                if (Id > 0)
                {
                    CountryDetail = Context.Country.Where(z => z.Id == Id).FirstOrDefault();
                }

                result.data = CountryDetail;
                result.status = Status.Success;
                result.message = "Country Detail";
            }
            catch (Exception ex)
            {
                result.status = Status.Error;
                result.error = ex.Message;

            }
            return result;
        }


        //--------------------------------State-------------------------------------------

        public ResponseModel AddUpdateState(State obj)
        {
            ResponseModel result = new ResponseModel();
            try
            {

                if (obj.Id > 0)
                {
                    var StateObj = Context.State.Where(z => z.Id == obj.Id).FirstOrDefault();
                    StateObj.StateName = obj.StateName;
                    StateObj.CountryId = obj.CountryId;
                    StateObj.RecUpd = "U";

                    StateObj.UpdatedBy = obj.UpdatedBy;
                    StateObj.UpdatedDate = DateTime.Now;

                    Context.SaveChanges();
                    result.message = "Successfully Updated";
                    result.status = Status.Success;

                }
                else
                {

                    if (!Context.State.Where(z => z.StateName == obj.StateName && z.RecUpd != "D").Any())
                    {
                        var StateDetail = new State
                        {
                            StateName = obj.StateName,
                            CountryId = obj.CountryId,
                            RecUpd = "C",
                            CreatedBy = obj.CreatedBy,
                            CreatedDate = DateTime.Now,
                        };
                        Context.State.Add(StateDetail);
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


        public ResponseModel GetAllState()
        {
            ResponseModel result = new ResponseModel();
            try
            {
                List<vmState> resultValue = new List<vmState>();
                        
                var innerJoin = from s in Context.State 
                                  join c in Context.Country 
                                  on s.CountryId equals c.Id 
                                  select new vmState
                                  { 
                                      Id = s.Id,
                                      StateName = s.StateName,
                                      CountryId = s.CountryId,
                                      CountryName = c.CountryName,
                                      RecUpd = s.RecUpd,
                                      CreatedDate = s.CreatedDate,
                                      CreatedBy = s.CreatedBy,
                                      UpdatedDate = s.UpdatedDate,
                                      UpdatedBy = s.UpdatedBy,

                                  };

                resultValue = innerJoin.Where(x => x.RecUpd != "D").ToList(); 



        //resultValue = Context.State.Where(z => z.RecUpd != "D").ToList();

                result.data = resultValue;
                result.status = Status.Success;
                result.message = "List for State";
            }
            catch (Exception ex)
            {
                result.status = Status.Error;
                result.error = ex.Message;

            }
            return result;
        }


        public ResponseModel deleteState(int? Id)
        {
            ResponseModel result = new ResponseModel();
            try
            {
                List<State> lst = new List<State>();
                if (Id > 0)
                {
                    var StateDetail = Context.State.Where(z => z.Id == Id).FirstOrDefault();
                    StateDetail.RecUpd = "D";
                    //Context.State.Remove(StateDetail);
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

        public ResponseModel GetStateDetailByStateId(int? Id)
        {
            ResponseModel result = new ResponseModel();
            try
            {
                var StateDetail = new State();
                if (Id > 0)
                {
                    StateDetail = Context.State.Where(z => z.Id == Id).FirstOrDefault();
                }

                result.data = StateDetail;
                result.status = Status.Success;
                result.message = "State Detail";
            }
            catch (Exception ex)
            {
                result.status = Status.Error;
                result.error = ex.Message;

            }
            return result;
        }


        //--------------------------------City-------------------------------------------

        public ResponseModel AddUpdateCity(City obj)
        {
            ResponseModel result = new ResponseModel();
            try
            {

                if (obj.Id > 0)
                {
                    var CityObj = Context.City.Where(z => z.Id == obj.Id).FirstOrDefault();
                    CityObj.CityName = obj.CityName;
                    CityObj.StateId = obj.StateId;
                    CityObj.CountryId = obj.CountryId;
                    CityObj.RecUpd = "U";

                    CityObj.UpdatedBy = obj.UpdatedBy;
                    CityObj.UpdatedDate = DateTime.Now;

                    Context.SaveChanges();
                    result.message = "Successfully Updated";
                    result.status = Status.Success;

                }
                else
                {
                    if (!Context.City.Where(z => z.CityName == obj.CityName && z.RecUpd != "D").Any())
                    {
                        var CityDetail = new City
                        {
                            CityName = obj.CityName,
                            StateId = obj.StateId,
                            CountryId = obj.CountryId,
                            RecUpd = "C",
                            CreatedBy = obj.CreatedBy,
                            CreatedDate = DateTime.Now,
                        };
                        Context.City.Add(CityDetail);
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


        public ResponseModel GetAllCity()
        {
            ResponseModel result = new ResponseModel();
            try
            {
                List<vmCity> resultValue = new List<vmCity>();

                var innerJoin = from country in Context.Country
                                join city in Context.City
                                on country.Id equals city.CountryId
                                join state in Context.State
                                on city.StateId equals state.Id
                                select new vmCity
                                {
                                    Id = city.Id,
                                    CityName = city.CityName,
                                    StateId = city.StateId,
                                    StateName = state.StateName,
                                    CountryId = city.CountryId,
                                    CountryName = country.CountryName,
                                    RecUpd = city.RecUpd,
                                    CreatedDate = city.CreatedDate,
                                    CreatedBy = city.CreatedBy,
                                    UpdatedDate = city.UpdatedDate,
                                    UpdatedBy = city.UpdatedBy
                                };

                resultValue = innerJoin.Where(x => x.RecUpd != "D").ToList();

                //List<City> resultValue = new List<City>();
                //resultValue = Context.City.Where(z => z.RecUpd != "D").ToList();

                result.data = resultValue;
                result.status = Status.Success;
                result.message = "List for City";
            }
            catch (Exception ex)
            {
                result.status = Status.Error;
                result.error = ex.Message;

            }
            return result;
        }


        public ResponseModel deleteCity(int? Id)
        {
            ResponseModel result = new ResponseModel();
            try
            {
                List<City> lst = new List<City>();
                if (Id > 0)
                {
                    var CityDetail = Context.City.Where(z => z.Id == Id).FirstOrDefault();
                    CityDetail.RecUpd = "D";
                    //Context.City.Remove(CityDetail);
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

        public ResponseModel GetCityDetailByCityId(int? Id)
        {
            ResponseModel result = new ResponseModel();
            try
            {
                var CityDetail = new City();
                if (Id > 0)
                {
                    CityDetail = Context.City.Where(z => z.Id == Id).FirstOrDefault();
                }

                result.data = CityDetail;
                result.status = Status.Success;
                result.message = "City Detail";
            }
            catch (Exception ex)
            {
                result.status = Status.Error;
                result.error = ex.Message;

            }
            return result;
        }

        
        public ResponseModel GetStateByCountryId(int? countryId)
        {
            ResponseModel result = new ResponseModel();
            try
            {
                List<State> StateList = new List<State>();
                if (countryId > 0)
                {
                    StateList = Context.State.Where(z => z.CountryId == countryId).ToList<State>();
                }

                result.data = StateList;
                result.status = Status.Success;
                result.message = "State List";
            }
            catch (Exception ex)
            {
                result.status = Status.Error;
                result.error = ex.Message;

            }
            return result;
        }


        public ResponseModel GetCityByStateId(int? stateId)
        {
            ResponseModel result = new ResponseModel();
            try
            {
                List<City> CityList = new List<City>();
                if (stateId > 0)
                {
                    CityList = Context.City.Where(z => z.StateId == stateId).ToList<City>();
                }

                result.data = CityList;
                result.status = Status.Success;
                result.message = "City List";
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
