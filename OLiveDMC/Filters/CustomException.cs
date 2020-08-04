﻿using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace CookApp.Filters
    {
    public class CustomException : ExceptionFilterAttribute
    {


        public CustomException()
        {

        }

        public override void OnException(ExceptionContext context)
        {


            var folderName = Path.Combine("AppData", "LogData");
            if (!Directory.Exists(folderName))
            {
                Directory.CreateDirectory(folderName);
            }
            var filename = Path.Combine(folderName, "ErrorLog4.txt");



            FileStream stream;




            if (File.Exists(filename))
                stream = new FileStream(filename, FileMode.Append, FileAccess.Write);
            else
                stream = new FileStream(filename, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            using (StreamWriter w = new StreamWriter(stream))
            {
                w.Write("\r\nLog Entry : ");
                w.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(),
                    DateTime.Now.ToLongDateString());
                w.WriteLine("  :");
                w.WriteLine("  :{0}", context.Exception.Message);
                w.WriteLine("-------------------------------");

                w.Flush();
                w.Close();
            }


        }
    }
}
