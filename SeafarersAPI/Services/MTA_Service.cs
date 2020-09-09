using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace SeafarersAPI.Services
{
    public class MTA_Service
    {

         public string mta_base_uri = "";

        public string GetServiceRequestId()
        {
            string requestID = null;

            using (var client = new HttpClient())
            {
                requestID=this.GetRequestID(client);
            }

            return requestID;
        }

        public int SaveFileOnMTA(string fileInJson)
        {
            int fileID = -1;
            using (var client = new HttpClient())
            {
                fileID=this.SaveFile(client, fileInJson);
            }

            return fileID;
        }



        private string GetRequestID(HttpClient webClient)
        {
            string requestID = null;

            webClient.BaseAddress = new Uri(mta_base_uri);
            HttpResponseMessage response =webClient.GetAsync("api/Values").Result;

            if (response.IsSuccessStatusCode)
            {
                requestID = response.Content.ReadAsStringAsync().Result;

            }

            return requestID;
        }

        private int SaveFile(HttpClient webClient, string file)
        {
            webClient.BaseAddress = new Uri(mta_base_uri);

            var stringContent = new StringContent(file.ToString());

            var result=webClient.PostAsync("api/postFile", stringContent).Result;  //TODO: get the post address correctly

            if (result.IsSuccessStatusCode)
            {
                //TODO: get the file ID for the saved file, so that we can retrieve it later again.
            }


            return 123; // the fileID needs to be returned from MTA

        }

    }
}
