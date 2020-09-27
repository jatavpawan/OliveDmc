using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace BusinessRespository.Infrastructure
{
   public class WebHelper
    {
        public static string WRequestobj(string URL, string postData)
        {
            
            string stuff = null;
            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(URL);


                httpWebRequest.ContentType = "application/json;charset=UTF-8";
                httpWebRequest.Method = "POST";
                httpWebRequest.KeepAlive = false;
                httpWebRequest.Timeout = 600000;


                httpWebRequest.KeepAlive = false;
                httpWebRequest.ProtocolVersion = HttpVersion.Version10;
                System.Net.ServicePointManager.MaxServicePointIdleTime = 60000;
                // httpWebRequest.ServicePoint.Expect100Continue = false;

                System.Net.ServicePointManager.Expect100Continue = false;

                if (httpWebRequest.Method == "POST")
                {
                    using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                    {
                        //string postData = "{\"UID\": \"135\"}";
                        streamWriter.Write(postData);
                        streamWriter.Flush();
                        streamWriter.Close();
                    }
                }
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                string results;
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    results = streamReader.ReadToEnd();
                }

                //  stuff = results;
                //  JObject jObject = JObject.Parse(results);

                //obj = JsonConvert.DeserializeObject<MakeAppointment.NotificationInfo[]>(jObject["d"].ToString());
                JObject jObject = JObject.Parse(results);
                stuff = jObject["d"].ToString();
            }

            catch (WebException ex)
            {
                Console.WriteLine(ex);
                if (ex.Status == WebExceptionStatus.ProtocolError)
                {
                    HttpWebResponse response = ex.Response as HttpWebResponse;
                }
            }
            return stuff;
        }

    }
}
