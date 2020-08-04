//using DataModel.DB;
//using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;

namespace BusinessRespository.Infrastructure
{
    public class SqlQueryHelper
    {
        //private EzContext Context;
        //public SqlQueryHelper(EzContext context)
        //{
        //    Context = context;
        //}
        //public List<T> RawSqlQuery<T>(string query, Func<DbDataReader, T> map)
        //{

        //    using (var command = Context.Database.GetDbConnection().CreateCommand())
        //    {
        //        command.CommandText = query;
        //        command.CommandType = CommandType.Text;

        //        Context.Database.OpenConnection();

        //        using (var result = command.ExecuteReader())
        //        {
        //            var entities = new List<T>();

        //            while (result.Read())
        //            {
        //                entities.Add(map(result));
        //            }

        //            return entities;
        //        }

        //    }
        //}
    }
}
