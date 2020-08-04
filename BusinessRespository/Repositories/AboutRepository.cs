using BusinessRespository.IRepositories;
//using DataModel.DB;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
//using Microsoft.Extensions.Configuration;
using System.Linq;

namespace BusinessRespository.Repositories
{
    public class AboutRepository : IAboutRepository, IDisposable
    {

        private bool disposed = false;
        //private PersonIntegration personIntegration;
        //private EzContext Context;
        //private EzContext db;
        //private IConfiguration _configuration;
        //public AboutRepository(EzContext context)
        //{
        //    Context = context;
        //    personIntegration = new PersonIntegration(context);
        //}

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    Debug.WriteLine("UnitOfWork is being disposed");
                    //Context.Dispose();
                }
            }
            this.disposed = true;
        }

        //public int AddMail(string email, string jobtitle)
        //{
        //    if (!(Context.Leads.Where(a => a.LeadEmail.Trim().ToLower() == email.Trim().ToLower()).Select(a => a.LeadEmail).Count() > 0))
        //    {
        //        Leads obj = new Leads()
        //    {
        //        LeadEmail = email,
        //        LeadOptOut = "N",
        //        JobTitle = jobtitle
        //    };
        //    Context.Leads.Add(obj);
        //    Context.SaveChanges();
        //    return 1;
        //    }
        //    return 0;
        //}
    }
}
